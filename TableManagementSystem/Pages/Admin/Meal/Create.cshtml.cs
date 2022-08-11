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

namespace TableManagementSystem.Pages.Admin.Meal
{
    public class CreateModel : PageModel
    {
        private readonly IMeal _meal;

        public CreateModel(IMeal meal)
        {
            _meal = meal;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public meal meal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            meal result = await _meal.GetMealByName(meal.Name);
            if (result != null)
            {
                ModelState.AddModelError(string.Empty, "meal already exists");
                return Page();
            } 

            await _meal.CreateAsync(meal);

            return RedirectToPage("./Index");
        }
    }
}
