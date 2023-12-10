

namespace feedback360
{
    public class Teacher : TeacherBase
    {
        public override event GradeAddedDeledate GradeAdded;
        private string FullFileName;

        private const string fileName = ".txt"; //w sumie to chyba nie potrzebe 
        public Teacher(string name, string surname) : base(name, surname)
        {
            FullFileName = $"{name}.{surname}{fileName}";
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                using (var writer = File.AppendText(FullFileName))
                {
                    writer.WriteLine(grade);
                }
                if (GradeAdded is not null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception($"nieprawidłwe dane - liczba {grade} nie mieście się w przedziałe 1-6");
            }
        }


        public override void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                case 'a':
                    AddGrade(6);
                    break;
                case 'B':
                case 'b':
                    AddGrade(5);
                    break;
                case 'C':
                case 'c':
                    AddGrade(4);
                    break;
                case 'D':
                case 'd':
                    AddGrade(3);
                    break;
                case 'E':
                case 'e':
                    AddGrade(2);
                    break;
                default:
                    throw new Exception("nie właściwe wprowadzony znak");
            }
        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                AddGrade(result);
            }
            else if (char.TryParse(grade, out char resultChar))
            {
                AddGrade(resultChar);
            }
            else
            {
                throw new Exception($"Wpisany znak: {grade} - nie da się przekonwertować na liczbę");
            }
        }

        public override void AddGrade(double grade)
        {
            float gradeFloat = (float)grade;
            AddGrade(gradeFloat);
        }
        public override Statistics GetStatistics()
        {
            var gradesListFromFile = this.ReadFromFile();
            var result = this.CountStat(gradesListFromFile);
            return result;
        }
        private List<float> ReadFromFile()
        {
            var grades = new List<float>();

            if (File.Exists(FullFileName))
            {
                using (var reader = File.OpenText(FullFileName))
                {
                    var line = reader.ReadLine();
                    while (line is not null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }
        private Statistics CountStat(List<float> grades)
        {
            var statistics = new Statistics();
            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}