namespace Application.Abstractions;

public interface ICommand;

public interface ICommand<TResponse> : ICommand;