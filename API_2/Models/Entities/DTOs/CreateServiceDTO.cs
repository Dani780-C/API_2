namespace API_2.Models.Entities.DTOs
{
    public class CreateServiceDTO
    {
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? Guarantee { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
