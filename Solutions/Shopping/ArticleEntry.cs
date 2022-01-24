namespace Shopping
{
    public class ArticleEntry
    {
        public int ArticleId { get; set; }

        public int Count { get; set; } = 1;
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => Count * UnitPrice;

        public string Name { get; set; }
    }
}