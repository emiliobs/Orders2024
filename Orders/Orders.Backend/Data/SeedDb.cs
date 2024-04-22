using Orders.Shared.Entities;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            this._context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoryAsync();
        }

        private async Task CheckCategoryAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tegnología" });
                _context.Categories.Add(new Category { Name = "Macotas" });
                _context.Categories.Add(new Category { Name = "Licores" });
                _context.Categories.Add(new Category { Name = "Cosmeticos" });
                _context.Categories.Add(new Category { Name = "Hogar" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "USA" });
                _context.Countries.Add(new Country { Name = "United Kingdom" });
                _context.Countries.Add(new Country { Name = "Perú" });
                _context.Countries.Add(new Country { Name = "Panama" });
                _context.Countries.Add(new Country { Name = "Argentina" });
                _context.Countries.Add(new Country { Name = "Italia" });

                await _context.SaveChangesAsync();
            }
        }
    }
}