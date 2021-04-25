using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeSolutions.Models
{
    public class Shop
    {
        [Key]
        public int ShopID { get; set; }
        [Required]
        [Display(Name = "Shop Name")]
        public string ShopName { get; set; }
        [Required]
        [Display(Name = "Shop Address")]
        public string ShopAddress { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
