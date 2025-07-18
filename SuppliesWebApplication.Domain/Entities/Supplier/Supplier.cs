namespace SuppliesWebApplication.Domain.Entities
{
    public class Supplier
    {
        // ef core
        private Supplier()
        {
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime DateCreate { get; set; }

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
