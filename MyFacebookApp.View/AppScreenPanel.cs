using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyFacebookApp.Model;
using System.Reflection;

namespace MyFacebookApp.View
{
	[TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<AppScreenPanel, UserControl>))]
	public abstract partial class AppScreenPanel : UserControl, ILogoutable, IBackable
	{
		protected readonly AppEngine r_AppEngine;
		protected readonly LogoutAttach r_LogoutAttacher;
		public AppScreenPanel(AppEngine i_AppEngine)
		{
			InitializeComponent();
			r_AppEngine = i_AppEngine;
			r_LogoutAttacher = new LogoutAttach();
		}

		protected virtual void fetchInitialDetails()
		{
			BindingFlags searchFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
			FieldInfo[] allFields = this.GetType().GetFields((searchFlags));

			foreach (FieldInfo currField in allFields)
			{
				if (currField.FieldType.IsSubclassOf(typeof(UserDetailsPanel))|| currField.FieldType.Equals((typeof(UserDetailsPanel))))
				{
					UserDetailsPanel panel = (UserDetailsPanel)currField.GetValue(this);
					panel.SetDataSource(r_AppEngine.LoggedUser);
				}
			}
		}

		public virtual void AddLogoutButton(Button i_LogoutButton)
		{
			r_LogoutAttacher.AddLogoutButton(i_LogoutButton, this, null);
		}

		public void AddBackToHomeButton(Button i_BackToHomeButton)
		{
			Controls.Add(i_BackToHomeButton);
		}
	}
}
