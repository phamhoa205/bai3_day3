namespace bai3_day3.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; } // để dấu hỏi chấm hoặc  = string.Empty; để tránh lỗi null;
        public List<Product>? Products { get; set; } // để dấu hỏi chấm hoặc  = new List<Product>(); để tránh lỗi null;
    }
}
