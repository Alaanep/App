using System.ComponentModel.DataAnnotations;

namespace App.Facade;

public class BaseView {
    [Required] public string Id { get; set; }
        
}