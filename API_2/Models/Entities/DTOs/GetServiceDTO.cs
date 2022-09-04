namespace API_2.Models.Entities.DTOs
{
    public class GetServiceDTO
    {
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? Guarantee { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public GetCompanyDataDTO? Company { get; set; }
        public GetServiceDTO(Service service)
        {
            this.ServiceName = service.ServiceName;
            this.Description = service.Description;
            this.Price = service.Price;
            this.Guarantee = service.Guarantee;
            this.Email = service.Email;
            this.PhoneNumber = service.PhoneNumber;
            this.Company = new GetCompanyDataDTO(service.Company);
        }
    }
}
