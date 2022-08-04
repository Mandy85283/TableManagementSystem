using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableManagementLibrary;
using TableManagementLibrary.Data;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.Flowers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IFlowers _flowers;

        public IndexModel(IFlowers flowers)
        {
            _flowers = flowers;
        }

       
         public IList<flowers> flowers { get;set; }
        public async Task OnGetAsync()
        {
            flowers = await _flowers.GetFlowersList();
        }
    }
}
