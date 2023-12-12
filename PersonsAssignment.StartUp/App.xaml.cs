using PersonsAssignment.Database;
using PersonsAssignment.Domain;
using PersonsAssignment.WPF;
using System;
using System.Windows;

namespace PersonsAssignment.StartUp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
				PeopleMapper mapper = new PeopleMapper();

				DomainManager manager = new DomainManager(mapper);

				PeopleApplication application = new(manager);
		}

		private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			MessageBox.Show("Something went terribly wrong", e.Exception.Message);
			Application.Current.Shutdown();
		}
	}
}
