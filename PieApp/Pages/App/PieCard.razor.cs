using PieApp.Models;
using Microsoft.AspNetCore.Components;

namespace PieApp.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
