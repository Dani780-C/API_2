namespace API_2.Models.Entities.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<GetServiceDataDTO>? Services { get; set; }

        public ClientDTO(Client client)
        {
            this.Id = client.Id;
            this.FirstName = client.FirstName;
            this.LastName = client.LastName;
            this.Email = client.Email;
            this.PhoneNumber = client.PhoneNumber;
            this.Services = new List<GetServiceDataDTO>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var clientservice in client.ClientServices)
            {
                this.Services.Add(new GetServiceDataDTO(clientservice));
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
