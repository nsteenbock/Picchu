using Autofac;
using Doozr.Common.Application;
using Doozr.Common.Application.Desktop.Wpf;
using Doozr.Common.Application.Desktop.Wpf.Autofac;
using Doozr.Common.Application.Desktop.Wpf.CaliburnMicro;
using Doozr.Common.I18n;
using Doozr.Common.I18n.Autofac;
using Doozr.Common.I18n.Wpf;
using Doozr.Common.Ipc.Autofac;
using Doozr.Common.Logging;
using Doozr.Common.Logging.Autofac;
using Doozr.Common.Translation.TranslatableApplication;
using Doozr.Common.Translation.TranslatableApplication.Autofac;
using PicChu.Autofac;
using System.Globalization;
using System.Windows;

namespace PicChu
{
	public class Bootstrapper : AutofacBootstrapper
	{
		protected override void PrepareRegistration()
		{
			RegisterUiAssemblyContaining<PicChu.Ui.ViewModels.ShellViewModel>();
		}

		protected override void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterType<NullLogManager>().As<ILogManager>();

			// Common modules
			builder.RegisterModule<LoggingModule>();
			builder.RegisterModule<ApplicationModule>();
			builder.RegisterModule<ApplicationDesktopWpfModule>();
			builder.RegisterModule<IpcModule>();
			builder.RegisterModule<I18nModule>();
			builder.RegisterModule<TranslatableApplicationModule>();

			// Application specific modules
			builder.RegisterModule<PicChuApplicationModule>();
		}

		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			var translationSource = container.Resolve<ITranslationSource>();
			TranslateExtension.TranslationSource = translationSource;
			translationSource.CurrentCulture = CultureInfo.CurrentCulture;

			ITranslationServer translationServer = container.Resolve<ITranslationServer>();
			translationServer.Start();

			this.DisplayRootViewFor<Ui.ViewModels.ShellViewModel>();
			var windowPlacementPersistor = container.Resolve<IWindowPlacementPersistor>();
			windowPlacementPersistor.Register(Application.Current.MainWindow);
		}
	}
}
