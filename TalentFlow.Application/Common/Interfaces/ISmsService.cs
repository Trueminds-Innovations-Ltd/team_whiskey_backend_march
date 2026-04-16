using System.Threading.Tasks;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface ISmsService
    {
        Task SendAsync(string phoneNumber, string v);
        Task SendOtpAsync(string toPhoneNumber, string otpCode);
    }
}
