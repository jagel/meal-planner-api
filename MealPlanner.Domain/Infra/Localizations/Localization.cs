﻿namespace MealPlanner.Domain.Infra.Localizations
{
    public class Localization : ILocalization
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
