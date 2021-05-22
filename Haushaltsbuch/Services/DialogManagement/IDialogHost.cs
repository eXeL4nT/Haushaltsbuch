using System.Windows;

namespace Technewlogic.WpfDialogManagement
{
	internal interface IDialogHost
	{
		void ShowDialog(DialogBaseControl dialog);
		void HideDialog(DialogBaseControl dialog);
		FrameworkElement GetCurrentContent();
	}
}