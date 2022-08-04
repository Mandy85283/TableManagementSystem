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
    public class DeleteModel : PageModel
    {
        private readonly IFoodType _foodType;

        public DeleteModel(IFoodType foodType)
        {
            _foodType = foodType;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            foodType = await _foodType.GetFoodTypeById(id);

            if (foodType != null)
            {
               
                await _foodType.DeleteAsysn(foodType);
            }

            return RedirectToPage("./Index");
        }
    }
}
