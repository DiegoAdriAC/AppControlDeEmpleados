using System.ComponentModel.DataAnnotations;

namespace AppControlDeEmpleados.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    }
}
