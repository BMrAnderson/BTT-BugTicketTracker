using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Common.Events
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent devent);
    }
}
