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
    public class IndexModel : PageModel
    {
        private readonly IMeal _meal;

        public IndexModel(IMeal meal)
        {
            _meal = meal;
        }

        public IList<meal> meal { get;set; }

        public async Task OnGetAsync()
        {
            meal = await _meal.GetMealList();
        }
    }
}
