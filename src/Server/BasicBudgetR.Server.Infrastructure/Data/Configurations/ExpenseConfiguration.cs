using BasicBudgetR.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBudgetR.Server.Infrastructure.Data.Configurations;
public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expenses",
        a => a.IsTemporal(a =>
        {
            a.UseHistoryTable("ExpenseHistory");
            a.HasPeriodStart(DomainConstants.CreatedAt);
            a.HasPeriodEnd(DomainConstants.ModifiedAt);
        }));
    }
}
