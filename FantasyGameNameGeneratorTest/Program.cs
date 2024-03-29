﻿using FantasyGameNameGenerator;

var n = new NameGenerator();

Console.WriteLine("Likely one word, five words at most:");
n.WordCountProfile = WordCountProfile.LikelyOneWordFiveAtMost;
Console.WriteLine();
for (var i = 0; i < 10; i++)
    Console.WriteLine($"{i + 1}. {n.GenerateName()}");
Console.WriteLine();

Console.WriteLine("Likely two words, five words at most:");
n.WordCountProfile = WordCountProfile.LikelyTwoWordsFiveAtMost;
Console.WriteLine();
for (var i = 0; i < 10; i++)
    Console.WriteLine($"{i + 1}. {n.GenerateName()}");
Console.WriteLine();

Console.WriteLine("Two to four words:");
n.WordCountProfile = WordCountProfile.TwoToFourWords;
Console.WriteLine();
for (var i = 0; i < 10; i++)
    Console.WriteLine($"{i + 1}. {n.GenerateName()}");
Console.WriteLine();

Console.WriteLine("High probability for hyphen:");
n.WordCountProfile = WordCountProfile.TwoOrThreeWords;
n.HyphenProbability = HyphenProbability.High;
Console.WriteLine();
for (var i = 0; i < 10; i++)
    Console.WriteLine($"{i + 1}. {n.GenerateName()}");
Console.WriteLine();

Console.WriteLine("Low probability for hyphen:");
n.HyphenProbability = HyphenProbability.Low;
Console.WriteLine();
for (var i = 0; i < 10; i++)
    Console.WriteLine($"{i + 1}. {n.GenerateName()}");
Console.WriteLine();
