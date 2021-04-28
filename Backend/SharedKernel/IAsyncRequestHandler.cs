using System.Threading.Tasks;

namespace SharedKernel
{
    public interface IAsyncRequestHandler<Request, Response>
    {
        Task<Response> Handle(Request requestData);
    }
}