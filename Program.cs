using System;
using System.Collections.Generic;
using System.IO;

namespace PROJEKT
{
    public class Patient
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string pesel { get; set; }

        public string getpatient
        {
            get
            {
                return name + " " + surname;
            }
            set
            {
                name = value;
                surname = value;
            }
        }

        public override string ToString()
        {
            return "Imie: " + name + "\nNazwisko: " + surname + "\nPESEL: " + pesel + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Patient objAsPatient = obj as Patient;
            if (objAsPatient == null) return false;
            else return Equals(objAsPatient);
        }
    }

    public class Doctor
    {
        public int docID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string spec { get; set; }

        public override string ToString()
        {
            return "ID: " + docID + "\nImie: " + name + "\nNazwisko: " + surname + "\nSpecjalizacja: " + spec + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Doctor objAsPatient = obj as Doctor;
            if (objAsPatient == null) return false;
            else return Equals(objAsPatient);
        }
    }

    public class Visit
    {
        public string pesel { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string doc { get; set; }

        public override string ToString()
        {
            return "PESEL: " + pesel + "\nLekarz: " + doc + "\nData: " + date + " godz. " + time;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Visit objAsPatient = obj as Visit;
            if (objAsPatient == null) return false;
            else return Equals(objAsPatient);
        }
    }
    public class Program
    {
        static int menu;

        public static List<Doctor> doctors = new List<Doctor>();
        public static List<Patient> patients = new List<Patient>();
        public static List<Visit> visits = new List<Visit>();

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Witaj w systemie obslugi przychodni. Wybierz jedna z ponizszych opcji:\n");
            Console.WriteLine("1. Dodawanie pacjentow");
            Console.WriteLine("2. Lista pacjentow");
            Console.WriteLine("3. Dodawanie wizyt do pacjenta");
            Console.WriteLine("4. Wyszukiwanie pacjentow");
            Console.WriteLine("5. Lista wizyt");
            Console.WriteLine("6. Dodawanie lekarzy");
            Console.WriteLine("7. Lista lekarzy");
            Console.WriteLine("8. Wyjscie z programu\n");
            menu = Convert.ToInt32(Console.ReadLine());

            if(menu > 0 && menu < 9)
            {
                switch (menu)
                {
                    case 1:
                        PatientList();
                        break;

                    case 2:
                        PatientList();
                        break;

                    case 3:
                        AddVisit();
                        break;

                    case 4:
                        SearchPatient();
                        break;

                    case 5:
                        VisitList();
                        break;

                    case 6:
                        AddDoctor();
                        break;

                    case 7:
                        DoctorList();
                        break;

                    case 8:
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wybrano nieprawidlowa wartosc!");
                Console.ReadKey();
                ShowMenu();
            }
            
        }

        static void PatientList() 
        {
            Console.Clear();

            if (menu == 2) { PLView(); }
            if (menu == 1) { PLAdd(); }

            void PLView()
            {
                foreach (Patient patient in patients)
                {
                    Console.WriteLine(patient);
                }

                Console.WriteLine("9. Powrot");
                Console.WriteLine("0. Wyjdz z aplikacji\n");

                menu = Convert.ToInt32(Console.ReadLine());

                if (menu == 9 || menu == 0)
                {
                    switch (menu)
                    {
                        case 9:
                            ShowMenu();
                            break;

                        case 0:
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wprowadzono nieprawidlowa wartosc!");
                    Console.ReadKey();
                    PatientList();
                }
            }

            void PLAdd()
            {
                string pname, psurname, ppesel;

                Console.Clear();

                Console.WriteLine("Podaj imie pacjenta: ");
                pname = Console.ReadLine();

                Console.WriteLine("Podaj nazwisko pacjenta: ");
                psurname = Console.ReadLine();

                Console.WriteLine("Podaj PESEL pacjenta: ");
                ppesel = Console.ReadLine();

                // sprawdz czy pesel jest prawidlowy

                patients.Add(new Patient() { name = pname, surname = psurname, pesel = ppesel });

                Console.WriteLine("\nPacjent " + pname + " " + psurname + " o numerze PESEL " + ppesel + " zostal dodany.");
                Console.ReadKey();
                ShowMenu();
            }

            
        }
        static void AddVisit() 
        {
            string vdate, vtime, vpesel, vdoc;

            Console.Clear();

            Console.WriteLine("Podaj PESEL pacjenta: ");
            vpesel = Console.ReadLine();

            Patient presult = patients.Find(x => x.pesel == vpesel);

            Console.WriteLine("\nDodajesz wizyte dla pacjenta:\n");

            Console.WriteLine(presult + "\n");

            Console.WriteLine("Podaj date (DD.MM.YYYY): ");
            vdate = Console.ReadLine();

            Console.WriteLine("Podaj godzine (HH:MM): ");
            vtime = Console.ReadLine();

            Console.WriteLine("Podaj ID lekarza: ");
            vdoc = Console.ReadLine();

            visits.Add(new Visit() { pesel = vpesel, date = vdate, time = vtime, doc = vdoc});

            Console.WriteLine("\nWizyta dla pacjenta o nr PESEL " + vpesel + " u lekarza nr " + vdoc + " zostala zapisana na " + vdate + " o godzinie " + vtime + ".");
            Console.ReadKey();
            ShowMenu();
        }
        static void SearchPatient() 
        {
            Console.Clear();

            Console.WriteLine("Podaj PESEL pacjenta, ktorego chcesz wyszukac: ");
            string ppesel = Console.ReadLine();

            Patient presult = patients.Find(x => x.pesel == ppesel);
            Visit vresult = visits.Find(x => x.pesel == ppesel);

            Console.WriteLine(presult + "\n");
            Console.WriteLine(vresult);

            Console.WriteLine("\n9. Powrot");
            Console.WriteLine("0. Wyjdz z aplikacji\n");

            menu = Convert.ToInt32(Console.ReadLine());

            if (menu == 9 || menu == 0)
            {
                switch (menu)
                {
                    case 9:
                        ShowMenu();
                        break;

                    case 0:
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wprowadzono nieprawidlowa wartosc!");
                Console.ReadKey();
                SearchPatient();
            }
        }
        static void VisitList() 
        {
            Console.Clear();

            foreach (Visit visit in visits)
            {
                Console.WriteLine(visit + "\n");
            }

            Console.WriteLine("\n9. Powrot");
            Console.WriteLine("0. Wyjdz z aplikacji\n");

            menu = Convert.ToInt32(Console.ReadLine());

            if (menu == 9 || menu == 0)
            {
                switch (menu)
                {
                    case 9:
                        ShowMenu();
                        break;

                    case 0:
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wprowadzono nieprawidlowa wartosc!");
                Console.ReadKey();
                PatientList();
            }
        }
        static void AddDoctor() 
        {
            string dname, dsurname, dspec;

            Console.Clear();

            Console.WriteLine("Podaj imie lekarza: ");
            dname = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko lekarza: ");
            dsurname = Console.ReadLine();

            Console.WriteLine("Podaj specjalizacje lekarza: ");
            dspec = Console.ReadLine();

            doctors.Add(new Doctor() { name = dname, surname = dsurname, spec = dspec });

            Console.WriteLine("\nLekarz " + dspec + " dr " + dname + " " + dsurname + " zostal dodany.");
            Console.ReadKey();
            ShowMenu();
        }
        static void DoctorList() 
        {
            Console.Clear();

            foreach (Doctor doctor in doctors)
            {
                Console.WriteLine(doctor);
            }

            Console.WriteLine("9. Powrot");
            Console.WriteLine("0. Wyjdz z aplikacji\n");

            menu = Convert.ToInt32(Console.ReadLine());

            if (menu == 9 || menu == 0)
            {
                switch (menu)
                {
                    case 9:
                        ShowMenu();
                        break;

                    case 0:
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wprowadzono nieprawidlowa wartosc!");
                Console.ReadKey();
                PatientList();
            }
        }

        public static void Main(string[] args)
        {
            string password;

            getpass:

            Console.WriteLine("Podaj haslo dostepu: ");
            password = Console.ReadLine();

            if(password == "123")
            {
                Console.Clear();
                ShowMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bledne haslo!");
                Console.ReadKey();
                Console.Clear();
                goto getpass;
            }
        }
    }
}
