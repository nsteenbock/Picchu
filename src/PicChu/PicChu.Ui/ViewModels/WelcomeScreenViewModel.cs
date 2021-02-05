using Caliburn.Micro;
using Doozr.Common.Application.Desktop.Wpf.Dialogs;
using PicChu.Ui.ViewModels.Collection;
using System;
using System.Collections.Generic;

namespace PicChu.Ui.ViewModels
{
	public class WelcomeScreenViewModel: Screen
	{
		private readonly IDialogManager dialogManager;
		private readonly Func<CreateCollectionViewModel> createCollectionViewModelFactory;

		public WelcomeScreenViewModel(IDialogManager dialogManager, Func<CreateCollectionViewModel> createCollectionViewModelFactory)
		{
			this.dialogManager = dialogManager;
			this.createCollectionViewModelFactory = createCollectionViewModelFactory;
		}

		public async void CreateCollection()
		{
			await dialogManager.ShowDialogAsync(createCollectionViewModelFactory(),
				null,
				new Dictionary<string, object> { { "Title", "Create new Collection" } });
		}
	}
}
