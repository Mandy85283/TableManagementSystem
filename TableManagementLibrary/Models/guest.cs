using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableManagementLibrary.Models
{
   public class guest
    {

        /// <summary>
        /// GuestId
        /// </summary>
        [Key]
        [Required]
        public int GuestId { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        /// <summary>
        /// Phone Number
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


    }
}
