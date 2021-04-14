using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class OperationResult<T>
    {
        public OperationResult()
        {
            Mensaje = new List<string>();
        }

        public bool Ok { get; set; }
        public T ResultObject { get; set; }
        public List<string> Mensaje { get; set; }
    }
}
