namespace SimaCheveresann;

public class Mecanic : User
{
    public Mecanic(string codUnic, string nume, string prenume, string email, string parola)
        : base(codUnic, nume, prenume, email, parola) { }

    public void PreiaCerere(List<CerereRezolvare> cereri)
    {
        var cerere = cereri.FirstOrDefault(c => c.Status == StatusCerere.InPreluare);

        if (cerere != null)
        {
            cerere.Status = StatusCerere.Investigare;
            Console.WriteLine("Cerere preluată: " + cerere);
        }
        else
            Console.WriteLine("Nu există cereri de preluat.");
    }

    public void InvestigheazaProblema()
    {
        Console.WriteLine("Problemă investigată.");
    }

    public void CerePiese(List<ComandaPiese> comenzi)
    {
        Console.Write("Detalii comandă: ");
        string detalii = Console.ReadLine();
        comenzi.Add(new ComandaPiese(Guid.NewGuid().ToString(), detalii));
        Console.WriteLine("Comandă adăugată.");
    }

    public void RezolvaProblema(List<CerereRezolvare> cereri, List<ComandaPiese> comenzi)
    {
        Console.WriteLine("Problemă rezolvată.");
    }
}