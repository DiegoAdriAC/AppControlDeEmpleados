using System.ComponentModel.DataAnnotations;

namespace AppControlDeEmpleados.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string NameRole { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
