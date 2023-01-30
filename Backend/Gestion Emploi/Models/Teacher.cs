namespace Gestion_Emploi.Models
{
    public class Teacher : User
    {
        public int Experience { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
    }
}
