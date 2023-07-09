using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkSudokuSlover.Exceptions
{
    [Serializable]
    public class ExceptionConnectDatabase : Exception
    {
        public ExceptionConnectDatabase() { }

        public ExceptionConnectDatabase(string message)
            : base(message) { }

        public ExceptionConnectDatabase(string message, Exception inner)
            : base(message, inner) { }
    }
}
