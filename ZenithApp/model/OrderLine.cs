using System;
using System.ComponentModel.DataAnnotations;

namespace ZenithApp.model
{
    public class OrderLine
    {
        public int Id { get; }
        [Required]
        public Product Product { get; set; }

        [Required]
        public int Count { get; set; }
        public int BasketId { get;  set; }

        public double Total()
        {
            return Product.Total() * Count;
        }
        public OrderLine()
        {

        }
        public OrderLine(Product product, int count)
        {
          
            Product = product;
            Count = count;
        }

        protected bool Equals(OrderLine other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((OrderLine)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Product)}: {Product}, {nameof(Count)}: {Count}";
        }
    }
}