using FantasyGameNameGenerator;

var n = new NameGenerator();

for (var i = 0; i < 30; i++)
    Console.WriteLine($"{i + 1}. {n.GenerateName()}");