using MediatR;

namespace Shared.Query;
public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class?
{

}