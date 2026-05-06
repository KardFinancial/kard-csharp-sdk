using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace KardFinancial.Hem;

/// <summary>
/// Hashed Email (HEM) generation following UID2/LiveRamp industry standards.
///
/// <list type="bullet">
///   <item><description>Remove all whitespace.</description></item>
///   <item><description>Lowercase.</description></item>
///   <item><description>Gmail/Googlemail only: strip any "+" suffix from the local-part and remove all "." characters.</description></item>
///   <item><description>Canonicalize googlemail.com to gmail.com.</description></item>
///   <item><description>SHA-256 over the UTF-8 bytes; lowercase hex output.</description></item>
/// </list>
/// </summary>
public static class Hem
{
    private static readonly HashSet<string> GmailDomains = new(StringComparer.Ordinal)
    {
        "gmail.com",
        "googlemail.com",
    };

    /// <summary>
    /// Returns the lowercase hex SHA-256 digest of the normalized, UTF-8 encoded email address.
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="raw"/> is null, empty, blank after whitespace removal, or
    /// not a valid single-"@" email address.
    /// </exception>
    public static string GenerateHEM(string raw)
    {
        var normalized = NormalizeEmail(raw);
        var bytes = Encoding.UTF8.GetBytes(normalized);
        using var sha = SHA256.Create();
        var hash = sha.ComputeHash(bytes);

        var sb = new StringBuilder(hash.Length * 2);
        foreach (var b in hash)
        {
            sb.Append(b.ToString("x2", CultureInfo.InvariantCulture));
        }
        return sb.ToString();
    }

    private static string NormalizeEmail(string raw)
    {
        if (string.IsNullOrEmpty(raw))
        {
            throw new ArgumentException("Email address must not be null or empty.", nameof(raw));
        }

        var stripped = new StringBuilder(raw.Length);
        foreach (var c in raw)
        {
            if (!char.IsWhiteSpace(c))
            {
                stripped.Append(c);
            }
        }
        var email = stripped.ToString().ToLowerInvariant();

        if (email.Length == 0)
        {
            throw new ArgumentException("Email address must not be blank.", nameof(raw));
        }

        var atCount = 0;
        var atIndex = -1;
        for (var i = 0; i < email.Length; i++)
        {
            if (email[i] == '@')
            {
                atCount++;
                atIndex = i;
            }
        }

        if (atCount == 0)
        {
            throw new ArgumentException("Invalid email format: missing '@'.", nameof(raw));
        }
        if (atCount > 1)
        {
            throw new ArgumentException("Invalid email format: multiple '@' characters.", nameof(raw));
        }

        var local = email.Substring(0, atIndex);
        var domain = email.Substring(atIndex + 1);

        if (local.Length == 0)
        {
            throw new ArgumentException("Invalid email format: empty local-part.", nameof(raw));
        }
        if (domain.Length == 0)
        {
            throw new ArgumentException("Invalid email format: empty domain.", nameof(raw));
        }

        if (GmailDomains.Contains(domain))
        {
            var plus = local.IndexOf('+');
            if (plus >= 0)
            {
                local = local.Substring(0, plus);
            }
            local = local.Replace(".", string.Empty);
            domain = "gmail.com";

            if (local.Length == 0)
            {
                throw new ArgumentException(
                    "Invalid email format: empty local-part after Gmail normalization.",
                    nameof(raw)
                );
            }
        }

        return local + "@" + domain;
    }
}
