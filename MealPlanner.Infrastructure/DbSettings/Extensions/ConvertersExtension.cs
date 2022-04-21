using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JGL.Infra.Globals.DbSettings.Definitions
{
    public static class ConvertersExtension
    {
        public static ValueConverter EnumConverterToString<TEnum>() where TEnum : Enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new Exception(typeof(TEnum)?.ToString() + "is not an Enum");
            }

            return new ValueConverter<TEnum, string>((TEnum v) => v.ToString(), (string v) => (TEnum)Enum.Parse(typeof(TEnum), v));
        }
      
    }
}
