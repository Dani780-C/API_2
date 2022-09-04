namespace API_2.Models.Entities.DTOs
{
    public class GetCompanyProfileDTO
    {
        public string? Description { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? StartDate { get; set; }
        public int? NumberOfEmployees { get; set; }
        public string? CallCenterPhoneNumber { get; set; }
        public GetCompanyProfileDTO(CompanyProfile companyProfile)
        {
            this.Description = companyProfile.Description;
            this.Street = companyProfile.Street;
            this.City = companyProfile.City;
            this.Country = companyProfile.Country;
            this.StartDate = companyProfile.StartDate;
            this.NumberOfEmployees = companyProfile.NumberOfEmployees;
            this.CallCenterPhoneNumber = companyProfile.CallCenterPhoneNumber;
        }
    }
}
