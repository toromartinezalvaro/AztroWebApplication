//create a model class User.cs and add the following code to it

using System.ComponentModel.DataAnnotations; // se usa para definir el tipo de datos de las propiedades de la clase como por ejemplo [Required] para definir que un campo es obligatorio, [EmailAddress] para definir que un campo es un email, etc.

namespace AztroWebApplication.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }

        public User ()
        {
        }
    }
}