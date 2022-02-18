﻿namespace MealPlanner.Infrastructure.DbSettings.Interfaces
{
    public interface IEntityModelBuilder
    {
        void BuildEntity(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder);

        void CreateGlobalParameters(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder);
    }
}
