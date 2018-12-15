using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using MyFacebookApp.Model;

namespace MyFacebookApp.View
{
	public partial class MatchPanel : UserControl
	{
		private readonly AppEngine r_AppEngine;

		public MatchPanel(AppEngine i_AppEngine)
		{
			InitializeComponent();
			r_AppEngine = i_AppEngine;
		}

		public void AddBackToHomeButton(Button i_BackToHomeButton)
		{
			Controls.Add(i_BackToHomeButton);
		}

		public void AddLogoutButton(Button i_LogoutButton)
		{
			Controls.Add(i_LogoutButton);
		}

		private void findMeAMatchButton_Click(object sender, EventArgs e)
		{
			if (checkedGenderPreference())
			{
				FacebookObjectCollection<AppUser> potentialMatches;

				flowLayoutPanelMatchPictures.Controls.Clear();
				panelUserDetails.Visible = false;
				try
				{
					potentialMatches = r_AppEngine.FindAMatch(
						checkBoxGirls.Checked,
						checkBoxBoys.Checked,
						comboBoxAgeRanges.Items[comboBoxAgeRanges.SelectedIndex].ToString());
					if (potentialMatches != null && potentialMatches.Count > 0)
					{
						FriendsDisplayer displayer = new FriendsDisplayer(r_AppEngine.GetFriends(), flowLayoutPanelMatchPictures);
						displayer.FriendOnClickDelegate += match_Click;
						displayer.Display();

					}
					else
					{
						MessageBox.Show("No love for you today :(");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Please choose preferred gender.");
			}
		}


		private bool checkedGenderPreference()
		{
			bool choseGender = false;

			if (checkBoxBoys.Checked || checkBoxGirls.Checked)
			{
				choseGender = true;
			}

			return choseGender;
		}

		private void match_Click(object i_PotentialMatch)
		{
			AppUser							potentinalMatch = i_PotentialMatch as AppUser;
			AlbumsManager					matchAlbumsManager;
			FacebookObjectCollection<Album> matchAlbums;
			string							profilePictureURL = string.Empty;
			string							potentialMatchFirstName = string.Empty;
			string							potentialMatchLastName = string.Empty;
			string							potentialMatchCity = string.Empty;
			string							potentialMatchBirthday = string.Empty;
			if (potentinalMatch != null)
			{
				try
				{
					matchAlbums = potentinalMatch.GetAlbums();
					if (matchAlbums != null)
					{
						matchAlbumsManager = new AlbumsManager(matchAlbums, flowLayoutPanelMatchPictures);
						matchAlbumsManager.DisplayAlbums();
					}

					profilePictureURL = potentinalMatch.GetProfilePicture();
					potentialMatchFirstName = potentinalMatch.GetFirstName();
					potentialMatchLastName = potentinalMatch.GetLastName();
					potentialMatchCity = potentinalMatch.GetCity();
					potentialMatchBirthday = potentinalMatch.GetBirthday();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					panelUserDetails.SetAllUserDetails(
						profilePictureURL,
						potentialMatchFirstName,
						potentialMatchLastName,
						potentialMatchCity,
						potentialMatchBirthday);
					panelUserDetails.Visible = true;
				}
			}
		}
	}
}
