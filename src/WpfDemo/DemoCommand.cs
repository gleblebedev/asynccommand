using WpfAsyncCommand;

namespace WpfDemo
{
	public class DemoCommand : AsyncCommand<string>
	{
		#region Constructors and Destructors

		public DemoCommand()
			: base()
		{
		}

		#endregion
	}
}