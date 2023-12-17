

namespace feedback360
{
    public class Teacher : TeacherBase
    {
        public override event GradeAddedDeledate GradeAdded;
        private string fullFileName;

        public Teacher(string name, string surname) : base(name, surname)
        {
            fullFileName = $"{name}.{surname}.txt";
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                using (var writer = File.AppendText(fullFileName))
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

        public override Statistics GetStatistics()
        {
            var gradesListFromFile = this.ReadFromFile();
            var result = this.CountStat(gradesListFromFile);
            return result;
        }
        private List<float> ReadFromFile()
        {
            var grades = new List<float>();

            if (File.Exists(fullFileName))
            {
                using (var reader = File.OpenText(fullFileName))
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