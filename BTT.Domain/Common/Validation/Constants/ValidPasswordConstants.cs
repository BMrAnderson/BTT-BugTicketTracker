using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Common.Validation
{
    public static class ValidPasswordConstants
    {
        public const string RgxNumber = @"[0-9]+";
        public const string RgxUpperCase = @"[A-Z]+";
        public const string RgxMinMaxChars = @".{8,12}";
        public const string RgxLowerChar = @"[a-z]+";
        public const string RgxSymbols = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";
    }
}
