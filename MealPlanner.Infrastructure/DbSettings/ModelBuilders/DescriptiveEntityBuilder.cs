using JGL.Infra.Domain.Entities;
using MealPlanner.Infrastructure.DbSettings.Definitions;
using MealPlanner.Infrastructure.DbSettings.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealPlanner.Infrastructure.DbSettings.ModelBuilders
{
    public abstract class DescriptiveEntityBuilder<TEntity> : IEntityModelBuilder where TEntity : DescriptiveEntity, new()
    {
        public abstract void BuildEntity(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder);

        public virtual void CreateGlobalParameters(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            string TableName = typeof(TEntity).Name;
            string text = "PrimaryKey_" + TableName + "Id";
            string TableNameId = TableName + "Id";
            modelBuilder.Entity(delegate (EntityTypeBuilder<TEntity> entity)
            {
                entity.Property((TEntity x) => x.Id).HasColumnName(TableNameId).HasComment(TableName + " PK: " + TableNameId);
                entity.HasKey((TEntity x) => x.Id).HasName(TableNameId);
                
                entity.Property((TEntity x) => x.Name)
                    .IsRequired()
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_NAME);
                
                entity.Property((TEntity x) => x.Description)
                    .IsRequired(required: false)
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_DESCRIPTION);

                //entity.Property((TEntity x) => x.Status).HasDefaultValue(InternalStatus.EDB_ItemStatus.Active).HasConversion(Converters.EnumConverter<InternalStatus.EDB_ItemStatus>())
                //    .IsRequired()
                //    .HasMaxLength(20)
                //    .HasComment("Database status");

                entity.Property((TEntity x) => x.CreatedDate)
                    .HasColumnType(DatabaseProperties.MySQL.TYPE_DATETIME)
                    .IsRequired();
                    //.HasDefaultValueSql("GETUTCDATE()");

                entity.Property((TEntity x) => x.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_GUID);

                entity.Property((TEntity x) => x.UpdatedDate).HasColumnType(DatabaseProperties.MySQL.TYPE_DATETIME)
                    .IsRequired(required: false);

                entity.Property((TEntity x) => x.UpdatedBy)
                    .IsRequired(required: false)
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_GUID);
            });
        }
    }
}
