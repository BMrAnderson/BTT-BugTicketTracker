using BTT.Domain.Common.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Common.Events
{
    public class MediatRDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MediatRDomainEventDispatcher> _logger;

        public MediatRDomainEventDispatcher(IMediator mediator, ILogger<MediatRDomainEventDispatcher> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        public async Task Dispatch(IDomainEvent devent)
        {
            var domainEventNotification = CreateDomainEventNotification(devent);
            _logger.LogDebug("Dispatching Domain Event notification. EventType: {eventType}", devent.GetType());
            await _mediator.Publish(domainEventNotification);
        }

        private INotification CreateDomainEventNotification(IDomainEvent domainEvent)
        {
            var genericDispatcher = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
            return (INotification)Activator.CreateInstance(genericDispatcher, domainEvent);
        }
    }
}
