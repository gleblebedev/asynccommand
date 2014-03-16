using System;

namespace WpfAsyncCommand
{
	public static class AsyncCommandFactory
	{
		#region Public Methods and Operators

		public static IAsyncCommand<T> Create<T>(Func<T> func)
		{
			return new AsyncCommand<T>((a) => func());
		}

		public static IAsyncCommand<T> Create<T>(Func<AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, T> end)
		{
			return new AsyncCommand<T>((arg, callback, state) => begin(callback, state), end);
		}

		public static IAsyncCommand<T> Create<TARG0, T>(Func<TARG0, T> func, Func<object, Tuple<TARG0>> argFactory)
		{
			return new AsyncCommand<T>((object arg) => { return func(argFactory(arg).Item1); });
		}

		public static IAsyncCommand<T> Create<TARG0, T>(
			Func<TARG0, AsyncCallback, object, IAsyncResult> begin,
			Func<IAsyncResult, T> end,
			Func<object, Tuple<TARG0>> argFactory)
		{
			return new AsyncCommand<T>((arg, callback, state) => begin(argFactory(arg).Item1, callback, state), end);
		}

		public static IAsyncCommand<T> Create<TARG0, TARG1, T>(
			Func<TARG0, TARG1, T> func,
			Func<object, Tuple<TARG0, TARG1>> argFactory)
		{
			return new AsyncCommand<T>(
				(object arg) =>
				{
					var actualArgs = argFactory(arg);
					return func(actualArgs.Item1, actualArgs.Item2);
				});
		}

		public static IAsyncCommand<T> Create<TARG0, TARG1, T>(
			Func<TARG0, TARG1, AsyncCallback, object, IAsyncResult> begin,
			Func<IAsyncResult, T> end,
			Func<object, Tuple<TARG0, TARG1>> argFactory)
		{
			return new AsyncCommand<T>(
				(arg, callback, state) =>
				{
					var actualArgs = argFactory(arg);
					return begin(actualArgs.Item1, actualArgs.Item2, callback, state);
				},
				end);
		}

		#endregion
	}
}