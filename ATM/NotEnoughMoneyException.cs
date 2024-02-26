using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class NotEnoughMoneyException : ApplicationException
    {
        private string _msg;

        public NotEnoughMoneyException()
        {
            _msg = "There is not enough money on your balance";
        }
        public override string Message
        {
            get { return $"{_msg}"; }
        }
    }
}
