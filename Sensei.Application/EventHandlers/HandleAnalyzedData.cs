using MediatR;
using Sensei.Application.Events;

namespace Sensei.Application.EventHandlers;

public class HandleAnalyzedData : INotificationHandler<SensorDataAnalyzedEvent>
{
    private readonly IMediator _mediator;

    public HandleAnalyzedData(IMediator mediator)
    {
        _mediator = mediator;
    }


    public Task Handle(SensorDataAnalyzedEvent notification, CancellationToken cancellationToken)
    {
        // save to database
        Console.WriteLine($"Saving the {notification.SensorDataAnalysis.Sensor.Name}'s " +
                          $"result: {notification.SensorDataAnalysis.Result} to db.");

        return Task.CompletedTask;
    }
}