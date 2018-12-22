using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyFacebookApp.View
{
	public class LogoutAttach
	{
		public void AddLogoutButton(Button i_LogoutButton, ILogoutable i_LogoutAttachTo, Panel i_OptionalPanelToAttachTo)
		{
			AppScreenPanel	appScreen = i_LogoutAttachTo as AppScreenPanel;
			Control			controlToAttachTo;

			if (appScreen != null)
			{
				if(i_OptionalPanelToAttachTo != null)
				{
					controlToAttachTo = i_OptionalPanelToAttachTo;
				}
				else
				{
					controlToAttachTo = appScreen;
				}

				controlToAttachTo.Controls.Add(i_LogoutButton);
			}
		}
	}
}
