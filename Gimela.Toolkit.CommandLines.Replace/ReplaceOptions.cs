﻿﻿/*
 * [The "BSD Licence"]
 * Copyright (c) 2011-2012 Chundong Gao
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 3. The name of the author may not be used to endorse or promote products
 *    derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ''AS IS'' AND ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Gimela.Toolkit.CommandLines.Replace
{
	internal static class ReplaceOptions
	{
		public static readonly ReadOnlyCollection<string> InputFileOptions;
		public static readonly ReadOnlyCollection<string> OutputFileOptions;
		public static readonly ReadOnlyCollection<string> FromTextOptions;
		public static readonly ReadOnlyCollection<string> ToTextOptions;
		public static readonly ReadOnlyCollection<string> HelpOptions;
		public static readonly ReadOnlyCollection<string> VersionOptions;

		public static readonly IDictionary<ReplaceOptionType, ICollection<string>> Options;

		[SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
		static ReplaceOptions()
		{
			InputFileOptions = new ReadOnlyCollection<string>(new string[] { "i", "inputfile" });
			OutputFileOptions = new ReadOnlyCollection<string>(new string[] { "o", "outputfile" });
			FromTextOptions = new ReadOnlyCollection<string>(new string[] { "f", "fromstring" });
			ToTextOptions = new ReadOnlyCollection<string>(new string[] { "t", "tostring" });
			HelpOptions = new ReadOnlyCollection<string>(new string[] { "h", "help" });
			VersionOptions = new ReadOnlyCollection<string>(new string[] { "v", "version" });

			Options = new Dictionary<ReplaceOptionType, ICollection<string>>();
			Options.Add(ReplaceOptionType.InputFile, InputFileOptions);
			Options.Add(ReplaceOptionType.OutputFile, OutputFileOptions);
			Options.Add(ReplaceOptionType.FromText, FromTextOptions);
			Options.Add(ReplaceOptionType.ToText, ToTextOptions);
			Options.Add(ReplaceOptionType.Help, HelpOptions);
			Options.Add(ReplaceOptionType.Version, VersionOptions);
		}

		public static List<string> GetSingleOptions()
		{
			List<string> singleOptionList = new List<string>();

			singleOptionList.AddRange(ReplaceOptions.HelpOptions);
			singleOptionList.AddRange(ReplaceOptions.VersionOptions);

			return singleOptionList;
		}

		#region Usage

		public const string Version = @"Replace v1.0";
		public static readonly string Usage = string.Format(CultureInfo.CurrentCulture, @"
NAME

	replace - changes strings in place in a file

SYNOPSIS

	replace [OPTION] FILE STRING1 STRING2

DESCRIPTION

	The replace utility program changes strings in place in files.

OPTIONS

	-i, --inputfile=FILE
	{0}{0}The FILE represents the input file.
	-o, --outputfile=FILE
	{0}{0}The FILE represents the output file.
	-f, --from=STRING
	{0}{0}Represents a string to look for and to represents its replacement.
	-t, --to=STRING
	{0}{0}Represents a string to replace. 
	-h, --help 
	{0}{0}Display this help and exit.
	-v, --version
	{0}{0}Output version information and exit.

EXAMPLES

	replace -i example.txt -f chundong -t gaochundong
	Replace the word 'chundong' with the word 'gaochundong' in the example.txt file.

AUTHOR

	Written by Chundong Gao.

REPORTING BUGS

	Report bugs to <gaochundong@gmail.com>.

COPYRIGHT

	Copyright (C) 2011-2012 Chundong Gao. All Rights Reserved.
", @" ");

		#endregion

		public static ReplaceOptionType GetOptionType(string option)
		{
			ReplaceOptionType optionType = ReplaceOptionType.None;

			foreach (var pair in Options)
			{
				foreach (var item in pair.Value)
				{
					if (item == option)
					{
						optionType = pair.Key;
						break;
					}
				}
			}

			return optionType;
		}
	}
}