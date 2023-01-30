namespace Gestion_Emploi.Models
{
    public class TeacherCourse : BaseModel
    {
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
