using MediatR;
using Sensei.Application.Events;
using Sensei.Application.RequestHandlers;

namespace Sensei.Application.EventHandlers;

public class HandleReadData : INotificationHandler<SensorDataReadEvent>
{
    private readonly IMediator _mediator;

    public HandleReadData(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Handle(SensorDataReadEvent notification, CancellationToken cancellationToken)
    {
        // save to database
        Console.WriteLine($"Saving the {notification.SensorReadData.MountedSensor.Name}'s value " +
                          $"{notification.SensorReadData.SensorValue.Value} to db.");

        _mediator.Send(new AnalyzeSensorDataCommand(notification.SensorReadData), cancellationToken);
        
        return Task.CompletedTask;
    }
}