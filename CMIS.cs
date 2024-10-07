using System;

namespace Informationsstander
{
    class Program
    {
        // Array til at gemme brugere
        static string[,] users = new string[50, 8]; // Fornavn, Efternavn, Alder, Adresse, Postnummer, By, Email, Tlf, Nyhedsbrev frekvens
        static int userCount = 0;
        static string adminPassword = "admin123"; // Hardcoded admin password

        static void Main(string[] args)
        {
            // Opret 20 brugere på forhånd
            PrepopulateUsers();

            while (true)
            {
                Console.WriteLine("Velkommen til informationsstanderen.");
                Console.WriteLine("1. Opret bruger");
                Console.WriteLine("2. Admin login");
                Console.WriteLine("3. Afslut program");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        OpretBruger();
                        break;
                    case "2":
                        AdminMenu();
                        break;
                    case "3":
                        Console.WriteLine("Program afsluttes.");
                        return;
                    default:
                        Console.WriteLine("Ugyldigt valg. Prøv igen.");
                        break;
                }
            }
        }

        // Forudfyld med 20 brugere
        static void PrepopulateUsers()
        {
            for (int i = 0; i < 20; i++)
            {
                users[i, 0] = "Fornavn" + (i + 1);
                users[i, 1] = "Efternavn" + (i + 1);
                users[i, 2] = (20 + i).ToString();
                users[i, 3] = "Adresse" + (i + 1);
                users[i, 4] = "Post" + (i + 1);
                users[i, 5] = "By" + (i + 1);
                users[i, 6] = "email" + (i + 1) + "@example.com";
                users[i, 7] = "1234567" + (i + 1);
                userCount++;
            }
        }

        // Funktion til at oprette bruger
        static void OpretBruger()
        {
            Console.Write("Indtast telefonnummer: ");
            string tlf = Console.ReadLine();

            // Tjek om telefonnummeret allerede findes
            for (int i = 0; i < userCount; i++)
            {
                if (users[i, 7] == tlf)
                {
                    Console.WriteLine("Telefonnummeret findes allerede.");
                    return;
                }
            }

            // Indtast brugerdetaljer
            Console.Write("Indtast fornavn: ");
            string fornavn = Console.ReadLine();

            Console.Write("Indtast efternavn: ");
            string efternavn = Console.ReadLine();

            Console.Write("Indtast alder: ");
            string alder = Console.ReadLine();

            Console.Write("Indtast adresse: ");
            string adresse = Console.ReadLine();

            Console.Write("Indtast postnummer: ");
            string postnummer = Console.ReadLine();

            Console.Write("Indtast by: ");
            string by = Console.ReadLine();

            Console.Write("Indtast email: ");
            string email = Console.ReadLine();

            Console.Write("Nyhedsbrev frekvens (12 for månedligt, 4 for kvartal, 1 for årligt): ");
            string frekvens = Console.ReadLine();

            // Gem data i array
            users[userCount, 0] = fornavn;
            users[userCount, 1] = efternavn;
            users[userCount, 2] = alder;
            users[userCount, 3] = adresse;
            users[userCount, 4] = postnummer;
            users[userCount, 5] = by;
            users[userCount, 6] = email;
            users[userCount, 7] = tlf;
            userCount++;

            Console.WriteLine("Bruger oprettet succesfuldt.");
        }

        // Admin menu
        static void AdminMenu()
        {
            Console.Write("Indtast admin password: ");
            string password = Console.ReadLine();

            if (password != adminPassword)
            {
                Console.WriteLine("Forkert password.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Admin menu:");
                Console.WriteLine("1. Find bruger");
                Console.WriteLine("2. Vis alle brugere");
                Console.WriteLine("3. Beregn gennemsnitsalder");
                Console.WriteLine("4. Log ud");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FindBruger();
                        break;
                    case "2":
                        VisAlleBrugere();
                        break;
                    case "3":
                        BeregnGennemsnitsalder();
                        break;
                    case "4":
                        Console.WriteLine("Logger ud.");
                        return;
                    default:
                        Console.WriteLine("Ugyldigt valg. Prøv igen.");
                        break;
                }
            }
        }

        // Funktion til at finde bruger
        static void FindBruger()
        {
            Console.Write("Indtast telefonnummer eller navn: ");
            string search = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < userCount; i++)
            {
                if (users[i, 7] == search || users[i, 0].ToLower() == search.ToLower())
                {
                    PrintUser(i);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Ingen brugere fundet med de angivne oplysninger.");
            }
        }

        // Funktion til at vise alle brugere
        static void VisAlleBrugere()
        {
            int count = 0;

            for (int i = 0; i < userCount; i++)
            {
                PrintUser(i);
                count++;

                if (count % 12 == 0)
                {
                    Console.WriteLine("Tryk Enter for at se næste side.");
                    Console.ReadLine();
                }
            }
        }

        // Beregn gennemsnitsalder
        static void BeregnGennemsnitsalder()
        {
            int totalAlder = 0;

            for (int i = 0; i < userCount; i++)
            {
                totalAlder += int.Parse(users[i, 2]);
            }

            double gennemsnit = (double)totalAlder / userCount;
            Console.WriteLine("Gennemsnitsalderen for brugerne er: " + gennemsnit);
        }

        // Udskriv brugerdata
        static void PrintUser(int index)
        {
            Console.WriteLine($"{users[index, 0]} {users[index, 1]}, Alder: {users[index, 2]}, Tlf: {users[index, 7]}");
        }
        console.readKey();
    }

    
}
