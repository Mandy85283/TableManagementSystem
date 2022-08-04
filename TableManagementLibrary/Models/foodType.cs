using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableManagementLibrary.Models
{
   public class foodType
    {

        /// <summary>
        /// FoodId
        /// </summary>
        [Key]
        [Required]
        public int FoodId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


    }
}
