using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiMarketHub.Domain.OrderAggregate.Enum;
public enum OrderStatus 
{
    [Display(Name = "Pending")]
    Pending,

    [Display(Name = "Finally")]
    Finally,

    [Display(Name = "Shipping")]
    Shipping,

    [Display(Name = "Rejected")]
    Rejected
}