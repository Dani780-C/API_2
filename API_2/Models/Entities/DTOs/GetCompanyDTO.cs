namespace API_2.Models.Entities.DTOs
{
    public class GetCompanyDTO
    {
        public string? CompanyName { get; set; }
        public string? OwnerLastName { get; set; }
        public string? OwnerFirstName { get; set; }
        public string? Type { get; set; }
        public GetCompanyProfileDTO? CompanyProfile { get; set; }
        public List<GetServiceForCompanyDTO>? Services { get; set; }

        public GetCompanyDTO(Company company)
        {
            this.CompanyName = company.CompanyName;
            this.OwnerFirstName = company.OwnerFirstName;
            this.OwnerLastName = company.OwnerLastName;
            this.Type = company.Type;
            if (company.CompanyProfile != null)
            {
                this.CompanyProfile = new GetCompanyProfileDTO(company.CompanyProfile);
            }
            else
            {
                this.CompanyProfile = null;
            }
            this.Services = new List<GetServiceForCompanyDTO>();
            
            foreach(var service in company.Services)
            {
                this.Services.Add(new GetServiceForCompanyDTO(service));
            }

        }

    }
}
