using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableManagementLibrary.Models
{
   public class bookingTable
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Phone Number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// MealId
        /// </summary>
        [ForeignKey("MealId")]
        [Display(Name = "Meal")]
        public int MealId { get; set; }

        /// <summary>
        /// Meals
        /// </summary>
        public meal Meals { get; set; }


        /// <summary>
        /// TableId
        /// </summary>
        [ForeignKey("TableId")]
        [Display(Name = "Table")]
        public int TableId { get; set; }

        /// <summary>
        /// Tables
        /// </summary>
        public tables Table { get; set; }

        /// <summary>
        /// FoodId
        /// </summary>
        [ForeignKey("FoodId")]
        [Display(Name = "Food Type")]
        public int FoodId { get; set; }

        /// <summary>
        /// FoodTypes
        /// </summary>
        public foodType Type { get; set; }

        /// <summary>
        /// FlowerId
        /// </summary>
        [ForeignKey("FlowerId")]
        [Display(Name = "Flower")]
        public int FlowerId { get; set; }

        /// <summary>
        /// Flowers
        /// </summary>
        public flowers Flower { get; set; }

        /// <summary>
        /// TablePositionId
        /// </summary>
        [ForeignKey("TablePositionId")]
        [Display(Name = "Table Position")]
        public int TablePositionId { get; set; }

        /// <summary>
        /// TablePositions
        /// </summary>
        public tablePosition TablePositions { get; set; }



        /// <summary>
        /// DateTime
        /// </summary>
        [Required]
        [Display(Name = "Date Time")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// SpecialNotes
        /// </summary>
        [Required]
        [Display(Name = "Special Notes")]
        public string SpecialNotes { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [Display(Name = "Status")]
        public bool Status { get; set; }




    }
}
