using CommGate.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Data.Repositories
{
    public class UnitOfWorkFactory
    {
        private UnitOfWorkFactory()
        {

        }
        public static IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
}
