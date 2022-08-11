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

namespace TableManagementSystem.Pages.Admin.Guest
{
    public class DeleteModel : PageModel
    {
        private readonly IGuest _guest;

        public DeleteModel(IGuest guest)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
           
            guest = await _guest.GetGuestById(id);

            if (guest != null)
            {

                await _guest.DeleteAsysn(guest);
            }

            return RedirectToPage("./Index");
        }
    }
}
