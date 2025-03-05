using Monkeys.Curso.Core.ViewModel;

namespace Monkeys.Curso.Pages;

public partial class DetailsMokeyPage : ContentPage
{
	public DetailsMokeyPage(DetailsMokeyViewModel detailsMokeyViewModel)
	{
		InitializeComponent();
		BindingContext = detailsMokeyViewModel;
    }
}