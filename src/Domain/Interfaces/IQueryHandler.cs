namespace Domain.Interfaces;

public interface IQueryHandler<TQuery, TResponse>
{
    Task<TResponse> Handle(TQuery query);
}