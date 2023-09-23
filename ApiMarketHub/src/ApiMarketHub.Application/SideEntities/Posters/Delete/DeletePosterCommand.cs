using Shared.Application;
using System;

namespace ApiMarketHub.Application.SideEntities.Posters.Delete;
public class DeletePosterCommand : IBaseCommand
{
    public long Poster { get; set; }
}