using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class RefreshTokenVM
    {
        public RefreshTokenVM(string userName, DateTime expiresUtc)
        {
            Username = userName;
            ExpiresUtc = expiresUtc;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpiresUtc { get; set; }
    }
}
