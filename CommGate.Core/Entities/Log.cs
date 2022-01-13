using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Entities
{
    public class Log
    {
        public long ID { get; set; }

        public DateTime EventDate { get; set; }
        public int? ItemID { get; set; }
        public string TableName { get; set; }
        public string EventName { get; set; }
        public string Record { get; set; }
        public string OldRecord { get; set; }
        public string NewRecord { get; set; }
    }
}
