
using Application.UseCases.Sponsor.Register;
using Application.UseCases.Sponsor.Update;
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

    public static Sponsor ToEntity(this UpdateSponsorRequest request)
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

     public static UpdateSponsorResponse ToUpdateResponse(this Sponsor sponsor)
    {

        return new UpdateSponsorResponse(
            sponsor.Id,
            sponsor.Name,
            sponsor.Description
        );
    }
    

    }
