
using Domain.Enums;

namespace Application.UseCases.Sponsor.Register;
    public sealed record RegisterSponsorRequest(
        string Name,
        string LogoUrl,
        string Description,
        string WebsiteUrl,
        string LinkedInUrl,
        string InstagramUrl,
        long  EventId,
        SponsorShipLevel Level  = SponsorShipLevel.Bronze
    );                      