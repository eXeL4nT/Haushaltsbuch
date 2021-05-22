using Haushaltsbuch.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Threading;
using Technewlogic.WpfDialogManagement.Contracts;

namespace Technewlogic.WpfDialogManagement
{
	public class DialogManager : IDialogManager
	{
		private OverviewViewModel _overviewViewModel;
		private bool _isInitialized;

		public bool IsInitialized => _isInitialized;

        public DialogManager(Dispatcher dispatcher)
		{
			_dispatcher = dispatcher;
		}

		public void Initialize(OverviewViewModel overviewViewModel)
        {
			_overviewViewModel = overviewViewModel;
			_isInitialized = true;
		}

		private readonly Dispatcher _dispatcher;

		#region Implementation of IDialogManager

		public IMessageDialog CreateMessageDialog(string message, DialogMode dialogMode)
		{
			IMessageDialog dialog = null;
			InvokeInUIThread(() =>
			{
				dialog = new MessageDialog(_overviewViewModel, dialogMode, message, _dispatcher);
			});
			return dialog;
		}

		public IMessageDialog CreateMessageDialog(string message, string caption, DialogMode dialogMode)
		{
			IMessageDialog dialog = null;
			InvokeInUIThread(() =>
			{
				dialog = new MessageDialog(_overviewViewModel, dialogMode, message, _dispatcher)
				{
					Caption = caption
				};
			});
			return dialog;
		}
		public ICustomContentDialog CreateCustomContentDialog(object content, DialogMode dialogMode)
		{
			ICustomContentDialog dialog = null;
			InvokeInUIThread(() =>
			{
				dialog = new CustomContentDialog(_overviewViewModel, dialogMode, content, _dispatcher);
			});
			return dialog;
		}

		public ICustomContentDialog CreateCustomContentDialog(object content, string caption, DialogMode dialogMode)
		{
			ICustomContentDialog dialog = null;
			InvokeInUIThread(() =>
			{
				dialog = new CustomContentDialog(_overviewViewModel, dialogMode, content, _dispatcher)
				{
					Caption = caption
				};
			});
			return dialog;
		}

		#endregion

		private void InvokeInUIThread(Action del)
		{
			_dispatcher.Invoke(del);
		}
	}
}