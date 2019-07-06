using TkashApi.Models;
namespace TkashApi.Services
{
    public interface ITelekom
    {
        string accessToken();
        string AtpRequest(AtpRequest payload);
        string B2C(CreditAsyncRequest payload);
        string C2B(C2BSimulate payload);
        string RegisterUrl(RegisterUrlRequest payload);
        string RegistrationRequest(RegistrationRequest payload);
        string ReplyNotification(ReplayNotification payload);
        string Transaction(TransactionRequest payload);
        string UpdateUrl(UpdateUrlRequest payload);
    }
}