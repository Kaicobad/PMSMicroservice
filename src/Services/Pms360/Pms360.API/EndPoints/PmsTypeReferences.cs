using MediatR;

namespace Pms360.API.EndPoints;

public class PmsTypeReferences
{
    //public override void Map(WebApplication app)
    //{
    //    var group = app.MapGroup("api/v1/tnt/claim-place-reference").WithTags("ClaimPlaceReference"); ;
    //    //.RequireAuthorization()
    //    //group.MapGet(GetClaimPlaceReferences);
    //    //group.MapPost(CreateClaimPlaceReference);
    //    //group.MapPut(UpdateClaimPlaceReference, "{code}");
    //    //group.MapDelete(DeleteClaimPlaceReference, "{code}");
    //}
    //public async Task<PaginatedList<ClaimPlaceReferenceDto>> GetClaimPlaceReferences(ISender sender, [AsParameters] GetClaimPlaceReferencesQuery query)
    //{
    //    return await sender.Send(query);
    //}

    //public async Task<IResult> CreateClaimPlaceReference(ISender sender, CreateClaimPlaceReferenceCommand command)
    //{
    //    var result = await sender.Send(command);
    //    return Results.Ok(result);
    //}
    //public async Task<IResult> UpdateClaimPlaceReference(ISender sender, string code, UpdateClaimPlaceReferenceCommand command)
    //{
    //    if (code != command.Code)
    //        return Results.BadRequest();

    //    var result = await sender.Send(command);
    //    return Results.Ok(result);
    //}

    //public async Task<IResult> DeleteClaimPlaceReference(ISender sender, string code)
    //{
    //    var result = await sender.Send(new DeleteClaimPlaceReferenceCommand
    //    {
    //        Code = code
    //    });
    //    return Results.Ok(result);
    //}
}
