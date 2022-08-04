using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TableManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TableManagementLibrary
{
    public class FlowerService: IFlowers
    {
        private readonly ApplicationDbContext _context;

        public FlowerService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get flower list
        /// </summary>
        /// <returns></returns>
        public async Task<IList<flowers>> GetFlowersList()
        {

           var flowers = await _context.Flowers.ToListAsync();

            return flowers;
        }

        /// <summary>
        /// get flower Drop Down list
        /// </summary>
        /// <returns></returns>
        public SelectList GetFlowersDDL()
        {

           var list= new SelectList(_context.Flowers, "FlowerId", "Name");

            return list;
        }

        /// <summary>
        /// get flower by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<flowers> GetFlowerById(int id)
        {
            return await _context.Flowers.FirstOrDefaultAsync(m => m.FlowerId == id);
   
        }

        /// <summary>
        /// get flower by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<flowers> GetFlowerByName(string name)
        {
            return await _context.Flowers.FirstOrDefaultAsync(
                m => m.Name.Trim().ToLower() == name.Trim().ToLower());

        }


        /// <summary>
        /// create flower record
        /// </summary>
        /// <param name="flowers"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(flowers flowers)
        {
            _context.Flowers.Add(flowers);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// update record
        /// </summary>
        /// <param name="flowers"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(flowers flowers)
        {
            _context.Attach(flowers).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="flowers"></param>
        /// <returns></returns>
        public async Task<bool>  DeleteAsysn(flowers flowers)
        {
            _context.Flowers.Remove(flowers);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// record exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool flowersExists(int id)
        {
            return _context.Flowers.Any(e => e.FlowerId == id);
        }

    }
}
