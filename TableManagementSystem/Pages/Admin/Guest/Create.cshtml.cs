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

namespace TableManagementSystem.Pages.Admin.Guest
{
    public class CreateModel : PageModel
    {
        private readonly IGuest _guest;

        public CreateModel(IGuest guest)
        {
            _guest = guest;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public guest guest { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _guest.CreateAsync(guest);
           

            return RedirectToPage("./Index");
        }
    }
}
