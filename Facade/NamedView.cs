using System.ComponentModel;
namespace App.Facade;

public abstract class NamedView:UniqueView
{
    [DisplayName("Name")] public string? Name { get; set; }
    [DisplayName("Description")] public string? Description { get; set; }
    [DisplayName("Code")] public string? Code { get; set; }
}