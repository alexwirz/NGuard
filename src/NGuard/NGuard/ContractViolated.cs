using System;

namespace NGuard
{
    public class ContractViolated : Exception
    {
        public ContractViolated(string _description) : base(_description)
        {
        }
    }
}
