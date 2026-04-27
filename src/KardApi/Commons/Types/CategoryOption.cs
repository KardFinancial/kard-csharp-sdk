using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(CategoryOption.CategoryOptionSerializer))]
[Serializable]
public readonly record struct CategoryOption : IStringEnum
{
    public static readonly CategoryOption ArtsEntertainment = new(Values.ArtsEntertainment);

    public static readonly CategoryOption BabyKidsToys = new(Values.BabyKidsToys);

    public static readonly CategoryOption BooksDigitalMedia = new(Values.BooksDigitalMedia);

    public static readonly CategoryOption ClothingShoesAccessories = new(
        Values.ClothingShoesAccessories
    );

    public static readonly CategoryOption ComputersElectronicsSoftware = new(
        Values.ComputersElectronicsSoftware
    );

    public static readonly CategoryOption Convenience = new(Values.Convenience);

    public static readonly CategoryOption Gas = new(Values.Gas);

    public static readonly CategoryOption DepartmentStores = new(Values.DepartmentStores);

    public static readonly CategoryOption FoodBeverage = new(Values.FoodBeverage);

    public static readonly CategoryOption HealthBeauty = new(Values.HealthBeauty);

    public static readonly CategoryOption HomeGarden = new(Values.HomeGarden);

    public static readonly CategoryOption Miscellaneous = new(Values.Miscellaneous);

    public static readonly CategoryOption OccasionsGifts = new(Values.OccasionsGifts);

    public static readonly CategoryOption Pets = new(Values.Pets);

    public static readonly CategoryOption SportsOutdoors = new(Values.SportsOutdoors);

    public static readonly CategoryOption SuppliesServices = new(Values.SuppliesServices);

    public static readonly CategoryOption Travel = new(Values.Travel);

    public CategoryOption(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static CategoryOption FromCustom(string value)
    {
        return new CategoryOption(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(CategoryOption value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CategoryOption value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CategoryOption value) => value.Value;

    public static explicit operator CategoryOption(string value) => new(value);

    internal class CategoryOptionSerializer : JsonConverter<CategoryOption>
    {
        public override CategoryOption Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new CategoryOption(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CategoryOption value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CategoryOption ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new CategoryOption(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CategoryOption value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ArtsEntertainment = "Arts & Entertainment";

        public const string BabyKidsToys = "Baby, Kids & Toys";

        public const string BooksDigitalMedia = "Books & Digital Media";

        public const string ClothingShoesAccessories = "Clothing, Shoes & Accessories";

        public const string ComputersElectronicsSoftware = "Computers, Electronics & Software";

        public const string Convenience = "Convenience";

        public const string Gas = "Gas";

        public const string DepartmentStores = "Department Stores";

        public const string FoodBeverage = "Food & Beverage";

        public const string HealthBeauty = "Health & Beauty";

        public const string HomeGarden = "Home & Garden";

        public const string Miscellaneous = "Miscellaneous";

        public const string OccasionsGifts = "Occasions & Gifts";

        public const string Pets = "Pets";

        public const string SportsOutdoors = "Sports & Outdoors";

        public const string SuppliesServices = "Supplies & Services";

        public const string Travel = "Travel";
    }
}
