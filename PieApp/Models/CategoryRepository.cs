namespace PieApp.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PieAppDbContext _pieAppDbContext;
        public CategoryRepository(PieAppDbContext pieAppDbContext) 
        { 
            _pieAppDbContext = pieAppDbContext;
        }

        public IEnumerable<Category> AllCategories => _pieAppDbContext.Categories.OrderBy(c => c.CategoryName);
    }
}
