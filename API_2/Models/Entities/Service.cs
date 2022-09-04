namespace API_2.Models.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? Guarantee { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public ICollection<ClientService>? ClientServices { get; set; }
    }
}
