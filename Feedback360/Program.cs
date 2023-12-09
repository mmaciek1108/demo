
using feedback360;

bool status = true;

Console.WriteLine("Witaj w alpikacji Feedbacku 360 Stopni!");
Console.WriteLine("------------------------------------------------");


while (status)
{
    Console.WriteLine("Wybierz odpowiedni numer i naciśnij Enter:");
    Console.WriteLine("1 - lista wprowadzonych ocen");
    Console.WriteLine("2 - wprowdz ocenę nowego wykładowc");
    Console.WriteLine("q - koniec");
    Console.WriteLine("Twój wybór: ");
    string userChoise = Console.ReadLine();
    switch (userChoise)
    {
        case "1":
            AddGradesToTxtFile();
            break;
        case "2":
            status = AddGradesToNewFile();
            break;
        case "q":
            Console.WriteLine("Do zobaczenia!");
            status = false;
            break;
        default:
            Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
            break;
    }
}

static void AddGradesToTxtFile()
{
    string folderPath = Directory.GetCurrentDirectory(); // Pobiera ścieżkę bieżącego folderu
    List<string> fileTxtNames = new List<string>(); // Lista do przechowywania nazw polików txt

    string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");
    var i = 1;
    foreach (string fileTxt in txtFiles)
    {
        fileTxtNames.Add(Path.GetFileName(fileTxt));
    }
    if (fileTxtNames.Count > 0)
    {
        Console.WriteLine("Znalezione pliki:");
        foreach (string nameFileTxt in fileTxtNames)
        {
            Console.Write(i++);
            Console.WriteLine($" {nameFileTxt}");
        }
        Console.WriteLine("Wybierz do którego Wykałdowcy dopisać ocenę: ");
        string userChoiseTeacher = Console.ReadLine();
        int userChoiseInt;
        if (!int.TryParse(userChoiseTeacher, out userChoiseInt) || userChoiseInt < 0 || userChoiseInt > fileTxtNames.Count)// to trzeba moze zrobić odwrotnie! 
        {
            Console.Write("Nipoporawny wybór");
            return;
        }
        else
        {
            Console.Write($"Twój wybór: {userChoiseInt} {fileTxtNames[userChoiseInt - 1]}");
        }


        string[] arrUser = fileTxtNames[userChoiseInt - 1].Split('.');

        var teacher = new Teacher(arrUser[0], arrUser[1]);

        while (true)
        {
            Console.WriteLine("Podaj ocenę pracownika: ");
            var input = Console.ReadLine();
            if (input == "q")
            {
                break;
            }
            try
            {
                teacher.AddGrade(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"cos poszło nie tak: {e.Message}");
            }
        }

        var statistics = teacher.GetStatistics();
        Console.WriteLine($"Ilośc ocen: {statistics.Count}");
        Console.WriteLine($"Averange: {statistics.Average:N2}");
        Console.WriteLine($"Min: {statistics.Min}");
        Console.WriteLine($"Max: {statistics.Max}");
        Console.WriteLine($"AverangeLetter: {statistics.AverageLetter}");
    }

    else
    {
        Console.WriteLine("Nie znaleziona ocenionej osoby ");
        AddGradesToNewFile();
    }
}

static bool AddGradesToNewFile()
{
    Console.WriteLine("Dodawanie nowej oceny");
    Console.WriteLine("--------------------------");
    Console.WriteLine("Podaj imię");
    string name = Console.ReadLine();

    Console.WriteLine("Podaj nazwisko");
    string surname = Console.ReadLine();

    var teacher = new Teacher(name, surname);

    while (true)
    {
        Console.WriteLine("Podaj ocenę pracownika: ");
        var input = Console.ReadLine();
        if (input == "q")
        {
            break;
        }
        try
        {
            teacher.AddGrade(input);
        }
        catch (Exception e)
        {
            Console.WriteLine($"cos poszło nie tak: {e.Message}");
        }
    }

    var statistics = teacher.GetStatistics();
    Console.WriteLine($"Ilośc ocen: {statistics.Count}");
    Console.WriteLine($"Averange: {statistics.Average:N2}");
    Console.WriteLine($"Min: {statistics.Min}");
    Console.WriteLine($"Max: {statistics.Max}");
    Console.WriteLine($"AverangeLetter: {statistics.AverageLetter}");
    return false;
}