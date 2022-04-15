using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Facade.Party {
    public abstract class IsoNamedView : NamedView {
        [DisplayName("English Name")] public new string? Name { get; set; }
        [DisplayName("Native Name")] public new string? Description { get; set; }
        [Required][DisplayName("Code")] public new string? Code { get; set; }
    }

}
