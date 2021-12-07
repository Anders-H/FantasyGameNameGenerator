# Fantasy game name generator

A simple function that generates unique names for, like, a science fiction game.

Each call to `GenerateName` returns a unique name.

Example:

```
using FantasyGameNameGenerator;

var n = new NameGenerator();

for (var i = 0; i < 30; i++)
    Console.WriteLine($"{i + 1}. {n.GenerateName()}");
```

Sample response:

```
1. Jot Tryppondul Jitud Yrryz-Unucra
2. Cracefugg Ekr
3. Lefruvin Dy Binn
4. Frygg-Epp-Orywe
5. Critaflih-Ifizz
6. Offocrixybbikv
7. Ubutr Epp Ikvemax
8. Eppazavyvo Yreggan
9. Vuhappuwacre
10. Enduzoffy Obybepp Zyfufe-Abbyggetj Ucry
11. Ryfaq Akle Ovik
12. Ylitacr
13. Etj Sam Ec Amydd Ikragunnack
14. Ap
15. Onnecom Ycoz
16. Uckevu Api Ypatrorr
17. Erkucritt Azecyligga
18. Asevycork Uvekrycrukv
19. Unydattugg Kreklabba Xo Ytirr
20. Idoja
21. Exoz
22. Abb
23. Qanduweffack Qoq
24. Yff-Yxu
25. Unyniromojo
26. Ykvickamm
27. Eggiryd Mofy
28. Ofl Uzib
29. Yce Ehurrad Enojeklyg-Yrkytrosy Etjunyfrokr
30. Uqini Ydu Tje Ojukvefr
```