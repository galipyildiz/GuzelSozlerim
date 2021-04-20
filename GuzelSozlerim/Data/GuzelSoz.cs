using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuzelSozlerim.Data
{
    public class GuzelSoz
    {
        public int Id { get; set; }

        [Required]
        public string Soz { get; set; }
    }
}
