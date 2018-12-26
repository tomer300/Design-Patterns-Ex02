using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using MyFacebookApp.Model;

namespace MyFacebookApp.View
{
	[TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<AppScreenPanel, UserControl>))]
	public abstract partial class AppScreenPanel : UserControl, IAddable
	{
		protected readonly AppEngine	r_AppEngine;
		protected readonly ButtonAttach r_ButtonAttacher;

		internal AppScreenPanel(AppEngine i_AppEngine)
		{
			InitializeComponent();
			r_AppEngine = i_AppEngine;
			r_ButtonAttacher = new ButtonAttach();
		}

		protected virtual void fetchInitialDetails()
		{
			BindingFlags	searchFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
			FieldInfo[]		allFields = this.GetType().GetFields(searchFlags);

			foreach (FieldInfo currField in allFields)
			{
				if (currField.FieldType.IsSubclassOf(typeof(UserDetailsPanel)) || currField.FieldType.Equals(typeof(UserDetailsPanel)))
				{
					UserDetailsPanel panel = (UserDetailsPanel)currField.GetValue(this);
					panel.SetDataSource(r_AppEngine.LoggedUser);
				}
			}
		}

		public virtual void AddButtons(ICollection<ButtonBase> i_Buttons)
		{
			foreach (ButtonBase buttonToAdd in i_Buttons)
			{
				r_ButtonAttacher.AddButton(buttonToAdd, this, null);
			}
		}
	}
}
