
using Application.UseCases.Sponsor.Register;
using Domain.Entities;

namespace Application.Mappings;

public static class SponsorMapping
{
    public static Sponsor ToEntity(this RegisterSponsorRequest request)
    {
        return new Sponsor(
            name: request.Name,
            logoUrl: request.LogoUrl,
            eventId: request.EventId,
            level: request.Level,
            description: request.Description,
            websiteUrl: request.WebsiteUrl,
            linkedInUrl: request.LinkedInUrl,
            instagramUrl: request.InstagramUrl
            );
    }

    public static RegisterSponsorResponse ToResponse(this Sponsor sponsor)
    {

        return new RegisterSponsorResponse(
            sponsor.Id,
            sponsor.Name,
            sponsor.Description
        );
    }
    }
