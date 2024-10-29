namespace Domain.Interfaces;

public interface ICommandHandler<TCommand, TResponse>
{
    Task<TResponse> Handle(TCommand command);
}