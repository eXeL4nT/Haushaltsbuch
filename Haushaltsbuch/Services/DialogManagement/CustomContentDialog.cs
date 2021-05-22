using Haushaltsbuch.ViewModels;
using System.Windows.Threading;
using Technewlogic.WpfDialogManagement.Contracts;

namespace Technewlogic.WpfDialogManagement
{
	internal class CustomContentDialog : DialogBase, ICustomContentDialog
	{
		public CustomContentDialog(OverviewViewModel overviewViewModel, DialogMode dialogMode, object content, Dispatcher dispatcher)
			: base(overviewViewModel, dialogMode, dispatcher)
		{
			SetContent(content);
		}
	}
}