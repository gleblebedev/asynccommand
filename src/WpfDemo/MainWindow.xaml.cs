using System.Windows;

using WpfAsyncCommand;

namespace WpfDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		#region Constructors and Destructors

		public MainWindow()
		{
			this.InitializeComponent();
		}

		#endregion

		#region Methods

		private void OnRun(object sender, RoutedEventArgs e)
		{
			var c = this.Resources["command"] as IAsyncCommand;
		}

		#endregion
	}
}