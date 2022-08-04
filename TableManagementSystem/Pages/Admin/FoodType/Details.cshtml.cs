using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableManagementLibrary.Data;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.Food
{
    public class DetailsModel : PageModel
    {
        private readonly IFoodType _foodType;

        public DetailsModel(IFoodType foodType)
        {
            _foodType = foodType;
        }

        public foodType foodType { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            foodType = await _foodType.GetFoodTypeById(id);

            if (foodType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
