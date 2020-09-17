using System.ComponentModel.DataAnnotations;

namespace ZenithApp.model
{
    public class TypeProduct
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 10,
            ErrorMessage = "The Name {0} should have {1} maximum characters and {2} minimum characters")]
        public string Name { get; set; }


        public TypeProduct(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public TypeProduct()
        {
        }

        protected bool Equals(TypeProduct other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TypeProduct)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}