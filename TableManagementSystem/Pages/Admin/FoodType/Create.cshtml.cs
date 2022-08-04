using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TableManagementLibrary.Data;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.Food
{
    public class CreateModel : PageModel
    {
        private readonly IFoodType _foodType;

        public CreateModel(IFoodType foodType)
        {
            _foodType = foodType;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public foodType foodType { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            foodType result = await _foodType.GetFoodTypeByName(foodType.Name);
            if (result != null)
            {
                ModelState.AddModelError(string.Empty, "food type already exists");
                return Page();
            }

            await _foodType.CreateAsync(foodType);

            return RedirectToPage("./Index");
        }
    }
}
