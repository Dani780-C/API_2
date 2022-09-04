namespace API_2.Models.Entities
{
    public class ClientService
    {
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
