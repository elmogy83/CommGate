using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(256)]
        public string TableName { get; set; }
        [MaxLength(256)]
        public string EventName { get; set; }
        public string Record { get; set; }
        public string OldRecord { get; set; }
        public string NewRecord { get; set; }
    }
}
