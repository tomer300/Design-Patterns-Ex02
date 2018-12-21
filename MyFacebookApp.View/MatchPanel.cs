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
				setLabelsVisibility(false);
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
			string								distanceToMatch = string.Empty;

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
						double distance = r_AppEngine.DistanceBetweenTwoCoordinatesAdapter.CalculateDistance(
							r_AppEngine.LoggedUser.Location.Latitude,
							r_AppEngine.LoggedUser.Location.Longitude,
							potentialMatch.Location.Latitude,
							potentialMatch.Location.Longitude
							);
						/*double? x1 = 32.0866296535;
						double? y1 = 34.8851297928;
						double? x2 = 31.97102;
						double? y2 = 34.78939;
						double distance = distanceAdapter.CalculateDistance(
							x1,
							y1,
							x2,
							y2
							);*/
						distanceToMatch = string.Format("{0:F1} km", distance);
						labelDistanceToInfo.Text = distanceToMatch;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
					finally
					{
						setLabelsVisibility(true);
					}
				}
			}
		}

		private void setLabelsVisibility(bool i_IsVisible)
		{
			labelDistanceTo.Visible = i_IsVisible;
			labelDistanceToInfo.Visible = i_IsVisible;
			panelUserDetailsMatch.Visible = i_IsVisible;
		}
	}
}
