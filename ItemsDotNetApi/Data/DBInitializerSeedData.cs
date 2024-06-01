using ItemsDotNetApi.Entity;



namespace ItemsDotNetApi.Data
{
    public static class DBInitializerSeedData
    {
        public static void InitializeDatabase(AppDbContext appDbContext)
        {
            if (appDbContext.Items.Any())
                return;

            var ItemOne = new Item
            {
                Name = "VELO",
                Description = "best selling snus product in Europe.",
                ImageUrl = "https://snusdaddy.com/media/amasty/shopby/option_images/slider/VELO.png"

            };
            var ItemTwo = new Item
            {
                Name = "Knox",
                Description = "A budget-friendly option, ",
                ImageUrl = "https://snusdaddy.com/media/amasty/shopby/option_images/slider/Knox_Logo_Additional_D_Black.png"

            };
            var ItemThree = new Item
            {
                Name = "Siberia",
                Description = "Notable for being one of the strongest snus ",
                ImageUrl = "https://snusdaddy.com/media/amasty/shopby/option_images/slider/siberia_logo.jpg"

            };

            appDbContext.Items.Add(ItemOne);
            appDbContext.Items.Add(ItemTwo);
            appDbContext.Items.Add(ItemThree);

            appDbContext.SaveChanges();
        }
    }
}
