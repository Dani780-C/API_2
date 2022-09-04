namespace API_2.Models.Entities.DTOs
{
    public class CreateCompanyDTO
    {
        public string? CompanyName { get; set; }
        public string? OwnerLastName { get; set; }
        public string? OwnerFirstName { get; set; }
        public string? Type { get; set; }

    }
}
