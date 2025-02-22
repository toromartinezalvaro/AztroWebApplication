//create a model class User.cs and add the following code to it

using System.ComponentModel.DataAnnotations; // se usa para definir el tipo de datos de las propiedades de la clase como por ejemplo [Required] para definir que un campo es obligatorio, [EmailAddress] para definir que un campo es un email, etc.

namespace AztroWebApplication.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int age { get; set; }

        public User ()
        {
        }
    }
}