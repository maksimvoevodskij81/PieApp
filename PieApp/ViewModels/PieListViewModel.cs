using PieApp.Models;

namespace PieApp.ViewModels
{
    public class PieListViewModel
    {
       public IEnumerable<Pie> Pies { get;}
       public string? CurrentCategory { get;}

        public PieListViewModel(IEnumerable<Pie> pies, string? currentCaregory)
        {
            Pies = pies;
            CurrentCategory = currentCaregory;
        }
    }
}
