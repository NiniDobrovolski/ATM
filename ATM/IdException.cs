using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class IdException : ApplicationException
    {
        private string _msg;

        public IdException()
        {
            _msg = "Id must be 11 characters";
        }
        public override string Message
        {
            get { return $"{_msg}"; }
        }
    }
}
