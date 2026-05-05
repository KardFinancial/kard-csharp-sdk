using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using KardApi.Hem;
using NUnit.Framework;

namespace KardApi.Test.Hem;

[TestFixture]
public class HemTests
{
    public sealed class TestVector
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("input")]
        public string Input { get; set; } = "";

        [JsonPropertyName("normalized")]
        public string Normalized { get; set; } = "";

        [JsonPropertyName("sha256_hex")]
        public string Sha256Hex { get; set; } = "";

        [JsonPropertyName("uid2_validated")]
        public bool Uid2Validated { get; set; }
    }

    private static IEnumerable<TestCaseData> Vectors()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Hem", "test_vectors.json");
        var json = File.ReadAllText(path);
        var vectors = JsonSerializer.Deserialize<List<TestVector>>(json) ?? new List<TestVector>();
        Assert.That(vectors, Is.Not.Empty, "test_vectors.json yielded no vectors");

        foreach (var v in vectors)
        {
            yield return new TestCaseData(v).SetName("{m}: " + v.Name);
        }
    }

    [TestCaseSource(nameof(Vectors))]
    public void GenerateHEM_ProducesExpectedHash(TestVector v)
    {
        Assert.That(KardApi.Hem.Hem.GenerateHEM(v.Input), Is.EqualTo(v.Sha256Hex));
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("@")]
    [TestCase("user")]
    [TestCase("user@")]
    [TestCase("@domain.com")]
    [TestCase("a@b@c.com")]
    public void GenerateHEM_RejectsInvalidEmails(string input)
    {
        Assert.Throws<global::System.ArgumentException>(() => KardApi.Hem.Hem.GenerateHEM(input));
    }
}
