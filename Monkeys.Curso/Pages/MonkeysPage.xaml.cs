using Monkeys.Curso.Core.ViewModel;

namespace Monkeys.Curso.Pages;

public partial class MonkeysPage : ContentPage
{
	public MonkeysPage( MonkeysViewModel monkeysViewModel)
	{
		InitializeComponent();
        BindingContext = monkeysViewModel;
    }
}