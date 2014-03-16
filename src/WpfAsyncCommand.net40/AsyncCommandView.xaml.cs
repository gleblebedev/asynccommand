using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAsyncCommand
{
	public partial class AsyncCommandView : UserControl
	{
		#region Constants and Fields

		public static readonly DependencyProperty AsyncCommandProperty = DependencyProperty.Register(
			"AsyncCommand",
			typeof(IAsyncCommand),
			typeof(AsyncCommandView),
			new PropertyMetadata(default(IAsyncCommand)));

		public static readonly DependencyProperty CommandArgumentProperty = DependencyProperty.Register(
			"CommandArgument",
			typeof(object),
			typeof(AsyncCommandView),
			new PropertyMetadata(default(object)));

		#endregion

		#region Constructors and Destructors

		public AsyncCommandView()
		{
			this.InitializeComponent();
		}

		#endregion

		#region Public Properties

		public IAsyncCommand AsyncCommand
		{
			get
			{
				return (IAsyncCommand)this.GetValue(AsyncCommandProperty);
			}
			set
			{
				this.SetValue(AsyncCommandProperty, value);
			}
		}

		public object CommandArgument
		{
			get
			{
				return (object)this.GetValue(CommandArgumentProperty);
			}
			set
			{
				this.SetValue(CommandArgumentProperty, value);
			}
		}

		#endregion

		#region Methods

		private void OnCloseClick(object sender, RoutedEventArgs e)
		{
		}

		private void OnCommandComplete(IAsyncResult ar)
		{
			var c = ar.AsyncState as IAsyncCommand;
			c.EndInvoke(ar);
		}

		private void OnRetryClick(object sender, RoutedEventArgs e)
		{
			var asyncCommand = this.AsyncCommand;
			if (asyncCommand == null)
			{
				return;
			}
			asyncCommand.BeginInvoke(this.CommandArgument, this.OnCommandComplete, asyncCommand);
		}

		#endregion
	}
}