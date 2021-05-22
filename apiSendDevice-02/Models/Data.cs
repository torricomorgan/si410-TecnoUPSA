using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiSendDevice_02.Models
{
    public class Data
    {
        [Key]
        public string NameDevice { get; set; }
        [Required]
        public string Mensaje { get; set; }
    }
}
