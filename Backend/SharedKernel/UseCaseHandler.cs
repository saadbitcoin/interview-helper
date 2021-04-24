using System.Threading.Tasks;

namespace SharedKernel
{
    public interface UseCaseHandler<Request, Response>
    {
        Task<Response> Handle(Request requestData);
    }
}