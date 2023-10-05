using MediatR;

namespace Shared.Query;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> 
    where TQuery : IQuery<TResponse> where TResponse : class?
{

}