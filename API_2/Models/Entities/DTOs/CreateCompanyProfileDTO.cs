namespace API_2.Models.Entities.DTOs
{
    public class CreateCompanyProfileDTO
    {
        public string? Description { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? StartDate { get; set; }
        public int? NumberOfEmployees { get; set; }
        public string? CallCenterPhoneNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
