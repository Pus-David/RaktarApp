using RaktarApp;

List<Termek> Termekek = new List<Termek>();
int hibasSorokSzama = 0;
foreach (var sor in File.ReadAllLines("termekek.txt").Skip(1))
{
    if (string.IsNullOrEmpty(sor))
    {
        hibasSorokSzama++;
        continue;
    }
    string[] adatok = sor.Split('|');

    if (adatok.Length != 4)
    {
        hibasSorokSzama++;
        continue;
    }
    if (adatok[0] != "G" && adatok[0] != "S")
    {
        hibasSorokSzama++;
        continue;
    }
    if (!int.TryParse(adatok[2], out int alapar) || !int.TryParse(adatok[3], out int garancia))
    {
        hibasSorokSzama++;
        continue;
    }
    if (adatok[0] == "S")
    {
        Termek aktualistermek = new Termek(adatok[0], alapar);
        Termekek.Add(aktualistermek);
    }
    else
    {
        TartosTermek aktualistermek = new TartosTermek(garancia, adatok[0], alapar);
        Termekek.Add(aktualistermek);
    }
}
Console.WriteLine($"Sikeresen beolvasott:{Termekek.Count}");
Console.WriteLine($"hibas sorok:{hibasSorokSzama}");

foreach(Termek termek in Termekek)
{
    Console.WriteLine(termek);
}
Console.WriteLine();
int teljesertek = Termekek.Sum(t => t.ErtekSzamitas(10));