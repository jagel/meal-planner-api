using MealPlanner.Domain.Entities.Auth;
using MealPlanner.Infrastructure.DbSettings.Definitions;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Infrastructure.DbSettings.Extensions;

namespace MealPlanner.Infrastructure.DataProvider.ModelBuilder
{
    public static class AuthModelBuilder
    {
        public static void BuilAuthdEntities(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            OrganizationModelBuilder(modelBuilder);
            UserModelBuilder(modelBuilder);
            OrganizatioUSernModelBuilder(modelBuilder);
        }

        private static void OrganizationModelBuilder(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            string text = "PrimaryKey_OrganizationId";
            string TableNameId = "OrganizationId";

            modelBuilder.Entity<Organization>(organization =>
            {
                organization.Property(x => x.Id)
                    .HasColumnName(TableNameId)
                    .HasComment("Organization PK: OrganizationId");

                organization.HasKey(x => x.Id)
                    .HasName(TableNameId);

                organization.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_NAME);

                organization.Property(x => x.OrganizationCode)
                    .IsRequired()
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_SHORTNAME);


                organization.Property(x => x.UserOwnerId)
                    .IsRequired();

            });


        }

        private static void UserModelBuilder(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            string text = "PrimaryKey_UerId";
            string TableNameId = "UserId";

            modelBuilder.Entity<User>(user =>
            {
                user.Property(x => x.Id)
                    .HasColumnName(TableNameId)
                    .HasComment("User PK: UserId");

                user.HasKey(x => x.Id)
                    .HasName(TableNameId);

                user.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_NAME);

                user.Property(x => x.Username)
                     .IsRequired()
                     .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_SHORTNAME);

                user.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_NAME);

                user.Property(x => x.Lastname)
                    .IsRequired()
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_NAME);

                user.Property(x => x.Lastname)
                    .IsRequired()
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_NAME);


                user.Property(x => x.PasswordHash)
                    .IsRequired()
                    .IsConcurrencyToken();

                user.Property(x => x.PasswordSalt)
                    .IsRequired()
                    .IsConcurrencyToken();

                user.HasMany(o => o.OrganizationUsers)
                  .WithOne(ou => ou.User)
                  .HasForeignKey(ou => ou.UserId);
            });


        }

        private static void OrganizatioUSernModelBuilder(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            string text = "PrimaryKey_OrganizationUserId";
            string TableNameId = "OrganizationUserId";

            modelBuilder.Entity<OrganizationUser>(organizationUser =>
            {
                organizationUser.Property(ou => ou.Id)
                    .HasColumnName(TableNameId)
                    .HasComment("OrganizationUser PK: OrganizationUserId");

                organizationUser.HasKey(ou => ou.Id)
                    .HasName(TableNameId);

                organizationUser.Property(ou => ou.UserStatus)
                    .HasConversion(ConvertersExtension.EnumConverterToString<EUserStatus>());

                organizationUser.HasOne( ou => ou.Organization)
                    .WithMany(o => o.OrganizationUsers)
                    .HasForeignKey(o => o.OrganizationId);

                organizationUser.HasOne(ou => ou.User)
                    .WithMany(o => o.OrganizationUsers)
                    .HasForeignKey(o => o.UserId);
            });


        }

    }
}
