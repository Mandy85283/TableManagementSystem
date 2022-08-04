using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TableManagementLibrary;
using TableManagementLibrary.Data;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.Flowers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IFlowers _flowers;

        public CreateModel(IFlowers flowers)
        {
            _flowers = flowers;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public flowers flowers { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            flowers result = await _flowers.GetFlowerByName(flowers.Name);
            if (result != null)
            {
                ModelState.AddModelError(string.Empty, "Flowers already exists");
                return Page();
            }

            await _flowers.CreateAsync(flowers);

            return RedirectToPage("./Index");
        }
    }
}
