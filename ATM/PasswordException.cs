using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class PasswordException : ApplicationException
    {
        private string _msg;

        public PasswordException()
        {
            _msg = "Password must be at least 8 character";
        }
        public override string Message
        {
            get { return $"{_msg}"; }
        }
    }
}
