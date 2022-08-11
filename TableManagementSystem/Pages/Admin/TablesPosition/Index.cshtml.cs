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

namespace TableManagementSystem.Pages.Admin.TablesPosition
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ITablePosition _tables;

        public IndexModel(ITablePosition tables)
        {
            _tables = tables;
        }

        public IList<tablePosition> tablePosition { get;set; }

        public async Task OnGetAsync()
        {
            tablePosition = await _tables.GetTablePositionList();
        }
    }
}
