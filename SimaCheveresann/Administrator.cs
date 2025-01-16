using SimaCheveresann;

public class Administrator : User
{
    public Administrator(string codUnic, string nume, string prenume, string email, string parola)
        : base(codUnic, nume, prenume, email, parola) { }

    public void VizualizareCereri(List<CerereRezolvare> cereri)
    {
        Console.WriteLine("Cereri:");
        foreach (var cerere in cereri)
            Console.WriteLine(cerere);
    }

    public void VizualizareComenzi(List<ComandaPiese> comenzi)
    {
        Console.WriteLine("Comenzi:");
        foreach (var comanda in comenzi)
            Console.WriteLine(comanda);
    }

    public void AdaugaCerere(List<CerereRezolvare> cereri)
    {
        Console.Write("Nume client: ");
        string numeClient = Console.ReadLine();
        Console.Write("Număr mașină: ");
        string numarMasina = Console.ReadLine();
        Console.Write("Descriere problemă: ");
        string descriereProblema = Console.ReadLine();

        cereri.Add(new CerereRezolvare(Guid.NewGuid().ToString(), numeClient, numarMasina, descriereProblema));
        Console.WriteLine("Cerere adăugată cu succes.");
    }

    public void FinalizeazaComanda(List<ComandaPiese> comenzi)
    {
        Console.Write("Cod comandă de finalizat: ");
        string codComanda = Console.ReadLine();
        var comanda = comenzi.FirstOrDefault(c => c.CodUnic == codComanda);

        if (comanda != null && comanda.Status == StatusComanda.InAsteptare)
        {
            comanda.Status = StatusComanda.Finalizat;
            Console.WriteLine("Comandă finalizată.");
        }
        else
            Console.WriteLine("Comandă invalidă.");
    }
}