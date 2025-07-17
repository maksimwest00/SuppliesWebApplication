namespace SuppliesWebApplication.Domain.Entities
{
    public class Supplier
    {
        // ef core
        private Supplier()
        {
        }

        public int Id { get; private set; }

        public string? Name { get; private set; }

        public DateTime DateCreate { get; private set; }

        public Supplier(string? name,
                        DateTime dateCreate)
        {
            Name = name;
            DateCreate = dateCreate;
        }

        public static Supplier Create(
                        string? name,
                        DateTime dateCreate)
        {
            return new Supplier(name, dateCreate);
        }
    }
}
