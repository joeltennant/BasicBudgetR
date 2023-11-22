using BudgetR.Core.Enums;
using BudgetR.Server.Domain.Entities;
using BudgetR.Server.Infrastructure.Data.BudgetR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Tools.SeedSampleData;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            using StreamReader reader = new("UserSettings.json");
            var json = reader.ReadToEnd();
            UserSettingDto? userSetting = JsonConvert.DeserializeObject<UserSettingDto>(json);


            var dbOptions = new DbContextOptionsBuilder<BudgetRDbContext>();
            dbOptions.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BasicBudgetR;Trusted_Connection=True;MultipleActiveResultSets=true");

            using var dbContext = new BudgetRDbContext(dbOptions.Options);

            User user = new()
            {
                AuthId = userSetting.AuthId,
                DisplayName = userSetting.DisplayName,
                Household = new Household
                {
                    Name = userSetting.HouseholdName
                }
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            foreach (var account in userSetting.Accounts)
            {
                BalanceType balanceType = account.BalanceType == 1
                                        ? BalanceType.Debit
                                        : BalanceType.Credit;

                dbContext.Accounts.Add(new Account
                {

                    Name = account.AccountName,
                    AccountTypeId = account.AccountType,
                    Balance = account.Balance,
                    BalanceType = balanceType,
                    HouseholdId = user.HouseholdId.Value
                });
            }

            dbContext.SaveChanges();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

        Console.WriteLine("Seeding is complete. You may close this console.");
    }
}
