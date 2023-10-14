﻿using Shared.Query.Bases;

namespace ApiMarketHub.Query.Products.DTOs;
public class ProductFilterData : BaseDto
{
    public string Title { get; set; }
    public string ImageName { get; set; }
    public string Slug { get; set; }
}