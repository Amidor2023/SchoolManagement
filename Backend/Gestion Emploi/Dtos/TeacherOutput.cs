namespace Gestion_Emploi.Dtos
{
    public class TeacherOutput
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Reference { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }
    }
}
