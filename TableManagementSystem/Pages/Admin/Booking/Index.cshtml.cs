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
    public class IndexModel : PageModel
    {
        private readonly IBooking _booking;

        public IndexModel(IBooking booking)
        {
            _booking = booking;
        }

        public IList<bookingTable> bookingTable { get;set; }

        public async Task OnGetAsync()
        {
            var result = await _booking.GetBookingByDate();

            foreach (var item in result)
            {
                item.Status = true;
                await _booking.UpdateAsync(item);
            }
            bookingTable = await _booking.GetBookingList();
        }
    }
}
