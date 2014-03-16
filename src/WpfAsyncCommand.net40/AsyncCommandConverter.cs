using System;
using System.Globalization;
using System.Windows.Input;
#if NETFX_CORE
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;

#endif

namespace WpfAsyncCommand
{
#if NETFX_CORE
#else
	[ValueConversion(typeof(ICommand), typeof(IAsyncCommand))]
#endif
	public class AsyncCommandConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var c = value as ICommand;
			if (c == null)
			{
				return null;
			}
			return new AsyncCommandAdapter(c);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var asyncCommandAdapter = value as AsyncCommandAdapter;
			if (asyncCommandAdapter == null)
			{
				return null;
			}
			return asyncCommandAdapter.Command;
		}
	}
}