using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(States.StatesSerializer))]
[Serializable]
public readonly record struct States : IStringEnum
{
    public static readonly States Al = new(Values.Al);

    public static readonly States Ak = new(Values.Ak);

    public static readonly States As = new(Values.As);

    public static readonly States Az = new(Values.Az);

    public static readonly States Ar = new(Values.Ar);

    public static readonly States Ca = new(Values.Ca);

    public static readonly States Co = new(Values.Co);

    public static readonly States Ct = new(Values.Ct);

    public static readonly States De = new(Values.De);

    public static readonly States Dc = new(Values.Dc);

    public static readonly States Fm = new(Values.Fm);

    public static readonly States Fl = new(Values.Fl);

    public static readonly States Ga = new(Values.Ga);

    public static readonly States Gu = new(Values.Gu);

    public static readonly States Hi = new(Values.Hi);

    public static readonly States Id = new(Values.Id);

    public static readonly States Il = new(Values.Il);

    public static readonly States In = new(Values.In);

    public static readonly States Ia = new(Values.Ia);

    public static readonly States Ks = new(Values.Ks);

    public static readonly States Ky = new(Values.Ky);

    public static readonly States La = new(Values.La);

    public static readonly States Me = new(Values.Me);

    public static readonly States Mh = new(Values.Mh);

    public static readonly States Md = new(Values.Md);

    public static readonly States Ma = new(Values.Ma);

    public static readonly States Mi = new(Values.Mi);

    public static readonly States Mn = new(Values.Mn);

    public static readonly States Ms = new(Values.Ms);

    public static readonly States Mo = new(Values.Mo);

    public static readonly States Mt = new(Values.Mt);

    public static readonly States Ne = new(Values.Ne);

    public static readonly States Nv = new(Values.Nv);

    public static readonly States Nh = new(Values.Nh);

    public static readonly States Nj = new(Values.Nj);

    public static readonly States Nm = new(Values.Nm);

    public static readonly States Ny = new(Values.Ny);

    public static readonly States Nc = new(Values.Nc);

    public static readonly States Nd = new(Values.Nd);

    public static readonly States Mp = new(Values.Mp);

    public static readonly States Oh = new(Values.Oh);

    public static readonly States Ok = new(Values.Ok);

    public static readonly States Or = new(Values.Or);

    public static readonly States Pw = new(Values.Pw);

    public static readonly States Pa = new(Values.Pa);

    public static readonly States Pr = new(Values.Pr);

    public static readonly States Ri = new(Values.Ri);

    public static readonly States Sc = new(Values.Sc);

    public static readonly States Sd = new(Values.Sd);

    public static readonly States Tn = new(Values.Tn);

    public static readonly States Tx = new(Values.Tx);

    public static readonly States Ut = new(Values.Ut);

    public static readonly States Vt = new(Values.Vt);

    public static readonly States Vi = new(Values.Vi);

    public static readonly States Va = new(Values.Va);

    public static readonly States Wa = new(Values.Wa);

    public static readonly States Wv = new(Values.Wv);

    public static readonly States Wi = new(Values.Wi);

    public static readonly States Wy = new(Values.Wy);

    public States(string value)
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
    public static States FromCustom(string value)
    {
        return new States(value);
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

    public static bool operator ==(States value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(States value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(States value) => value.Value;

    public static explicit operator States(string value) => new(value);

    internal class StatesSerializer : JsonConverter<States>
    {
        public override States Read(
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
            return new States(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            States value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override States ReadAsPropertyName(
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
            return new States(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            States value,
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
        public const string Al = "AL";

        public const string Ak = "AK";

        public const string As = "AS";

        public const string Az = "AZ";

        public const string Ar = "AR";

        public const string Ca = "CA";

        public const string Co = "CO";

        public const string Ct = "CT";

        public const string De = "DE";

        public const string Dc = "DC";

        public const string Fm = "FM";

        public const string Fl = "FL";

        public const string Ga = "GA";

        public const string Gu = "GU";

        public const string Hi = "HI";

        public const string Id = "ID";

        public const string Il = "IL";

        public const string In = "IN";

        public const string Ia = "IA";

        public const string Ks = "KS";

        public const string Ky = "KY";

        public const string La = "LA";

        public const string Me = "ME";

        public const string Mh = "MH";

        public const string Md = "MD";

        public const string Ma = "MA";

        public const string Mi = "MI";

        public const string Mn = "MN";

        public const string Ms = "MS";

        public const string Mo = "MO";

        public const string Mt = "MT";

        public const string Ne = "NE";

        public const string Nv = "NV";

        public const string Nh = "NH";

        public const string Nj = "NJ";

        public const string Nm = "NM";

        public const string Ny = "NY";

        public const string Nc = "NC";

        public const string Nd = "ND";

        public const string Mp = "MP";

        public const string Oh = "OH";

        public const string Ok = "OK";

        public const string Or = "OR";

        public const string Pw = "PW";

        public const string Pa = "PA";

        public const string Pr = "PR";

        public const string Ri = "RI";

        public const string Sc = "SC";

        public const string Sd = "SD";

        public const string Tn = "TN";

        public const string Tx = "TX";

        public const string Ut = "UT";

        public const string Vt = "VT";

        public const string Vi = "VI";

        public const string Va = "VA";

        public const string Wa = "WA";

        public const string Wv = "WV";

        public const string Wi = "WI";

        public const string Wy = "WY";
    }
}
