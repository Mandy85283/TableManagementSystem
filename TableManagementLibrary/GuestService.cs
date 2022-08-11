using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TableManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Data;

namespace TableManagementLibrary
{
    public class GuestService: IGuest
    {
        private readonly ApplicationDbContext _context;

        public GuestService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get guest list
        /// </summary>
        /// <returns></returns>
        public async Task<IList<guest>> GetGuestList()
        {

           var guest = await _context.Guests.ToListAsync();

            return guest;
        }

        /// <summary>
        /// get guest by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<guest> GetGuestById(int id)
        {
            return await _context.Guests.FirstOrDefaultAsync(m => m.GuestId == id);
   
        }


        /// <summary>
        /// create guest record
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
          public async Task<bool> CreateAsync(guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// update record
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(guest guest)
        {
            _context.Attach(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task<bool>  DeleteAsysn(guest guest)
        {
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// record exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool guestExists(int id)
        {
            return _context.Guests.Any(e => e.GuestId == id);
        }

    }
}
