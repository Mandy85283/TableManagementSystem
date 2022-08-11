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

namespace TableManagementSystem.Pages.Admin.Guest
{
    public class EditModel : PageModel
    {
        private readonly IGuest _guest;

        public EditModel(IGuest guest)
        {
            _guest = guest;
        }

        [BindProperty]
        public guest guest { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
           

            guest = await _guest.GetGuestById(id);

            if (guest == null)
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
                await _guest.UpdateAsync(guest);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_guest.guestExists(guest.GuestId))
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
