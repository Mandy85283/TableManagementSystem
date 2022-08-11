using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableManagementLibrary.Models;

namespace TableManagementLibrary.Interface
{
   public interface IGuest
    {
        /// <summary>
        /// get guest list
        /// </summary>
        /// <returns></returns>
         Task<IList<guest>> GetGuestList();

        /// <summary>
        /// get guest by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<guest> GetGuestById(int id);

        /// <summary>
        /// create record
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(guest guest);

        /// <summary>
        /// update record
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(guest guest);

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        Task<bool> DeleteAsysn(guest guest);

        /// <summary>
        /// record exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool guestExists(int id);



    }
}
