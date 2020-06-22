using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class BadClass
    {
        public string creditCardNumber;

        public string _ssn;

        public string SSN
        {
            get
            {
                return "***-**-1234";
            }
            set { _ssn = value; }
        }

        public int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 0 && value < 130)
                {
                    _age = value;
                }
            }
        }


    }
}
