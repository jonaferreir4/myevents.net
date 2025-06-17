
using Domain.Enums;

namespace Application.UseCases.Sponsor.Update;
    public sealed record UpdateSponsorRequest(
         string Name,
        string LogoUrl,
        string Description,
        string WebsiteUrl,
        string LinkedInUrl,
        string InstagramUrl,
        long  EventId,
        SponsorShipLevel Level
    );                      