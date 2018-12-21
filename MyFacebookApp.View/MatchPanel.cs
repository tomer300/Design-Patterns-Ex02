using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using MyFacebookApp.Model;

namespace MyFacebookApp.View
{
	//add a data member
	public partial class MatchPanel : AppScreenPanel
	{
		public MatchPanel(AppEngine i_AppEngine) : base(i_AppEngine)
		{
			InitializeComponent();
			fetchInitialDetails();
		}

		private void findMeAMatchButton_Click(object sender, EventArgs e)
		{
			if (checkedGenderPreference())
			{
				FacebookObjectCollection<AppUser> potentialMatches;

				flowLayoutPanelMatchPictures.Controls.Clear();
				panelUserDetailsMatch.Visible = false;
				try
				{
					potentialMatches = r_AppEngine.FindAMatch(
						checkBoxGirls.Checked,
						checkBoxBoys.Checked,
						comboBoxAgeRanges.Items[comboBoxAgeRanges.SelectedIndex].ToString());
					if (potentialMatches != null && potentialMatches.Count > 0)
					{
						FriendsDisplayer displayer = new FriendsDisplayer(r_AppEngine.Friends, flowLayoutPanelMatchPictures);
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

		private void match_Click(object i_sender, EventArgs e)
		{
			FriendsDisplayer.AppUserEventArgs	appUserEventArgs = e as FriendsDisplayer.AppUserEventArgs;
			AppUser								potentialMatch;
			AlbumsManager						matchAlbumsManager;
			FacebookObjectCollection<Album>		matchAlbums;
			string								profilePictureURL = string.Empty;
			string								potentialMatchFirstName = string.Empty;
			string								potentialMatchLastName = string.Empty;
			string								potentialMatchCity = string.Empty;
			string								potentialMatchBirthday = string.Empty;

			if (appUserEventArgs != null)
			{
				potentialMatch = appUserEventArgs.User;
				if (potentialMatch != null)
				{
					try
					{
						matchAlbums = potentialMatch.GetAlbums();
						if (matchAlbums != null)
						{
							matchAlbumsManager = new AlbumsManager(matchAlbums, flowLayoutPanelMatchPictures);
							matchAlbumsManager.DisplayAlbums();
						}
						panelUserDetailsMatch.SetDataSource(potentialMatch);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
					finally
					{			
						panelUserDetailsMatch.Visible = true;
					}
				}
			}
		}
	}
}
