namespace CbMaker.Application.DTOs
{
    public class OptionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public OptionDTO() { }

        public OptionDTO(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
