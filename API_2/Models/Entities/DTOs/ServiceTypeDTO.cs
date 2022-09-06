namespace API_2.Models.Entities.DTOs
{
    public class ServiceTypeDTO
    {
        public string? ServiceName { get; set; }
        public string? Type { get; set; }
        public ServiceTypeDTO()
        {
        }

        public ServiceTypeDTO(string? name, string? type)
        {
            this.ServiceName = name;
            this.Type = type;
        }
    }
}
