
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

namespace TableManagementSystem.Pages.Admin.Flowers
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IFlowers _flowers;

        public DeleteModel(IFlowers flowers)
        {
            _flowers = flowers;
        }

        [BindProperty]
        public flowers flowers { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            flowers = await _flowers.GetFlowerById(id);

            if (flowers == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            flowers = await _flowers.GetFlowerById(id);

            if (flowers != null)
            {

                await _flowers.DeleteAsysn(flowers);
            }

            return RedirectToPage("./Index");
        }
    }
}
