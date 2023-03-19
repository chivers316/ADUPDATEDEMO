namespace ADASSESSMENT.Models
{
    public class JobCategory
    {
        public int Id { get; set; }
        public string[] CategoryType = { "Breakdown, None, VOR, Warranty" };
        public string CategorySelected { get; set; } = string.Empty;

        public int? EngineerId { get; set; } = 0;
    }
}
