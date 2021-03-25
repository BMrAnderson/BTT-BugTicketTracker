using BTT.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Notifications
{
    public interface INotification : IDateTime
    {
        string Message { get; }
    }
}
