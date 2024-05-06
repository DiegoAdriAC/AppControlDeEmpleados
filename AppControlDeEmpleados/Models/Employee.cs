using System.ComponentModel.DataAnnotations;

namespace AppControlDeEmpleados.Models
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int IdPosition { get; set; }
        public Position Position { get; set; }
        public int IdRole { get; set; }
        public Role Role { get; set; }
    }
}
