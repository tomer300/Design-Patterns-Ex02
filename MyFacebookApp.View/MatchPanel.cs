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
				FacebookObjectCollection<AppUser>	potentialMatches;
				bool								hasShownMessageBox = false;

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
						foreach (AppUser currentPotentialMatch in potentialMatches)
						{
							addPotentialMatch(currentPotentialMatch, ref hasShownMessageBox);
						}
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

		private void addPotentialMatch(AppUser i_CurrentPotentialMatch, ref bool io_HasShownMessageBox)
		{
			PictureWrapper	matchPicWrapper;
			string			profilePictureURL = string.Empty;

			try
			{
				profilePictureURL = i_CurrentPotentialMatch.GetProfilePicture();
			}
			catch (Exception ex)
			{
				if (!io_HasShownMessageBox)
				{
					MessageBox.Show(ex.Message);
					io_HasShownMessageBox = true;
				}
			}
			finally
			{
				PictureBox matchPic;

				matchPicWrapper = new PictureWrapper(profilePictureURL);
				matchPic = matchPicWrapper.PictureBox;
				matchPic.Cursor = Cursors.Hand;
				matchPic.Click += (user, ex) => match_Click(i_CurrentPotentialMatch);
				flowLayoutPanelMatchPictures.Controls.Add(matchPic);
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

		private void match_Click(AppUser i_PotentialMatch)
		{
			AlbumsManager					matchAlbumsManager;
			FacebookObjectCollection<Album> matchAlbums;
			string							profilePictureURL = string.Empty;
			string							potentialMatchFirstName = string.Empty;
			string							potentialMatchLastName = string.Empty;
			string							potentialMatchCity = string.Empty;
			string							potentialMatchBirthday = string.Empty;

			try
			{
				matchAlbums = i_PotentialMatch.GetAlbums();
				if (matchAlbums != null)
				{
					matchAlbumsManager = new AlbumsManager(matchAlbums, flowLayoutPanelMatchPictures);
					matchAlbumsManager.DisplayAlbums();
				}

				profilePictureURL = i_PotentialMatch.GetProfilePicture();
				potentialMatchFirstName = i_PotentialMatch.GetFirstName();
				potentialMatchLastName = i_PotentialMatch.GetLastName();
				potentialMatchCity = i_PotentialMatch.GetCity();
				potentialMatchBirthday = i_PotentialMatch.GetBirthday();
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
