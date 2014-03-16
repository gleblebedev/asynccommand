using System;
using System.Windows.Input;

namespace WpfAsyncCommand
{
	internal class AsyncCommandAdapter : IAsyncCommand
	{
		#region Constants and Fields

		private Action<object> executingDelegate;

		#endregion

		#region Constructors and Destructors

		public AsyncCommandAdapter(ICommand command)
		{
			this.Command = command;
		}

		#endregion

		#region Public Properties

		public ICommand Command { get; private set; }

		#endregion

		#region Public Methods and Operators

		public IAsyncResult BeginInvoke(object arg, AsyncCallback callback, object state)
		{
			if (this.Command != null && this.Command.CanExecute(arg))
			{
				this.executingDelegate = this.Command.Execute;
			}
			else
			{
				this.executingDelegate = NoOperation;
			}
			return this.executingDelegate.BeginInvoke(arg, callback, state);
		}

		public object EndInvoke(IAsyncResult result)
		{
			this.executingDelegate.EndInvoke(result);
			this.executingDelegate = null;
			return null;
		}

		#endregion

		#region Methods

		private static void NoOperation(object arg)
		{
		}

		#endregion
	}
}