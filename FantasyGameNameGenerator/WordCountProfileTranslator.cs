namespace FantasyGameNameGenerator;

internal class WordCountProfileTranslator
{
    private readonly WordCountProfile _wordCountProfile;
    private readonly Random _rnd;

    public WordCountProfileTranslator(WordCountProfile wordCountProfile, Random rnd)
    {
        _wordCountProfile = wordCountProfile;
        _rnd = rnd;
    }

    public int GetWordCount()
    {
        var wordCounts = GetWordCountsFromProfile();
        
        var wordCount = wordCounts[_rnd.Next(wordCounts.Length)];

        return wordCount;
    }

    private int[] GetWordCountsFromProfile() =>
        _wordCountProfile switch
        {
            WordCountProfile.LikelyOneWordFiveAtMost => new[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5 },
            WordCountProfile.LikelyTwoWordsFiveAtMost => new[] { 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5 },
            WordCountProfile.TwoToFourWords => new[] { 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4 },
            WordCountProfile.TwoOrThreeWords => new[] { 2, 3 },
            _ => throw new ArgumentOutOfRangeException()
        };

}