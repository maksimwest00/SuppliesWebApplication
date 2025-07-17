namespace SuppliesWebApplication.Domain.Entities
{
    public class Offer
    {
        // ef core
        private Offer()
        {

        }

        public int Id { get; private set; }

        public string? Stamp { get; private set; }

        public string? Model { get; private set; }

        public Supplier Provider { get; private set; } = default!;

        public DateTime DateRegistration { get; private set; }

        public Offer(
            string? stamp,
            string? model,
            DateTime dateRegistration)
        {
            
        }

        public static Offer Create(
            string? stamp,
            string? model,
            DateTime dateRegistration)
        {
            return new Offer(stamp, model, dateRegistration);
        }
    }
}
