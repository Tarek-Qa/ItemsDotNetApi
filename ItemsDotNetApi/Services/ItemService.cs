using Microsoft.EntityFrameworkCore;
using ItemsDotNetApi.Data;
using ItemsDotNetApi.Entity;

namespace ItemsDotNetApi.Services
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _appDbContext;

        public ItemService(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }
        public async Task<Item> CreateAsync(Item item)
        {
            await _appDbContext.Items.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var item = await _appDbContext.Items.FirstOrDefaultAsync(p => p.Id == id);
            if (item != null)
            {
                _appDbContext.Items.Remove(item);
                await _appDbContext.SaveChangesAsync();
                id = item.Id;
            }
            return id;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _appDbContext.Items.ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _appDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Item item)
        {
            var existingItem = await _appDbContext.Items.FirstOrDefaultAsync(p => p.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
                existingItem.ImageUrl = item.ImageUrl;

                await _appDbContext.SaveChangesAsync();
            }
            return existingItem.Id;
        }
    }
}
