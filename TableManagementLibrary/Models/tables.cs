using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableManagementLibrary.Models
{
   public class tables
    {

        /// <summary>
        /// TableId
        /// </summary>
        [Key]
        [Required]
        public int TableId { get; set; }

        /// <summary>
        /// TableName
        /// </summary>
        [Required]
        [Display(Name = "Table Name")]
        public string TableName { get; set; }

        /// <summary>
        /// No_Of_Person
        /// </summary>
        [Required]
        [Display(Name = "No Of Persone")]
        public int No_Of_Person { get; set; }


        [NotMapped]
        public string Table
        {
            get { return TableName + "--- Person "+No_Of_Person; }
        }


    }
}
