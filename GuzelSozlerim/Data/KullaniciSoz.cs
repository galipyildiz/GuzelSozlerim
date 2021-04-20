using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuzelSozlerim.Data
{
    public class KullaniciSoz
    {
        public string KullaniciId { get; set; }
        public int GuzelSozId { get; set; }
        public Kullanici Kullanici { get; set; }
        public GuzelSoz GuzelSoz { get; set; }
    }
}
