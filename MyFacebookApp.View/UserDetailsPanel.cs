using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyFacebookApp.Model;

namespace MyFacebookApp.View
{
	public partial class UserDetailsPanel : UserControl
	{
		public UserDetailsPanel()
		{
			InitializeComponent();
		}

		public void SetDataSource(AppUser i_User)
		{
			if (!this.InvokeRequired)
			{
				appUserBindingSource.DataSource = i_User;
			}
			else
			{
				this.Invoke(new Action(() => appUserBindingSource.DataSource = i_User));
			}
		}
	}
}
