using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.LogSystem
{
    internal class NullLog : ILog
    {
      

        public void Info(string message, string position)
        {
            Trace.Write(String.Format("Info: {0} {1}", message, position));
        }

        public void Error(string message, string position)
        {
            Trace.Write(String.Format("Error: {0} {1}", message, position));
        }
    }
}
