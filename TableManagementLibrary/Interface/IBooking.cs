using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableManagementLibrary.Models;

namespace TableManagementLibrary.Interface
{
   public interface IBooking
    {
        /// <summary>
        /// get booking list
        /// </summary>
        /// <returns></returns>
         Task<IList<bookingTable>> GetBookingList();

        /// <summary>
        /// get booking by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<bookingTable> GetBookingById(int id);

        /// <summary>
        /// get booking by obj
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bookingTable> GetBookingByTable(bookingTable book);

        /// <summary>
        /// get table by date
        /// </summary>
        /// <returns></returns>
        Task<IList<bookingTable>> GetBookingByDate();

        /// <summary>
        /// create record
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(bookingTable booking);

        /// <summary>
        /// update record
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(bookingTable booking);

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        Task<bool> DeleteAsysn(bookingTable booking);

        /// <summary>
        /// record exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool bookingExists(int id);



    }
}
