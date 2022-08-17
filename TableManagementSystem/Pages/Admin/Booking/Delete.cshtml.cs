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

namespace TableManagementSystem.Pages.Admin.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly IBooking _booking;

        public DeleteModel(IBooking booking)
        {
            _booking = booking;
        }

        [BindProperty]
        public bookingTable bookingTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {


            bookingTable = await _booking.GetBookingById(id);

            if (bookingTable == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
           

            bookingTable = await _booking.GetBookingById(id);

            if (bookingTable != null)
            {

                await _booking.DeleteAsysn(bookingTable);
            }

            return RedirectToPage("./Index");
        }
    }
}
