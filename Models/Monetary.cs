using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ST10115884_MashuduLuvhengo_POE_TASK1.Models
{
    public class Monetary
    {
        [Key]
        public int monetaryId { get; set; }
        public int amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime donationDate { get; set; }
        public string donor { get; set; }
        
    }
}
