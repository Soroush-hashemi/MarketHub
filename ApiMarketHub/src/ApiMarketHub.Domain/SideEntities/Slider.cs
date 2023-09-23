﻿using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.SideEntities;
public class Slider : BaseEntity
{
    public string Title { get; private set; }
    public string Link { get; private set; }
    public string ImageName { get; private set; }
    public bool IsActive { get; private set; }

    public Slider(string title, string link, string imageName, bool isActive)
    {
        Guard(title, link, imageName);
        Title = title;
        Link = link;
        ImageName = imageName;
        IsActive = isActive;
    }

    public void Edit(string title, string link, string imageName, bool isActive)
    {
        Guard(title, link, imageName);
        Title = title;
        Link = link;
        ImageName = imageName;
        IsActive = isActive;
    }

    public void Guard(string title, string link, string imageName)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
        NullOrEmptyException.CheckString(link, nameof(link));
        NullOrEmptyException.CheckString(imageName, nameof(imageName));
    }
}