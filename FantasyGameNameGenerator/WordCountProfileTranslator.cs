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
        return wordCounts[_rnd.Next(wordCounts.Length)];
    }

    private int[] GetWordCountsFromProfile() =>
        _wordCountProfile switch
        {
            WordCountProfile.LikelyOneWordFiveAtMost => [1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5],
            WordCountProfile.LikelyTwoWordsFiveAtMost => [1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5],
            WordCountProfile.TwoToFourWords => [2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4],
            WordCountProfile.TwoOrThreeWords => [2, 3],
            WordCountProfile.OneToThree => [1, 2, 3],
            _ => throw new ArgumentOutOfRangeException()
        };

}