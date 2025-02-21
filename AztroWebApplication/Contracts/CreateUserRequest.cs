//Esto es el DTO (Data Transfer Object) que se usa para definir la estructura de los datos que se van a enviar en una petición POST para crear un nuevo usuario. Se usa para definir la estructura de los datos que se van a enviar en una petición POST para crear un nuevo usuario.
using System.ComponentModel.DataAnnotations;

public class CreateUserRequest
{
    [MinLength(3)]
    public string? Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Range(1, 80)]
    public int Age { get; set; }
}