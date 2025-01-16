namespace SimaCheveresann;

public class ComandaPiese
{
    public string CodUnic { get; set; }
    public string Detalii { get; set; }
    public StatusComanda Status { get; set; }

    public ComandaPiese(string codUnic, string detalii)
    {
        CodUnic = codUnic;
        Detalii = detalii;
        Status = StatusComanda.InAsteptare;
    }

    public override string ToString()
    {
        return $"{CodUnic} | {Detalii} | {Status}";
    }
}

public enum StatusCerere
{
    InPreluare,
    Investigare,
    AsteptarePiese,
    Finalizat
}

public enum StatusComanda
{
    InAsteptare,
    Finalizat
}

