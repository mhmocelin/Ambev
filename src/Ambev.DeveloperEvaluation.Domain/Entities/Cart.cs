﻿using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Cart : BaseEntity
{
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public virtual ICollection<Product> Products { get; set; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(User.Id))]
    public virtual User User { get; set; }
}