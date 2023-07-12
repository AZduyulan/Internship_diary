namespace Staj.Service.Services
{
    public interface IEmailService
    {
        Task SendResetPasswordEmail(string emaillink, string to);
    }
}
