#nullable enable
using System.ComponentModel.DataAnnotations;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;

namespace ZenithApp.model
{
    public class Product
    {

        public int Id { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 10,
            ErrorMessage = "The Name {0} should have {1} maximum characters and {2} minimum characters")]
        public string Name { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 5,
            ErrorMessage = "The Description {0} should have {1} maximum characters and {2} minimum characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]

        public string PriceString
        {
            get => Price.ToString(CultureInfo.InvariantCulture);


            set => Price = Convert.ToDouble(string.IsNullOrEmpty(value) ? "0.0" : value);
        }


        public string VatString
        {
            get => VatPercentage.ToString(CultureInfo.InvariantCulture);


            set => VatPercentage = Convert.ToDouble(string.IsNullOrEmpty(value) ? "0.0" : value);
        }
        [Range(0, 100, ErrorMessage = "The Price should be between 0 and 10")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        [Range(0, 100, ErrorMessage = "The Price should be between 0 and 10")]
        public double VatPercentage { get; set; }
        public byte[]? Image { get; set; }
        [Required(ErrorMessage = "TypeProduct is required")]
        public TypeProduct? TypeProduct { get; set; }

        public double TotalPrice => Total();

        public Product()
        {
        }

        public Product(int id, string name, string description, double price, string code, double vatPercentage, byte[] image, TypeProduct typeProduct)
        {
            if (price <= 0) throw new ArgumentException("Bad price");
            if (vatPercentage < 0) throw new ArgumentException("Bad vat");
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Code = code;
            VatPercentage = vatPercentage;
            Image = image;
            TypeProduct = typeProduct;
        }

        public Bitmap? ImageProduct()
        {
            if (Image == null) return default;
            using MemoryStream mStream = new MemoryStream(Image);
            return new Bitmap(mStream);

        }

        public double Total()
        {
            return Price + Price * VatPercentage / 100;
        }


        private bool Equals(Product other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(Price)}: {Price}, {nameof(Code)}: {Code}, {nameof(VatPercentage)}: {VatPercentage}, {nameof(Image)}: {Image}, {nameof(TypeProduct)}: {TypeProduct}";
        }

        public double VatTotal()
        {
            return Price * VatPercentage / 100;
        }
    }

}