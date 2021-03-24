using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Contracts
{
    public interface IRangeableDateTime : IDateTime
    {
        DateTime EndDueDate { get; }

        void ChangeDueDate(DateTime dateTime);
    }
}
