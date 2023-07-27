namespace _Project_CheatSheet.Infrastructure.Data.Seed
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models.Enums;

    internal class DataSeeder
    {
        internal static ModelBuilder SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = ApplicationRolesEnum.Administrator.ToString(),
                    NormalizedName = ApplicationRolesEnum.Administrator.ToString().ToUpper(),
                    ConcurrencyStamp = "02174cf0–9412–4cfe-afbf-59f706d72cf0"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = ApplicationRolesEnum.Moderator.ToString(),
                    NormalizedName = ApplicationRolesEnum.Moderator.ToString().ToUpper(),
                    ConcurrencyStamp = "02174cf0–9412–4cfe-afbf-59f706d72cf1"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = ApplicationRolesEnum.User.ToString(),
                    NormalizedName = ApplicationRolesEnum.User.ToString().ToUpper(),
                    ConcurrencyStamp = "02174cf0–9412–4cfe-afbf-59f706d72cf2"
                }
            );


            return modelBuilder;
        }
    }
}