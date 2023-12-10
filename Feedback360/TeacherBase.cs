
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

        public abstract void AddGrade(char grade);

        public abstract void AddGrade(string grade);

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

}