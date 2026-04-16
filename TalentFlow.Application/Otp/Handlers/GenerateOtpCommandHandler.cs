using MediatR;
using TalentFlow.Application.Otp.Commands;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Otp.Handlers
{
    public class GenerateOtpCommandHandler : IRequestHandler<GenerateOtpCommand, string>
    {
        private readonly IOtpRepository _otpRepo;
        private readonly IUserRepository _userRepo;
        private readonly ISmsService _smsService;

        public GenerateOtpCommandHandler(
            IOtpRepository otpRepo,
            IUserRepository userRepo,
            ISmsService smsService)
        {
            _otpRepo = otpRepo;
            _userRepo = userRepo;
            _smsService = smsService;
        }

        public async Task<string> Handle(GenerateOtpCommand request, CancellationToken cancellationToken)
        {
            // 1. Get user
            var user = await _userRepo.GetByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User not found");

            // 2. Expire old OTPs
            var existingOtps = await _otpRepo.GetActiveOtpsByUserIdAsync(request.UserId);
            foreach (var otp in existingOtps)
            {
                otp.IsUsed = true;
                otp.ExpiresAt = DateTime.UtcNow;
                await _otpRepo.UpdateAsync(otp);
            }

            // 3. Generate new OTP
            var newOtp = new Random().Next(100000, 999999).ToString();

            var otpCode = new OtpCode
            {
                UserId = request.UserId,
                Code = newOtp,
                Channel = request.Channel,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            };

            await _otpRepo.AddAsync(otpCode);

            // 4. SEND SMS via Termii ✅
            await _smsService.SendAsync(
                user.PhoneNumber,
                $"Your TalentFlow OTP is {newOtp}"
            );

            return newOtp; // keep for DEV/debug only
        }
    }
}