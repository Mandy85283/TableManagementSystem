using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TableManagementLibrary.Data;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.Food
{
    public class EditModel : PageModel
    {
        private readonly IFoodType _foodType;

        public EditModel(IFoodType foodType)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            try
            {
                await _foodType.UpdateAsync(foodType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_foodType.foodTypeExists(foodType.FoodId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

    }
}
