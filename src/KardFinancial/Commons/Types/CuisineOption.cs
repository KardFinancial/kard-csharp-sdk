using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(CuisineOption.CuisineOptionSerializer))]
[Serializable]
public readonly record struct CuisineOption : IStringEnum
{
    public static readonly CuisineOption American = new(Values.American);

    public static readonly CuisineOption Southern = new(Values.Southern);

    public static readonly CuisineOption CajunCreole = new(Values.CajunCreole);

    public static readonly CuisineOption Southwestern = new(Values.Southwestern);

    public static readonly CuisineOption Bbq = new(Values.Bbq);

    public static readonly CuisineOption Steakhouse = new(Values.Steakhouse);

    public static readonly CuisineOption Burgers = new(Values.Burgers);

    public static readonly CuisineOption HotDogs = new(Values.HotDogs);

    public static readonly CuisineOption Wings = new(Values.Wings);

    public static readonly CuisineOption FriedChicken = new(Values.FriedChicken);

    public static readonly CuisineOption Sandwiches = new(Values.Sandwiches);

    public static readonly CuisineOption Deli = new(Values.Deli);

    public static readonly CuisineOption Diner = new(Values.Diner);

    public static readonly CuisineOption Hawaiian = new(Values.Hawaiian);

    public static readonly CuisineOption Canadian = new(Values.Canadian);

    public static readonly CuisineOption Mexican = new(Values.Mexican);

    public static readonly CuisineOption Tacos = new(Values.Tacos);

    public static readonly CuisineOption Burritos = new(Values.Burritos);

    public static readonly CuisineOption LatinAmerican = new(Values.LatinAmerican);

    public static readonly CuisineOption Caribbean = new(Values.Caribbean);

    public static readonly CuisineOption Jamaican = new(Values.Jamaican);

    public static readonly CuisineOption Cuban = new(Values.Cuban);

    public static readonly CuisineOption PuertoRican = new(Values.PuertoRican);

    public static readonly CuisineOption Brazilian = new(Values.Brazilian);

    public static readonly CuisineOption Argentine = new(Values.Argentine);

    public static readonly CuisineOption Peruvian = new(Values.Peruvian);

    public static readonly CuisineOption Colombian = new(Values.Colombian);

    public static readonly CuisineOption Venezuelan = new(Values.Venezuelan);

    public static readonly CuisineOption Salvadoran = new(Values.Salvadoran);

    public static readonly CuisineOption Honduran = new(Values.Honduran);

    public static readonly CuisineOption Italian = new(Values.Italian);

    public static readonly CuisineOption Pizza = new(Values.Pizza);

    public static readonly CuisineOption Pasta = new(Values.Pasta);

    public static readonly CuisineOption French = new(Values.French);

    public static readonly CuisineOption Creperie = new(Values.Creperie);

    public static readonly CuisineOption Spanish = new(Values.Spanish);

    public static readonly CuisineOption Tapas = new(Values.Tapas);

    public static readonly CuisineOption Portuguese = new(Values.Portuguese);

    public static readonly CuisineOption German = new(Values.German);

    public static readonly CuisineOption Austrian = new(Values.Austrian);

    public static readonly CuisineOption Swiss = new(Values.Swiss);

    public static readonly CuisineOption Fondue = new(Values.Fondue);

    public static readonly CuisineOption British = new(Values.British);

    public static readonly CuisineOption FishAndChips = new(Values.FishAndChips);

    public static readonly CuisineOption Irish = new(Values.Irish);

    public static readonly CuisineOption Belgian = new(Values.Belgian);

    public static readonly CuisineOption Dutch = new(Values.Dutch);

    public static readonly CuisineOption Scandinavian = new(Values.Scandinavian);

    public static readonly CuisineOption EasternEuropean = new(Values.EasternEuropean);

    public static readonly CuisineOption Polish = new(Values.Polish);

    public static readonly CuisineOption Russian = new(Values.Russian);

    public static readonly CuisineOption European = new(Values.European);

    public static readonly CuisineOption Mediterranean = new(Values.Mediterranean);

    public static readonly CuisineOption Greek = new(Values.Greek);

    public static readonly CuisineOption MiddleEastern = new(Values.MiddleEastern);

    public static readonly CuisineOption Lebanese = new(Values.Lebanese);

    public static readonly CuisineOption Israeli = new(Values.Israeli);

    public static readonly CuisineOption Jewish = new(Values.Jewish);

    public static readonly CuisineOption Turkish = new(Values.Turkish);

    public static readonly CuisineOption Persian = new(Values.Persian);

    public static readonly CuisineOption Egyptian = new(Values.Egyptian);

    public static readonly CuisineOption Moroccan = new(Values.Moroccan);

    public static readonly CuisineOption Armenian = new(Values.Armenian);

    public static readonly CuisineOption Georgian = new(Values.Georgian);

    public static readonly CuisineOption Falafel = new(Values.Falafel);

    public static readonly CuisineOption Kebab = new(Values.Kebab);

    public static readonly CuisineOption African = new(Values.African);

    public static readonly CuisineOption Ethiopian = new(Values.Ethiopian);

    public static readonly CuisineOption Indian = new(Values.Indian);

    public static readonly CuisineOption Pakistani = new(Values.Pakistani);

    public static readonly CuisineOption Bangladeshi = new(Values.Bangladeshi);

    public static readonly CuisineOption SriLankan = new(Values.SriLankan);

    public static readonly CuisineOption Nepalese = new(Values.Nepalese);

    public static readonly CuisineOption Afghan = new(Values.Afghan);

    public static readonly CuisineOption Asian = new(Values.Asian);

    public static readonly CuisineOption Chinese = new(Values.Chinese);

    public static readonly CuisineOption Taiwanese = new(Values.Taiwanese);

    public static readonly CuisineOption HongKong = new(Values.HongKong);

    public static readonly CuisineOption DimSum = new(Values.DimSum);

    public static readonly CuisineOption HotPot = new(Values.HotPot);

    public static readonly CuisineOption Dumplings = new(Values.Dumplings);

    public static readonly CuisineOption Noodles = new(Values.Noodles);

    public static readonly CuisineOption Japanese = new(Values.Japanese);

    public static readonly CuisineOption Sushi = new(Values.Sushi);

    public static readonly CuisineOption Ramen = new(Values.Ramen);

    public static readonly CuisineOption Yakitori = new(Values.Yakitori);

    public static readonly CuisineOption Korean = new(Values.Korean);

    public static readonly CuisineOption Mongolian = new(Values.Mongolian);

    public static readonly CuisineOption Thai = new(Values.Thai);

    public static readonly CuisineOption Vietnamese = new(Values.Vietnamese);

    public static readonly CuisineOption Filipino = new(Values.Filipino);

    public static readonly CuisineOption Malaysian = new(Values.Malaysian);

    public static readonly CuisineOption Indonesian = new(Values.Indonesian);

    public static readonly CuisineOption Singaporean = new(Values.Singaporean);

    public static readonly CuisineOption Burmese = new(Values.Burmese);

    public static readonly CuisineOption Cambodian = new(Values.Cambodian);

    public static readonly CuisineOption Australian = new(Values.Australian);

    public static readonly CuisineOption Seafood = new(Values.Seafood);

    public static readonly CuisineOption Poke = new(Values.Poke);

    public static readonly CuisineOption Salads = new(Values.Salads);

    public static readonly CuisineOption Soups = new(Values.Soups);

    public static readonly CuisineOption Breakfast = new(Values.Breakfast);

    public static readonly CuisineOption Brunch = new(Values.Brunch);

    public static readonly CuisineOption Bagels = new(Values.Bagels);

    public static readonly CuisineOption Buffet = new(Values.Buffet);

    public static readonly CuisineOption FastFood = new(Values.FastFood);

    public static readonly CuisineOption FoodTruck = new(Values.FoodTruck);

    public static readonly CuisineOption Gastropub = new(Values.Gastropub);

    public static readonly CuisineOption Bakery = new(Values.Bakery);

    public static readonly CuisineOption Cafe = new(Values.Cafe);

    public static readonly CuisineOption BubbleTea = new(Values.BubbleTea);

    public static readonly CuisineOption JuiceBar = new(Values.JuiceBar);

    public static readonly CuisineOption Dessert = new(Values.Dessert);

    public static readonly CuisineOption IceCream = new(Values.IceCream);

    public static readonly CuisineOption Doughnuts = new(Values.Doughnuts);

    public static readonly CuisineOption Bar = new(Values.Bar);

    public static readonly CuisineOption SportsBar = new(Values.SportsBar);

    public static readonly CuisineOption WineBar = new(Values.WineBar);

    public static readonly CuisineOption Winery = new(Values.Winery);

    public static readonly CuisineOption Brewery = new(Values.Brewery);

    public static readonly CuisineOption CocktailBar = new(Values.CocktailBar);

    public static readonly CuisineOption Distillery = new(Values.Distillery);

    public static readonly CuisineOption Nightclub = new(Values.Nightclub);

    public static readonly CuisineOption Karaoke = new(Values.Karaoke);

    public static readonly CuisineOption ComedyClub = new(Values.ComedyClub);

    public static readonly CuisineOption MusicVenue = new(Values.MusicVenue);

    public static readonly CuisineOption DanceClub = new(Values.DanceClub);

    public static readonly CuisineOption PoolHall = new(Values.PoolHall);

    public static readonly CuisineOption Casino = new(Values.Casino);

    public static readonly CuisineOption Bowling = new(Values.Bowling);

    public static readonly CuisineOption MovieTheater = new(Values.MovieTheater);

    public static readonly CuisineOption Museum = new(Values.Museum);

    public static readonly CuisineOption Stadium = new(Values.Stadium);

    public static readonly CuisineOption ThemePark = new(Values.ThemePark);

    public static readonly CuisineOption SportsRec = new(Values.SportsRec);

    public static readonly CuisineOption Vegan = new(Values.Vegan);

    public static readonly CuisineOption Vegetarian = new(Values.Vegetarian);

    public static readonly CuisineOption Kosher = new(Values.Kosher);

    public static readonly CuisineOption Halal = new(Values.Halal);

    public static readonly CuisineOption GlutenFree = new(Values.GlutenFree);

    public static readonly CuisineOption Healthy = new(Values.Healthy);

    public CuisineOption(string value)
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
    public static CuisineOption FromCustom(string value)
    {
        return new CuisineOption(value);
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

    public static bool operator ==(CuisineOption value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CuisineOption value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CuisineOption value) => value.Value;

    public static explicit operator CuisineOption(string value) => new(value);

    internal class CuisineOptionSerializer : JsonConverter<CuisineOption>
    {
        public override CuisineOption Read(
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
            return new CuisineOption(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CuisineOption value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CuisineOption ReadAsPropertyName(
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
            return new CuisineOption(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CuisineOption value,
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
        public const string American = "American Restaurant";

        public const string Southern = "Southern Restaurant";

        public const string CajunCreole = "Cajun & Creole Restaurant";

        public const string Southwestern = "Southwestern Restaurant";

        public const string Bbq = "BBQ Restaurant";

        public const string Steakhouse = "Steakhouse";

        public const string Burgers = "Burger Restaurant";

        public const string HotDogs = "Hot Dog Joint";

        public const string Wings = "Wings Joint";

        public const string FriedChicken = "Fried Chicken Restaurant";

        public const string Sandwiches = "Sandwich Shop";

        public const string Deli = "Deli";

        public const string Diner = "Diner";

        public const string Hawaiian = "Hawaiian Restaurant";

        public const string Canadian = "Canadian Restaurant";

        public const string Mexican = "Mexican Restaurant";

        public const string Tacos = "Taco Shop";

        public const string Burritos = "Burrito Restaurant";

        public const string LatinAmerican = "Latin American Restaurant";

        public const string Caribbean = "Caribbean Restaurant";

        public const string Jamaican = "Jamaican Restaurant";

        public const string Cuban = "Cuban Restaurant";

        public const string PuertoRican = "Puerto Rican Restaurant";

        public const string Brazilian = "Brazilian Restaurant";

        public const string Argentine = "Argentine Restaurant";

        public const string Peruvian = "Peruvian Restaurant";

        public const string Colombian = "Colombian Restaurant";

        public const string Venezuelan = "Venezuelan Restaurant";

        public const string Salvadoran = "Salvadoran Restaurant";

        public const string Honduran = "Honduran Restaurant";

        public const string Italian = "Italian Restaurant";

        public const string Pizza = "Pizza Restaurant";

        public const string Pasta = "Pasta Restaurant";

        public const string French = "French Restaurant";

        public const string Creperie = "Creperie";

        public const string Spanish = "Spanish Restaurant";

        public const string Tapas = "Tapas Restaurant";

        public const string Portuguese = "Portuguese Restaurant";

        public const string German = "German Restaurant";

        public const string Austrian = "Austrian Restaurant";

        public const string Swiss = "Swiss Restaurant";

        public const string Fondue = "Fondue Restaurant";

        public const string British = "British Restaurant";

        public const string FishAndChips = "Fish & Chips Shop";

        public const string Irish = "Irish Restaurant";

        public const string Belgian = "Belgian Restaurant";

        public const string Dutch = "Dutch Restaurant";

        public const string Scandinavian = "Scandinavian Restaurant";

        public const string EasternEuropean = "Eastern European Restaurant";

        public const string Polish = "Polish Restaurant";

        public const string Russian = "Russian Restaurant";

        public const string European = "European Restaurant";

        public const string Mediterranean = "Mediterranean Restaurant";

        public const string Greek = "Greek Restaurant";

        public const string MiddleEastern = "Middle Eastern Restaurant";

        public const string Lebanese = "Lebanese Restaurant";

        public const string Israeli = "Israeli Restaurant";

        public const string Jewish = "Jewish Restaurant";

        public const string Turkish = "Turkish Restaurant";

        public const string Persian = "Persian Restaurant";

        public const string Egyptian = "Egyptian Restaurant";

        public const string Moroccan = "Moroccan Restaurant";

        public const string Armenian = "Armenian Restaurant";

        public const string Georgian = "Georgian Restaurant";

        public const string Falafel = "Falafel Restaurant";

        public const string Kebab = "Kebab Shop";

        public const string African = "African Restaurant";

        public const string Ethiopian = "Ethiopian Restaurant";

        public const string Indian = "Indian Restaurant";

        public const string Pakistani = "Pakistani Restaurant";

        public const string Bangladeshi = "Bangladeshi Restaurant";

        public const string SriLankan = "Sri Lankan Restaurant";

        public const string Nepalese = "Nepalese Restaurant";

        public const string Afghan = "Afghan Restaurant";

        public const string Asian = "Asian Restaurant";

        public const string Chinese = "Chinese Restaurant";

        public const string Taiwanese = "Taiwanese Restaurant";

        public const string HongKong = "Hong Kong Restaurant";

        public const string DimSum = "Dim Sum Restaurant";

        public const string HotPot = "Hot Pot Restaurant";

        public const string Dumplings = "Dumpling Restaurant";

        public const string Noodles = "Noodle Shop";

        public const string Japanese = "Japanese Restaurant";

        public const string Sushi = "Sushi Restaurant";

        public const string Ramen = "Ramen Restaurant";

        public const string Yakitori = "Yakitori Restaurant";

        public const string Korean = "Korean Restaurant";

        public const string Mongolian = "Mongolian Restaurant";

        public const string Thai = "Thai Restaurant";

        public const string Vietnamese = "Vietnamese Restaurant";

        public const string Filipino = "Filipino Restaurant";

        public const string Malaysian = "Malaysian Restaurant";

        public const string Indonesian = "Indonesian Restaurant";

        public const string Singaporean = "Singaporean Restaurant";

        public const string Burmese = "Burmese Restaurant";

        public const string Cambodian = "Cambodian Restaurant";

        public const string Australian = "Australian Restaurant";

        public const string Seafood = "Seafood Restaurant";

        public const string Poke = "Poke Restaurant";

        public const string Salads = "Salad Restaurant";

        public const string Soups = "Soup Restaurant";

        public const string Breakfast = "Breakfast Restaurant";

        public const string Brunch = "Brunch Restaurant";

        public const string Bagels = "Bagel Shop";

        public const string Buffet = "Buffet";

        public const string FastFood = "Fast Food Restaurant";

        public const string FoodTruck = "Food Truck";

        public const string Gastropub = "Gastropub";

        public const string Bakery = "Bakery";

        public const string Cafe = "Cafe";

        public const string BubbleTea = "Bubble Tea Shop";

        public const string JuiceBar = "Juice Bar";

        public const string Dessert = "Dessert Shop";

        public const string IceCream = "Ice Cream Shop";

        public const string Doughnuts = "Doughnut Shop";

        public const string Bar = "Bar";

        public const string SportsBar = "Sports Bar";

        public const string WineBar = "Wine Bar";

        public const string Winery = "Winery";

        public const string Brewery = "Brewery";

        public const string CocktailBar = "Cocktail Bar";

        public const string Distillery = "Distillery";

        public const string Nightclub = "Nightclub";

        public const string Karaoke = "Karaoke Bar";

        public const string ComedyClub = "Comedy Club";

        public const string MusicVenue = "Music Venue";

        public const string DanceClub = "Dance Club";

        public const string PoolHall = "Pool Hall";

        public const string Casino = "Casino";

        public const string Bowling = "Bowling Alley";

        public const string MovieTheater = "Movie Theater";

        public const string Museum = "Museum";

        public const string Stadium = "Stadium";

        public const string ThemePark = "Theme Park";

        public const string SportsRec = "Sports & Recreation";

        public const string Vegan = "Vegan Restaurant";

        public const string Vegetarian = "Vegetarian Restaurant";

        public const string Kosher = "Kosher Restaurant";

        public const string Halal = "Halal Restaurant";

        public const string GlutenFree = "Gluten Free Restaurant";

        public const string Healthy = "Healthy Restaurant";
    }
}
