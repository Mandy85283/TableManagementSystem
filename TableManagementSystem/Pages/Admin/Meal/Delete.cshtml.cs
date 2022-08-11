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

namespace TableManagementSystem.Pages.Admin.Meal
{
    public class DeleteModel : PageModel
    {
        private readonly IMeal _meal;

        public DeleteModel(IMeal meal)
        {
            _meal = meal;
        }

        [BindProperty]
        public meal meal { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            meal = await _meal.GetMealById(id);

            if (meal == null)
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

            meal = await _meal.GetMealById(id);

            if (meal != null)
            {

                await _meal.DeleteAsysn(meal);
            }

            return RedirectToPage("./Index");
        }
    }
}
