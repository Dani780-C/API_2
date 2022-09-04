namespace API_2.Models.Entities.DTOs
{
    public class GetCompanyDataDTO
    {
        public string? CompanyName { get; set; }
        public string? OwnerLastName { get; set; }
        public string? OwnerFirstName { get; set; }
        public string? Type { get; set; }
        
        public GetCompanyDataDTO(Company company)
        {
            this.CompanyName = company.CompanyName;
            this.OwnerFirstName = company.OwnerFirstName;
            this.OwnerLastName = company.OwnerLastName;
            this.Type = company.Type;
        }
    
    }
}
