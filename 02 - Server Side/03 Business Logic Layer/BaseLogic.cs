using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNGive
{
    public class BaseLogic : IDisposable
    {
        protected CareNGiveEntities DB = new CareNGiveEntities();

        public void Dispose()
        {
            DB.Dispose();
        }
        
    }
}
