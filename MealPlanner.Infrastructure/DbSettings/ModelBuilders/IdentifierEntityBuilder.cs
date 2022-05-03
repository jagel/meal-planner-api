using JGL.Infra.Globals.DbSettings.Interfaces;
using JGL.Infra.Globals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JGL.Infra.Globals.DbSettings.ModelBuilders
{
    public abstract class IdentifierEntityBuilder<TEntity> : IEntityModelBuilder where TEntity : IdentifierEntity, new()
    {
        public abstract void BuildEntity(ModelBuilder modelBuilder);

        public virtual void CreateGlobalParameters(ModelBuilder modelBuilder)
        {
            string TableName = typeof(TEntity).Name;
            string text = "PrimaryKey_" + TableName + "Id";
            string TableNameId = TableName + "Id";

            modelBuilder.Entity(delegate (EntityTypeBuilder<TEntity> entity)
            {
                entity.Property((TEntity x) => x.Id)
                    .HasColumnName(TableNameId)
                    .HasComment(TableName + " PK: " + TableNameId);

                entity.HasKey((TEntity x) => x.Id)
                    .HasName(TableNameId);
            });
        }
    }
}
