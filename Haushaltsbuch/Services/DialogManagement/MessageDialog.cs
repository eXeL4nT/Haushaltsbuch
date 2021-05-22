using Haushaltsbuch.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Technewlogic.WpfDialogManagement.Contracts;

namespace Technewlogic.WpfDialogManagement
{
	internal class MessageDialog : DialogBase, IMessageDialog
	{
		public MessageDialog(OverviewViewModel overviewViewModel, DialogMode dialogMode, string message,	Dispatcher dispatcher)
			: base(overviewViewModel, dialogMode, dispatcher)
		{
			InvokeUICall(() =>
				{
					_messageTextBlock = new TextBlock
					{
						Text = message,
						HorizontalAlignment = HorizontalAlignment.Center,
						VerticalAlignment = VerticalAlignment.Center,
						TextWrapping = TextWrapping.Wrap,
					};
					SetContent(_messageTextBlock);
				});
		}

		private TextBlock _messageTextBlock;

		#region Implementation of IMessageDialog

		public string Message
		{
			get
			{
				var text = string.Empty;
				InvokeUICall(
					() => text = _messageTextBlock.Text);
				return text;
			}
			set
			{
				InvokeUICall(
					() => _messageTextBlock.Text = value);
			}
		}

		#endregion
	}
}