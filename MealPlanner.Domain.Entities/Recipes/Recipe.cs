﻿using JGL.Infra.Domain.Entities;

namespace MealPlanner.Domain.Entities.Recipes
{
    public class Recipe : DescriptiveEntity
    {
        public string? SourceCode { get; set; }
    }
}