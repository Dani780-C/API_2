﻿namespace API_2.Models.Entities.DTOs
{
    public class GetServiceDataDTO
    {
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? Guarantee { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CompanyId { get; set; }
    
        public GetServiceDataDTO(ClientService service)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            this.ServiceName = service.Service.ServiceName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            this.Description = service.Service.Description;
            this.Price = service.Service.Price;
            this.Guarantee = service.Service.Guarantee;
            this.Email = service.Service.Email;
            this.PhoneNumber = service.Service.PhoneNumber;
            this.CompanyId = service.Service.CompanyId;
        }
    }
}
