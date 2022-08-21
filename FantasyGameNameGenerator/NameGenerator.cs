using System.Text;

namespace FantasyGameNameGenerator
{
    public class NameGenerator
    {
        private readonly List<string> _vowels;
        private readonly List<string> _consonants;
        private readonly List<string> _startConsonants;
        private readonly Random _rnd;
        public WordCountProfile WordCountProfile { get; set; }
        public HyphenProbability HyphenProbability { get; set; }
        public static List<string> UsedNames { get; }

        static NameGenerator()
        {
            UsedNames = new List<string>();
        }

        public NameGenerator() : this(WordCountProfile.LikelyOneWordFiveAtMost, HyphenProbability.Medium)
        {
        }

        public NameGenerator(WordCountProfile wordCountProfile, HyphenProbability hyphenPropability)
        {
            WordCountProfile = wordCountProfile;
            HyphenProbability = hyphenPropability;

            _rnd = new Random();

            _vowels = new List<string>
            {
                "A",
                "O",
                "U",
                "E",
                "I",
                "Y"
            };

            _consonants = new List<string>
            {
                "B",
                "BB",
                "C",
                "CR",
                "CK",
                "D",
                "DD",
                "F",
                "FF",
                "FR",
                "FL",
                "G",
                "GG",
                "H",
                "J",
                "K",
                "KL",
                "KV",
                "KR",
                "L",
                "M",
                "MM",
                "N",
                "NN",
                "ND",
                "P",
                "PP",
                "Q",
                "R",
                "RR",
                "RK",
                "S",
                "SS",
                "T",
                "TT",
                "TJ",
                "TR",
                "V",
                "W",
                "X",
                "Z",
                "ZZ"
            };

            _startConsonants = new List<string>
            {
                "B",
                "C",
                "CR",
                "D",
                "F",
                "FR",
                "FL",
                "G",
                "H",
                "J",
                "K",
                "KL",
                "KV",
                "KR",
                "L",
                "M",
                "N",
                "P",
                "Q",
                "R",
                "RK",
                "S",
                "T",
                "TJ",
                "TR",
                "V",
                "W",
                "X",
                "Z"
            };
        }

        public string GenerateName()
        {
            var tryCount = 0;
            do
            {
                var name = GetRandomName();

                if (UsedNames.All(x => string.Compare(x, name, StringComparison.CurrentCultureIgnoreCase) != 0))
                {
                    UsedNames.Add(name);
                    return name;
                }

                tryCount++;
                if (tryCount > 1000)
                    break;

            } while (true);

            return "";
        }

        private string GetRandomName()
        {
            var hyphenProbabilityTranslator = new HyphenProbabilityTranslator(HyphenProbability, _rnd);
            var wordCountProfileTranslator = new WordCountProfileTranslator(WordCountProfile, _rnd);
            
            var s = new StringBuilder();
            var wordCount = wordCountProfileTranslator.GetWordCount();
            for (var i = 0; i < wordCount; i++)
            {
                int syllables;

                if (i == 0 && wordCount <= 1)
                    syllables = _rnd.Next(5) + 1;
                else if (i == 1 && wordCount == 3)
                    syllables = _rnd.Next(2);
                else if (i == 2 && wordCount == 4)
                    syllables = _rnd.Next(2);
                else
                    syllables = _rnd.Next(4) + 1;

                if (_rnd.Next(4) == 0 || syllables <= 0)
                    s.Append(_startConsonants[_rnd.Next(_startConsonants.Count)]);

                for (var j = 0; j < syllables; j++)
                {
                    s.Append(_vowels[_rnd.Next(_vowels.Count)]);
                    s.Append(_consonants[_rnd.Next(_consonants.Count)]);
                }

                if (_rnd.Next(4) == 0 || syllables <= 0)
                    s.Append(_vowels[_rnd.Next(_vowels.Count)]);

                if (i < wordCount - 1)
                    s.Append(hyphenProbabilityTranslator.NextSeparatorIsHyphen() ? "-" : " ");
            }
            return FixCase(s.ToString());
        }

        private string FixCase(string s)
        {
            var ret = new StringBuilder();
            
            for (var i = 0; i < s.Length; i++)
                if (i == 0 || s[i - 1] == ' ' || s[i - 1] == '-')
                    ret.Append(s[i].ToString().ToUpper());
                else
                    ret.Append(s[i].ToString().ToLower());
            
            return ret.ToString();
        }
    }
}