using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableManagementLibrary.Data;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.Tables
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ITables _tables;

        public IndexModel(ITables tables)
        {
            _tables = tables;
        }

        public IList<tables> tables { get;set; }

        public async Task OnGetAsync()
        {
            tables = await _tables.GetTableList();
        }
    }
}
