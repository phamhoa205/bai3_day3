namespace bai3_day3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; } // để dấu hỏi chấm hoặc  = string.Empty; để tránh lỗi null;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null;
    }
}
