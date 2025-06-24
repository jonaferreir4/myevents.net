
using Domain.Entities;
using Library.Http.Requests.Sponsor;
using Library.Http.Responses.Sponsor;

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

    public static Sponsor ToEntity(this UpdateSponsorRequest request, Sponsor existingSponsor)
    {
        existingSponsor.Name = request.Name;
        existingSponsor.LogoUrl = request.LogoUrl;
        existingSponsor.EventId = request.EventId;
        existingSponsor.Level = request.Level;
        existingSponsor.Description = request.Description;
        existingSponsor.WebsiteUrl = request.WebsiteUrl;
        existingSponsor.LinkedInUrl = request.LinkedInUrl;
        existingSponsor.InstagramUrl = request.InstagramUrl;

        return existingSponsor;
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
