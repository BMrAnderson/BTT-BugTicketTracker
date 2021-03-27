using BTT.Application.Common.Events;
using BTT.Domain.Models.Members;
using BTT.Infrastructure.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BTT.Application.Common.Handlers
{
    public class OnMemberEmailChanged
    {
        public class Handler : INotificationHandler<DomainEventNotification<MemberChangedEmail>>
        {
            private readonly IssueTicketTrackerDBContext _dbContext;
            private readonly ILogger<Handler> _logger;

            public Handler(IssueTicketTrackerDBContext dbContext, ILogger<Handler> logger)
            {
                this._dbContext = dbContext;
                this._logger = logger;
            }

            public Task Handle(DomainEventNotification<MemberChangedEmail> notification, CancellationToken cancellationToken)
            {
                var domainEvent = notification.DomainEvent;

                try
                {
                    _logger.LogDebug("Handling Domain Event. EmailId : {emailId} Type: {type}", domainEvent.EventId, notification.GetType());

                    _dbContext.SaveChangesAsync(cancellationToken).GetAwaiter().GetResult();

                    return Task.CompletedTask;
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
    }
}
