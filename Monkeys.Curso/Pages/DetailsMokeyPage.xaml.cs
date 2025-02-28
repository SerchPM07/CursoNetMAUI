using Monkeys.Curso.Core.ViewModel;

namespace Monkeys.Curso.Pages;

public partial class DetailsMokeyPage : ContentPage
{

    // este ya se encuentra registrado 
    public DetailsMokeyPage(DetailsMokeyViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}