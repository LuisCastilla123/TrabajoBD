namespace CVMaker.Application.DTOs 
{
    public record OptionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
    }
}