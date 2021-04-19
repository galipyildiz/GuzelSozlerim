using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuzelSozlerim.Data
{
    public class Kullanici :IdentityUser
    {
        [Required]
        public string GorunenAd { get; set; }
    }
}
