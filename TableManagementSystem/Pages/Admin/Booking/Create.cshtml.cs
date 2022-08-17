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

namespace TableManagementSystem.Pages.Admin.Booking
{
    public class CreateModel : PageModel
    {
        private readonly IBooking _booking;
        private readonly IFlowers _flowers;
        private readonly IMeal _meal;
        private readonly ITables _table;
        private readonly IFoodType _foodType;
        private readonly ITablePosition _tablePosition;


        public CreateModel(IBooking booking,
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

        public IActionResult OnGet()
        {

            ViewData["FlowerId"] = _flowers.GetFlowersDDL();
            ViewData["MealId"] = _meal.GetMealDDL();
            ViewData["TableId"] = _table.GetTableDDL();
            ViewData["FoodId"] = _foodType.GetFoodTypeDDL();
            ViewData["TablePositionId"] = _tablePosition.GetTablePositionDDL();
            return Page();
        }

        [BindProperty]
        public bookingTable bookingTable { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bookingTable result = await _booking.GetBookingByTable(bookingTable);
            if (result != null)
            {
                ModelState.AddModelError(string.Empty, "Table already booked. Please select another table or meal");
                ViewData["FlowerId"] = _flowers.GetFlowersDDL();
                ViewData["MealId"] = _meal.GetMealDDL();
                ViewData["TableId"] = _table.GetTableDDL();
                ViewData["FoodId"] = _foodType.GetFoodTypeDDL();
                ViewData["TablePositionId"] = _tablePosition.GetTablePositionDDL();
                return Page();
            }

            await _booking.CreateAsync(bookingTable);

            return RedirectToPage("./Index");
        }
    }
}
