using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableManagementLibrary.Models
{
   public class tablePosition
    {

        /// <summary>
        /// TablePositionId
        /// </summary>
        [Key]
        [Required]
        public int TablePositionId { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }


    }
}
