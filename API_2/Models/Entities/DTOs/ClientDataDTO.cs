namespace API_2.Models.Entities.DTOs
{
    public class ClientDataDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ClientDataDTO(Client client)
        {
            this.FirstName = client.FirstName;
            this.LastName = client.LastName;
            this.Email = client.Email;
            this.PhoneNumber = client.PhoneNumber;
        }
    }
}
