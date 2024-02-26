using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class WrongUsernameOrPasswordException : ApplicationException
    {
        private string _msg;

        public WrongUsernameOrPasswordException()
        {
            _msg = "Username or password is incorrect";
        }
        public override string Message
        {
            get { return $"{_msg}"; }
        }
    }
}
