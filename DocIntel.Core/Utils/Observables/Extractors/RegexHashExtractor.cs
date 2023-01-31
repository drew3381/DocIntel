using System.Collections.Generic;
using System.Text.RegularExpressions;
using Synsharp.Telepath.Messages;

namespace DocIntel.Core.Utils.Observables;

public class RegexHashExtractor : RegexExtractor
{
    public const string MD5_REGEX = @"[^a-fA-F\d\/=\\]([a-fA-F\d]{32})[^a-fA-F\d\/=\\]";
    public const string SHA1_REGEX = @"[^a-fA-F\d\/=\\]([a-fA-F\d]{40})[^a-fA-F\d\/=\\]";
    public const string SHA256_REGEX = @"[^a-fA-F\d\/=\\]([a-fA-F\d]{64})[^a-fA-F\d\/=\\]";
    public const string SHA512_REGEX = @"[^a-fA-F\d\/=\\]([a-fA-F\d]{128})[^a-fA-F\d\/=\\]";

#pragma warning disable CS1998
    public override async IAsyncEnumerable<SynapseNode> Extract(string content)
#pragma warning restore CS1998
    {
        var matches = Regex.Matches(content, MD5_REGEX, DEFAULT_REGEX_OPTIONS);
        foreach (Match match in matches)
        {
            var synapseObject  = new SynapseNode()
            {
                Form = "hash:md5",
                Valu = match.Groups[1].Value
            };
            yield return synapseObject;
        }
        
        matches = Regex.Matches(content, SHA1_REGEX, DEFAULT_REGEX_OPTIONS);
        foreach (Match match in matches)
        {
            var synapseObject  = new SynapseNode()
            {
                Form = "hash:sha1",
                Valu = match.Groups[1].Value
            };
            yield return synapseObject;
        }
        
        matches = Regex.Matches(content, SHA256_REGEX, DEFAULT_REGEX_OPTIONS);
        foreach (Match match in matches)
        {
            var synapseObject  = new SynapseNode()
            {
                Form = "hash:sha256",
                Valu = match.Groups[1].Value
            };
            yield return synapseObject;
        }
    }
}