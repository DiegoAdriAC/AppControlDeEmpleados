using System.ComponentModel.DataAnnotations;

namespace AppControlDeEmpleados.Models
{
    public class Position
    {
        [Key]
        public int IdPosition { get; set; }
        public string NamePosition { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
