using System.Net;

namespace TkashApi.Services
{
    public interface ITelekomService
    {
        (string, HttpStatusCode) ServiceRequest();
        (string, HttpStatusCode) ServiceRequestSpecial();
    }
}