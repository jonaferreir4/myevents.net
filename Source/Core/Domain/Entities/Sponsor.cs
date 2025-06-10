
namespace Domain.Entities;
    public  sealed class Sponsor: BaseEntity
    {
  
      public string Name { get; private set; }
      public string LogoUrl { get; private set; }
      public string Description { get; private set; }
      public string Social { get; private set; }


      public int EventId { get; private set; }
      public Event Event { get; private set; }

    }