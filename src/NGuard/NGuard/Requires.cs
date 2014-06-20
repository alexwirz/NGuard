using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGuard
{
    public class Requires
    {
        public static void That(bool condition)
        {
            if (!condition) throw new ContractViolated();
        }
    }
}
