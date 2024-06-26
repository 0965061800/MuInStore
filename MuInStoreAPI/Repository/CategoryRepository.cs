﻿using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Data;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext _context;
		public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_context = dbContext;
		}

		public async Task<bool> CheckCategoryId(int id)
		{
			return await _context.Categories.AnyAsync(s => s.CatId == id);
		}
		public async Task<Category?> GetByIdAsync(int id)
		{
			return await _context.Categories.Include(c => c.Products).Include(c => c.Subcategories).ThenInclude(cc => cc.Products).FirstOrDefaultAsync(c => c.CatId == id);
		}
	}
}
