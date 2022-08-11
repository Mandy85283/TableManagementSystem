using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableManagementLibrary.Models
{
   public class meal
    {

        /// <summary>
        /// MealId
        /// </summary>
        [Key]
        [Required]
        public int MealId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


    }
}
