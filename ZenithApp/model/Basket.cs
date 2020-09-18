using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ZenithApp.model
{
    public class Basket
    {
        public Basket()
        {

        }
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bad Gsm")]
        [MinLength(8, ErrorMessage = "The property {0} doesn't have more than {1} elements")]
        public string Gsm { get; set; } = "";

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bad Email")]
        [EmailAddress] public string Email { get; set; } = "";

        public bool Collected { get; set; }

        public bool Payed { get; set; }



        public DateTime DateTimeCreated { get;  } =DateTime.Now;



        public List<OrderLine> Lines { get; set; }= new List<OrderLine>();
      

        public void Add(OrderLine orderLine)
        {
            Lines.Add(orderLine);
        }

        public bool RemoveOrderline(OrderLine line)
        {
            return Lines.Remove(line);
        }

        public void RemoveOrderline(int lineId)
        {
            var pos = Lines.FindIndex(i => i.Id == lineId);
            Lines.RemoveAt(pos);
        }

        public List<OrderLine> AllLines()
        {
            return Lines;
        }


        public double Total()
        {
            return Lines.Sum(t => t.Total());
        }


        public double TotalVat()
        {
            return Lines.Sum(t => t.Product.VatTotal());
        }



        protected bool Equals(Basket other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Basket)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}