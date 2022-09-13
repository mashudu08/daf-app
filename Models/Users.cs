using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ST10115884_MashuduLuvhengo_POE_TASK1.Models
{
    public class Users
    {
        [Key]
        //public int userId { get; set; }
        //public string firstname { get; set; }
        //public string lastname { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        //public string userType { get; set; }
    }
}
