namespace ADASSESSMENT.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? FirstLine { get; set; } = string.Empty;
        public string? SecondLine { get; set; } = string.Empty;
        public string? ThirdLine { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty; 
        public string? PostCode { get; set; } = string.Empty;

        public int? EngineerId { get; set; } = 0;
    }
}
