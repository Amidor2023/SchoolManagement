namespace Gestion_Emploi.Models
{
    public class Course : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public Section Section { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
    }
}
