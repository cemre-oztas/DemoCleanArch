﻿using CleanArch.Domain.Entities.Common;
using CleanArch.Domain.Entities.Identity;


namespace CleanArch.Domain.Entities;

public class Basket : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public Order Order { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
}
