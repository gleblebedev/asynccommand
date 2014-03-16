using System.ComponentModel;

using WpfDemo.Annotations;

namespace WpfDemo
{
	public class ViewModel : INotifyPropertyChanged
	{
		#region Constants and Fields

		private string query;

		#endregion

		#region Public Events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Public Properties

		public string Query
		{
			get
			{
				return this.query;
			}
			set
			{
				if (this.query != value)
				{
					this.query = value;
					this.OnPropertyChanged("Query");
				}
			}
		}

		#endregion

		#region Methods

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged(string propertyName)
		{
			var handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion
	}
}