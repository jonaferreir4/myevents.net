
using Library.Enums;

namespace Library.Http.Requests.Sponsor;
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