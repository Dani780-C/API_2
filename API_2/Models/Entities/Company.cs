namespace API_2.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? OwnerLastName { get; set; }
        public string? OwnerFirstName { get; set; }
        public string? Type { get; set; }
        public CompanyProfile? CompanyProfile { get; set; }
        public ICollection<Service>? Services { get; set; }

        
    }
}
