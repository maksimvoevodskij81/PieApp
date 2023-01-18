using PieApp.Models;

namespace PieApp.ViewModels
{
    public class HomeViewModel
    {
       public  IEnumerable<Pie> PiesOfTheWeek { get;}

        public HomeViewModel(IEnumerable<Pie> pieOfTheWeek)
        {
            PiesOfTheWeek = pieOfTheWeek;
        }
    }
}
