﻿using BasicBudgetR.Core.Enums;
using BasicBudgetR.Server.Domain.Entities.ReferenceEntities;

namespace BasicBudgetR.Server.Domain.Entities;
public class Account : BaseEntity
{
    [Key]
    [Column(Order = 0)]
    public long AccountId { get; set; }

    [Column(Order = 1)]
    [MinLength(5)]
    [MaxLength(125)]
    public string? Name { get; set; }

    [Column(Order = 2)]
    [Precision(19, 2)]
    public decimal Balance { get; set; }

    [Column(Order = 3)]
    public BalanceType BalanceType { get; set; }

    [Column(Order = 4)]
    public long AccountTypeId { get; set; }

    public AccountType? AccountType { get; set; }

    [Column(Order = 5)]
    public long UserDetailId { get; set; }
    public UserDetail? UserDetail { get; set; }
}
