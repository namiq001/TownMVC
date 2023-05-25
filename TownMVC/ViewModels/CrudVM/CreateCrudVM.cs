using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TownMVC.ViewModels.CrudVM;

public class CreateCrudVM
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string IconUrl { get; set; } = null!;
}
