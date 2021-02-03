using Caliburn.Micro;
using System.Threading;
using System.Threading.Tasks;

namespace PicChu.Ui.ViewModels
{
	public class ShellViewModel : Conductor<Screen>
	{
		private readonly WelcomeScreenViewModel welcomeScreenViewModel;

		public ShellViewModel(WelcomeScreenViewModel welcomeScreenViewModel)
		{
			this.welcomeScreenViewModel = welcomeScreenViewModel;
		}

		protected async override Task OnActivateAsync(CancellationToken cancellationToken)
		{
			await ActivateItemAsync(welcomeScreenViewModel);
			await base.OnActivateAsync(cancellationToken);
		}
	}
}
