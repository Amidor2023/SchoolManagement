namespace Gestion_Emploi.Models
{
    public class Student : User
    {
        public string Picture { get; set; }
        public Classmate Classmate { get; set; }
    }
}
