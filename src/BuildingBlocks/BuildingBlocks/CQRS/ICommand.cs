using MediatR;

namespace BuildingBlocks.CQRS
{
    //this interface doesn't return a response
    public interface ICommand: ICommand<Unit>
    {
    }

    //this interface returns a response
    public interface ICommand<out TResponse>: IRequest<TResponse>
    {
    }
}
