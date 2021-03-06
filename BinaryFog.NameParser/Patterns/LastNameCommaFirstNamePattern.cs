﻿using System.Text.RegularExpressions;
using static BinaryFog.NameParser.RegexNameComponents;

namespace BinaryFog.NameParser.Patterns {
	internal class LastNameCommaFirstNamePattern : IPattern {
		private static readonly Regex Rx = new Regex(
			@"^" + Last + CommaSpace + First + @"$",
			RegexOptions.Compiled | RegexOptions.IgnoreCase);

		public ParsedName Parse(string rawName) {
			var match = Rx.Match(rawName);
			if (!match.Success) return null;
			var pn = new ParsedName {
				FirstName = match.Groups["first"].Value,
				LastName = match.Groups["last"].Value,
				DisplayName = $"{match.Groups["first"].Value} {match.Groups["last"].Value}",
				Score = 100
			};
			return pn;
		}
	}
}
