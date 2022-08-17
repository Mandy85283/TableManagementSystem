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

namespace TableManagementSystem.Pages.Admin.Booking
{
    public class EditModel : PageModel
    {
        private readonly IBooking _booking;
        private readonly IFlowers _flowers;
        private readonly IMeal _meal;
        private readonly ITables _table;
        private readonly IFoodType _foodType;
        private readonly ITablePosition _tablePosition;


        public EditModel(IBooking booking,
            IFlowers flowers, IMeal meal,
            ITables table,
            IFoodType foodtype,
            ITablePosition tablePosition)
        {
            _booking = booking;
            _flowers = flowers;
            _meal = meal;
            _table = table;
            _foodType = foodtype;
            _tablePosition = tablePosition;
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
            ViewData["FlowerId"] = _flowers.GetFlowersDDL();
            ViewData["MealId"] = _meal.GetMealDDL();
            ViewData["TableId"] = _table.GetTableDDL();
            ViewData["FoodId"] = _foodType.GetFoodTypeDDL();
            ViewData["TablePositionId"] = _tablePosition.GetTablePositionDDL();
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
                await _booking.UpdateAsync(bookingTable);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_booking.bookingExists(bookingTable.Id))
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
