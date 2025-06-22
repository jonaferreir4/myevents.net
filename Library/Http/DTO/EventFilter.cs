namespace Library.Http.DTO;
    public class EventFilter
    {
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Location { get; set; }
        public long? OrganizerId { get; set; } 
    }