namespace SimaCheveresann;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<User> utilizatori = new List<User>();
    static List<CerereRezolvare> cereri = new List<CerereRezolvare>();
    static List<ComandaPiese> comenzi = new List<ComandaPiese>();

    static void Main(string[] args)
    {
        IncarcaDate();

        while (true)
        {
            Console.WriteLine("\n1. Logare");
            Console.WriteLine("2. Adaugare utilizatori (Admin sau Mecanic)");
            Console.WriteLine("0. Iesire");
            Console.Write("Alege o optiune: ");

            string optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    Logare();
                    break;

                case "2":
                    AdaugaUtilizator();
                    break;

                case "0":
                    SalveazaDate();
                    Console.WriteLine("La revedere!");
                    return;

                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }
    }
     static void Logare()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Parola: ");
            string parola = Console.ReadLine();

            var user = utilizatori.FirstOrDefault(u => u.Email == email && u.VerificaParola(parola));

            if (user == null)
            {
                Console.WriteLine("Autentificare esuata.");
                return;
            }

            if (user is Administrator admin)
                MeniuAdministrator(admin);
            else if (user is Mecanic mecanic)
                MeniuMecanic(mecanic);
        }

        static void AdaugaUtilizator()
        {
            Console.WriteLine("Tip utilizator (1. Administrator, 2. Mecanic): ");
            string tip = Console.ReadLine();

            Console.Write("Cod Unic: ");
            string codUnic = Console.ReadLine();
            Console.Write("Nume: ");
            string nume = Console.ReadLine();
            Console.Write("Prenume: ");
            string prenume = Console.ReadLine();
            Console.Write("Email: ");2
            string email = Console.ReadLine();
            Console.Write("Parola: ");
            string parola = Console.ReadLine();

            if (tip == "1")
                utilizatori.Add(new Administrator(codUnic, nume, prenume, email, parola));
            else if (tip == "2")
                utilizatori.Add(new Mecanic(codUnic, nume, prenume, email, parola));

            Console.WriteLine("Utilizator adăugat cu succes.");
        }

        static void MeniuAdministrator(Administrator admin)
        {
            while (true)
            {
                Console.WriteLine("\n1. Vizualizare cereri");
                Console.WriteLine("2. Vizualizare comenzi");
                Console.WriteLine("3. Adaugare cerere de rezolvare");
                Console.WriteLine("4. Finalizare comanda piese");
                Console.WriteLine("0. Logout");
                Console.Write("Alege o optiune: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        admin.VizualizareCereri(cereri);
                        break;

                    case "2":
                        admin.VizualizareComenzi(comenzi);
                        break;

                    case "3":
                        admin.AdaugaCerere(cereri);
                        break;

                    case "4":
                        admin.FinalizeazaComanda(comenzi);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }

        static void MeniuMecanic(Mecanic mecanic)
        {
            while (true)
            {
                Console.WriteLine("\n1. Preluare cerere");
                Console.WriteLine("2. Investigare problema");
                Console.WriteLine("3. Cerere piese");
                Console.WriteLine("4. Rezolvare problema");
                Console.WriteLine("0. Logout");
                Console.Write("Alege o optiune: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        mecanic.PreiaCerere(cereri);
                        break;

                    case "2":
                        mecanic.InvestigheazaProblema();
                        break;

                    case "3":
                        mecanic.CerePiese(comenzi);
                        break;

                    case "4":
                        mecanic.RezolvaProblema(cereri, comenzi);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }

        static void SalveazaDate()
        {
            try
            {
                File.WriteAllText("utilizatori.json", System.Text.Json.JsonSerializer.Serialize(utilizatori));
                File.WriteAllText("cereri.json", System.Text.Json.JsonSerializer.Serialize(cereri));
                File.WriteAllText("comenzi.json", System.Text.Json.JsonSerializer.Serialize(comenzi));
                Console.WriteLine("Date salvate cu succes.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la salvarea datelor: " + ex.Message);
            }
        }

        static void IncarcaDate()
        {
            try
            {
                if (File.Exists("utilizatori.json"))
                    utilizatori = System.Text.Json.JsonSerializer.Deserialize<List<User>>(File.ReadAllText("utilizatori.json"));

                if (File.Exists("cereri.json"))
                    cereri = System.Text.Json.JsonSerializer.Deserialize<List<CerereRezolvare>>(File.ReadAllText("cereri.json"));

                if (File.Exists("comenzi.json"))
                    comenzi = System.Text.Json.JsonSerializer.Deserialize<List<ComandaPiese>>(File.ReadAllText("comenzi.json"));

                Console.WriteLine("Date încărcate cu succes.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la încărcarea datelor: " + ex.Message);
            }
        }
    }