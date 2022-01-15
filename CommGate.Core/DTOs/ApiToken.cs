using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    [Serializable]
    public class ApiToken
    {
        public string UserName { get; set; }
        public List<string> Claims { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
