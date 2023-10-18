using ApiMarketHub.Query.SideEntities.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.SideEntities.Poster.GetById;
public record GetPosterByIdQuery(long Id) : IQuery<PosterDto?>;