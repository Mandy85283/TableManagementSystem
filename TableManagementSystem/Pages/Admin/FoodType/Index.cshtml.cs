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

namespace TableManagementSystem.Pages.Admin.Food
{
    public class IndexModel : PageModel
    {
        private readonly IFoodType _foodType;

        public IndexModel(IFoodType foodType)
        {
            _foodType = foodType;
        }

        public IList<foodType> foodType { get;set; }

        public async Task OnGetAsync()
        {
            foodType = await _foodType.GetFoodTypeList();
        }
    }
}
