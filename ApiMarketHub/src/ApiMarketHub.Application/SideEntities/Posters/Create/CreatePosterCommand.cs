﻿using ApiMarketHub.Domain.SideEntities.Enum;
using Microsoft.AspNetCore.Http;
using Shared.Application;
using System;

namespace ApiMarketHub.Application.SideEntities.Posters.Create;
public class CreatePosterCommand : IBaseCommand
{
    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public PosterPosition Position { get; set; }
}