using System;

namespace WpfAsyncCommand
{
	public interface IAsyncCommand
	{
		#region Public Methods and Operators

		IAsyncResult BeginInvoke(object arg, AsyncCallback callback, object state);

		object EndInvoke(IAsyncResult result);

		#endregion
	}

	public interface IAsyncCommand<T> : IAsyncCommand
	{
		#region Public Methods and Operators

		T EndInvoke(IAsyncResult result);

		#endregion
	}
}