using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class BankruptException : ApplicationException
    {
        private string _msg;

        public BankruptException()
        {
            _msg = "There is no money on your account";
        }

        public override string Message
        {
            get { return _msg; }
        }
    }
}
