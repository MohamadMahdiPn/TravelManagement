namespace TravelManagement.Shared.Abstractions.Commands;

public interface ICommand
{
    
}

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}