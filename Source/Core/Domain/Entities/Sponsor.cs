
using Domain.Enums;

namespace Domain.Entities;

public sealed class Sponsor : BaseEntity
{

  public string Name { get; set; }
  public string LogoUrl { get; set; }
  public string Description { get; set; }
  public string WebsiteUrl { get; set; }
  public string LinkedInUrl { get; set; }
  public string InstagramUrl { get; set; }
  public bool IsActive { get; set; }
  public SponsorShipLevel Level { get; set; }

  public long EventId { get; set; }
  public Event Event { get; set; }



  public Sponsor(
     string name,
        string logoUrl,
        long eventId,
        SponsorShipLevel level,
        string description = null,
        string websiteUrl = null,
        string linkedInUrl = null,
        string instagramUrl = null,
         bool isActive = true
    )
  {

    Name = name;
    LogoUrl = logoUrl;
    EventId = eventId;
    Level = level;
    Description = description;
    WebsiteUrl = websiteUrl;
    LinkedInUrl = linkedInUrl;
    InstagramUrl = instagramUrl;
    IsActive = isActive;
  }

  public Sponsor() { }
  

  public void ToggleActiveStatus()
    {
        IsActive = !IsActive;
    }

    }