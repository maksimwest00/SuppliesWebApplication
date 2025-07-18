using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SuppliesWebApplication.Domain.Entities
{
    public class Offer
    {
        // ef core
        private Offer()
        {

        }

        public int Id { get; set; }

        public string? Stamp { get; set; }

        public string? Model { get; set; }

        [JsonIgnore]
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public DateTime DateRegistration { get; set; }

        public Offer(
            string? stamp,
            string? model,
            DateTime dateRegistration,
            Supplier? supplier = null)
        {
            Stamp = stamp;
            Model = model;
            Supplier = supplier;
            DateRegistration = dateRegistration;
        }

        public static Offer Create(
            string? stamp,
            string? model,
            Supplier? supplier)
        {
            return new Offer(stamp,
                             model,
                             DateTime.Now,
                             supplier);
        }
    }
}
