using BasicBudgetR.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBudgetR.Server.Infrastructure.Data.Configurations;
public class ExpenseDetailConfiguration : IEntityTypeConfiguration<ExpenseDetail>
{
    public void Configure(EntityTypeBuilder<ExpenseDetail> builder)
    {
        builder.ToTable("ExpenseDetails",
            a => a.IsTemporal(a =>
            {
                a.UseHistoryTable("ExpenseDetailHistory");
                a.HasPeriodStart(DomainConstants.CreatedAt);
                a.HasPeriodEnd(DomainConstants.ModifiedAt);
            }));
    }
}
