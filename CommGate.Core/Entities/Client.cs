using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Entities
{
    public class Client
    {
        #region Constructors

        public Client() { }

        #endregion

        public string Id { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ApplicationTypes ApplicationType { get; set; }

        [Required]
        public bool IsClientAdminPanel { get; set; }

        [Required]
        public int RefreshTokenLifeTime { get; set; }

        [MaxLength(100)]
        public string AllowedOrigin { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public enum ApplicationTypes
        {
            JavaScript,
            NativeConfidential
        };
    }
}
