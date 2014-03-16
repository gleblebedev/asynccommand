using System;

namespace WpfAsyncCommand
{
	public class AsyncCommand<T> : IAsyncCommand<T>
	{
		#region Constants and Fields

		private readonly Func<object, AsyncCallback, object, IAsyncResult> begin;

		private readonly Func<IAsyncResult, T> end;

		#endregion

		#region Constructors and Destructors

		public AsyncCommand()
		{
		}

		public AsyncCommand(Func<object, T> func)
		{
			this.begin = func.BeginInvoke;
			this.end = func.EndInvoke;
		}

		public AsyncCommand(Func<object, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, T> end)
		{
			this.begin = begin;
			this.end = end;
		}

		#endregion

		#region Public Methods and Operators

		public IAsyncResult BeginInvoke(object arg, AsyncCallback callback, object state)
		{
			return this.begin(arg, callback, state);
		}

		public T EndInvoke(IAsyncResult result)
		{
			return this.end.EndInvoke(result);
		}

		#endregion

		#region Explicit Interface Methods

		object IAsyncCommand.EndInvoke(IAsyncResult result)
		{
			return this.end.EndInvoke(result);
		}

		#endregion
	}
}