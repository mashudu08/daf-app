using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ST10115884_MashuduLuvhengo_POE_TASK1.Models
{
    public class Disaster
    {
        [Key]
        public int disasterId { get; set; }
        public string disasterName { get; set; }
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string aidType { get; set; }
    }
}
