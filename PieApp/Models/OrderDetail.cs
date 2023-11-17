using System.ComponentModel.DataAnnotations.Schema;

namespace PieApp.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public Pie Pie { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
