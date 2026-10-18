using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPutandPatch.Services
{
    public class Myservice : IMyService
    {
        private readonly Guid _Id;
        public Myservice()
        {
            _Id = Guid.NewGuid();
        }
        public Guid GetInstanceId()
        {
            return _Id;
        }
    }
}
