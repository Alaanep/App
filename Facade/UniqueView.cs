using System.ComponentModel.DataAnnotations;
namespace App.Facade;
public abstract class UniqueView
{
   [Required] public string Id { get; set; } = Guid.NewGuid().ToString();
}
