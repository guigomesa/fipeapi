namespace Fipe.Domain
{
    public class Brand
    {
        public Brand(string name, int id)
        {
            Name = name;
            Id = id;
        }

        protected internal Brand() { }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
