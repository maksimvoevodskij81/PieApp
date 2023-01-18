
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PieApp.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly PieAppDbContext _pieAppDbContext;

        public PieRepository(PieAppDbContext pieAppDbContext)
        {
            _pieAppDbContext = pieAppDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                //return _pieAppDbContext.Pies.Include(c => c.Category);
                return _pieAppDbContext.Pies.Include("Category");

            }
        }


        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _pieAppDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId) => _pieAppDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _pieAppDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
