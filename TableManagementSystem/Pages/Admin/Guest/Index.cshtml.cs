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
    public class IndexModel : PageModel
    {
        private readonly IGuest _guest;

        public IndexModel(IGuest guest)
        {
            _guest = guest;
        }

        public IList<guest> guest { get;set; }

        public async Task OnGetAsync()
        {
            guest = await _guest.GetGuestList();
        }
    }
}
