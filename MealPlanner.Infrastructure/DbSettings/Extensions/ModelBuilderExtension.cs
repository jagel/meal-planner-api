using MealPlanner.Infrastructure.DbSettings.Interfaces;
using System.Reflection;

namespace MealPlanner.Infrastructure.DbSettings.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void BuildEntities(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            Type typeFromHandle = typeof(IEntityModelBuilder);
            List<Type> list = (from p in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly s) => s.GetTypes())
                               where typeof(IEntityModelBuilder).IsAssignableFrom(p) && p.IsClass && !p.IsAbstract
                               select p).ToList();
            list.ForEach(delegate (Type entityBuilder)
            {
                IEntityModelBuilder? entityModelBuilder = Activator.CreateInstance(type: entityBuilder) as IEntityModelBuilder;
                if(entityBuilder != null)
                {
                    entityModelBuilder?.CreateGlobalParameters(modelBuilder);
                    entityModelBuilder?.BuildEntity(modelBuilder);
                }
            });
        }
    }
}
