using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyFacebookApp.View
{
	public partial class UserDetailsPanel : UserControl
	{
		public UserDetailsPanel()
		{
			InitializeComponent();
		}

		public void SetProfilePicture(string i_ProfilePicURL)
		{
			PictureBoxUserProfile.LoadAsync(i_ProfilePicURL);
		}

		public void SetFirstName(string i_FirstName)
		{
			labelFirstNameInfo.Text = i_FirstName;
			labelFirstName.AutoSize = true;
		}

		public void SetLastName(string i_LastName)
		{
			labelLastNameInfo.Text = i_LastName;
			labelLastNameInfo.AutoSize = true;
		}

		public void SetCity(string i_CityName)
		{
			labelCityInfo.Text = i_CityName;
			labelCityInfo.AutoSize = true;
		}

		public void SetBirthday(string i_BirthdayDate)
		{
			labelBirthdayInfo.Text = i_BirthdayDate;
			labelBirthdayInfo.AutoSize = true;
		}

		public void SetAllUserDetails(string i_ProfilePictureURL, string i_FirstName, string i_LastName, string i_City, string i_Birthday)
		{
			SetProfilePicture(i_ProfilePictureURL);
			SetFirstName(i_FirstName);
			SetLastName(i_LastName);
			SetCity(i_City);
			SetBirthday(i_Birthday);
		}
	}
}
