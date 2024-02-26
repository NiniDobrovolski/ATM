using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class UsernameException : ApplicationException
    {
        private string _msg;

        public UsernameException()
        {
            _msg = "Username and password must not be same";
        }
        public override string Message
        {
            get { return $"{_msg}"; }
        }
    }
}
