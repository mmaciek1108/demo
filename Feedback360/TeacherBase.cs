
namespace feedback360
{
    public abstract class TeacherBase : ITeacher
    {
        public delegate void GradeAddedDeledate(object sender, EventArgs args);
        public abstract event GradeAddedDeledate GradeAdded;

        public string Name { get; private set; }
        public string Surname { get; private set; }

        public TeacherBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public abstract void AddGrade(float grade);

        public void AddGrade(char grade)
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


        public void AddGrade(string grade)
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

        public void AddGrade(double grade)
        {
            float gradeFloat = (float)grade;
            AddGrade(gradeFloat);
        }

        public abstract Statistics GetStatistics();
    }

}