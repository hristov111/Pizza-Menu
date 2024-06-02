﻿using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace Menu.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuDbContext _context;
        public Menu(MenuDbContext Context)
        {
            _context = Context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _context.Dishes select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d=>d.Name.Contains(searchString));

				return View(await dishes.ToListAsync());

			}
			return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context.Dishes
                .Include(di => di.DishIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(x=>x.DishId == id);
            if (dish == null) 
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
