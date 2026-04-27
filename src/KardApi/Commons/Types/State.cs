using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(State.StateSerializer))]
[Serializable]
public readonly record struct State : IStringEnum
{
    public static readonly State Al = new(Values.Al);

    public static readonly State Ak = new(Values.Ak);

    public static readonly State As = new(Values.As);

    public static readonly State Az = new(Values.Az);

    public static readonly State Ar = new(Values.Ar);

    public static readonly State Ca = new(Values.Ca);

    public static readonly State Co = new(Values.Co);

    public static readonly State Ct = new(Values.Ct);

    public static readonly State De = new(Values.De);

    public static readonly State Dc = new(Values.Dc);

    public static readonly State Fm = new(Values.Fm);

    public static readonly State Fl = new(Values.Fl);

    public static readonly State Ga = new(Values.Ga);

    public static readonly State Gu = new(Values.Gu);

    public static readonly State Hi = new(Values.Hi);

    public static readonly State Id = new(Values.Id);

    public static readonly State Il = new(Values.Il);

    public static readonly State In = new(Values.In);

    public static readonly State Ia = new(Values.Ia);

    public static readonly State Ks = new(Values.Ks);

    public static readonly State Ky = new(Values.Ky);

    public static readonly State La = new(Values.La);

    public static readonly State Me = new(Values.Me);

    public static readonly State Mh = new(Values.Mh);

    public static readonly State Md = new(Values.Md);

    public static readonly State Ma = new(Values.Ma);

    public static readonly State Mi = new(Values.Mi);

    public static readonly State Mn = new(Values.Mn);

    public static readonly State Ms = new(Values.Ms);

    public static readonly State Mo = new(Values.Mo);

    public static readonly State Mt = new(Values.Mt);

    public static readonly State Ne = new(Values.Ne);

    public static readonly State Nv = new(Values.Nv);

    public static readonly State Nh = new(Values.Nh);

    public static readonly State Nj = new(Values.Nj);

    public static readonly State Nm = new(Values.Nm);

    public static readonly State Ny = new(Values.Ny);

    public static readonly State Nc = new(Values.Nc);

    public static readonly State Nd = new(Values.Nd);

    public static readonly State Mp = new(Values.Mp);

    public static readonly State Oh = new(Values.Oh);

    public static readonly State Ok = new(Values.Ok);

    public static readonly State Or = new(Values.Or);

    public static readonly State Pw = new(Values.Pw);

    public static readonly State Pa = new(Values.Pa);

    public static readonly State Pr = new(Values.Pr);

    public static readonly State Ri = new(Values.Ri);

    public static readonly State Sc = new(Values.Sc);

    public static readonly State Sd = new(Values.Sd);

    public static readonly State Tn = new(Values.Tn);

    public static readonly State Tx = new(Values.Tx);

    public static readonly State Ut = new(Values.Ut);

    public static readonly State Vt = new(Values.Vt);

    public static readonly State Vi = new(Values.Vi);

    public static readonly State Va = new(Values.Va);

    public static readonly State Wa = new(Values.Wa);

    public static readonly State Wv = new(Values.Wv);

    public static readonly State Wi = new(Values.Wi);

    public static readonly State Wy = new(Values.Wy);

    public State(string value)
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
    public static State FromCustom(string value)
    {
        return new State(value);
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

    public static bool operator ==(State value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(State value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(State value) => value.Value;

    public static explicit operator State(string value) => new(value);

    internal class StateSerializer : JsonConverter<State>
    {
        public override State Read(
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
            return new State(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            State value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override State ReadAsPropertyName(
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
            return new State(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            State value,
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
