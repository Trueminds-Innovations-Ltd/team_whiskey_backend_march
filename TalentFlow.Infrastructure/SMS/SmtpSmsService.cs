using TalentFlow.Application.Common.Interfaces;

public class SmtpSmsService : ISmsService
{
    public Task SendAsync(string phoneNumber, string message)
    {
        // 🚫 Email-to-SMS does NOT work in Nigeria
        Console.WriteLine($"[SMS LOG] To: {phoneNumber} | Message: {message}");
        return Task.CompletedTask;
    }

    public Task SendOtpAsync(string toPhoneNumber, string otpCode)
    {
        Console.WriteLine($"[SMS OTP] To: {toPhoneNumber} | OTP: {otpCode}");
        return Task.CompletedTask;
    }
}