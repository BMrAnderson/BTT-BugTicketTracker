using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Contracts
{
    public interface IMutableDetail
    {
        void ChangeName(string name);
        void ChangeDescription(string description);
    }
}
