using ItemsDotNetApi.Entity;



namespace ItemsDotNetApi.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(int id);
        Task<Item> CreateAsync(Item item);
        Task<int> UpdateAsync(int id, Item item);
        Task<int> DeleteAsync(int id);
    }
}
