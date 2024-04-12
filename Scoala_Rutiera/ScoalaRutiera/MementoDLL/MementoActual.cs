using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDLL
{
    public class MementoActual: IMemento
    {
        private string _name;
        private string _state;

        public MementoActual() { }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public string GetState()
        {
            throw new NotImplementedException();
        }
    }
}
