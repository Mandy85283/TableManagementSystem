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
    public class MealService: IMeal
    {
        private readonly ApplicationDbContext _context;

        public MealService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get meal list
        /// </summary>
        /// <returns></returns>
        public async Task<IList<meal>> GetMealList()
        {

           var meal = await _context.Meal.ToListAsync();

            return meal;
        }

        /// <summary>
        /// Get drop down list
        /// </summary>
        /// <returns></returns>
        public SelectList GetMealDDL()
        {

            var list = new SelectList(_context.Meal, "MealId", "Name");

            return list;
        }

        /// <summary>
        /// get meal by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<meal> GetMealByName(string name)
        {
            return await _context.Meal.FirstOrDefaultAsync(
                m => m.Name.Trim().ToLower() == name.Trim().ToLower()); 
   
        }

        /// <summary>
        /// get meal by id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<meal> GetMealById(int id)
        {
            return await _context.Meal.FirstOrDefaultAsync(
                m => m.MealId==id);

        }


        /// <summary>
        /// create meal record
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(meal meal)
        {
            _context.Meal.Add(meal);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// update record
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(meal meal)
        {
            _context.Attach(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        public async Task<bool>  DeleteAsysn(meal meal)
        {
            _context.Meal.Remove(meal);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// record exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool mealExists(int id)
        {
            return _context.Meal.Any(e => e.MealId == id);
        }

    }
}
