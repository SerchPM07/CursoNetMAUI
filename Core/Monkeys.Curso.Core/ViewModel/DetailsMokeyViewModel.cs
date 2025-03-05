using CommunityToolkit.Mvvm.ComponentModel;

namespace Monkeys.Curso.Core.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial  class DetailsMokeyViewModel : ObservableObject
{
    [ObservableProperty]
    public Monkey monkey;

    public DetailsMokeyViewModel()
    {

    }
}
