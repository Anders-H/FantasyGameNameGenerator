namespace FantasyGameNameGenerator;

internal class HyphenProbabilityTranslator
{
    private readonly HyphenProbability _hyphenProbability;
    private readonly Random _rnd;

    public HyphenProbabilityTranslator(HyphenProbability hyphenProbability, Random rnd)
    {
        _hyphenProbability = hyphenProbability;
        _rnd = rnd;
    }

    public bool NextSeparatorIsHyphen() =>
        _rnd.Next(GetHyphenProbability()) == 0;

    private int GetHyphenProbability() =>
        _hyphenProbability switch
        {
            HyphenProbability.Low => 15,
            HyphenProbability.Medium => 9,
            HyphenProbability.High => 4,
            _ => throw new ArgumentOutOfRangeException()
        };
}