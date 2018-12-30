using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using MyFacebookApp.Model;

namespace MyFacebookApp.View
{
	public partial class MatchPanel : AppScreenPanel, IBackable
	{
		internal MatchPanel(AppEngine i_AppEngine) : base(i_AppEngine)
		{
			InitializeComponent();
			FacebookView.CreateThread(fetchInitialDetails);
		}

		private void findMeAMatchButton_Click(object sender, EventArgs e)
		{
			if (checkedGenderPreference())
			{
				FacebookObjectCollection<AppUser> potentialMatches;

				setLabelsVisibility(false);
				try
				{
					potentialMatches = r_AppEngine.FindAMatch(
						checkBoxGirls.Checked,
						checkBoxBoys.Checked,
						comboBoxAgeRanges.Items[comboBoxAgeRanges.SelectedIndex].ToString());
					if (potentialMatches != null && potentialMatches.Count > 0)
					{
						FriendsDisplayer displayer = new FriendsDisplayer(potentialMatches, flowLayoutPanelMatchPictures);
						displayer.FriendOnClickDelegate += match_Click;
						FacebookView.CreateThread(displayer.Display);
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
			const int							KM = 1000;
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
						IDistance distanceAdapter = r_AppEngine.DistanceBetweenTwoCoordinatesAdapter;
						matchAlbums = potentialMatch.GetAlbums();
						if (matchAlbums != null)
						{
							matchAlbumsManager = new AlbumsManager(matchAlbums, flowLayoutPanelMatchPictures);
							FacebookView.CreateThread(matchAlbumsManager.DisplayAlbums);
						}

						panelUserDetailsMatch.SetDataSource(potentialMatch);
						double distance = distanceAdapter.GetDistanceTo(
							r_AppEngine.LoggedUser.Location.Latitude,
							r_AppEngine.LoggedUser.Location.Longitude,
							potentialMatch.Location.Latitude,
							potentialMatch.Location.Longitude);

						distanceToMatch = string.Format("{0:F1} km", distance / KM);
						labelDistanceToInfo.Invoke(new Action(() => labelDistanceToInfo.Text = distanceToMatch));
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
			labelDistanceTo.Invoke(new Action(() => labelDistanceTo.Visible = i_IsVisible));
			labelDistanceToInfo.Invoke(new Action(() => labelDistanceToInfo.Visible = i_IsVisible));
			panelUserDetailsMatch.Invoke(new Action(() => panelUserDetailsMatch.Visible = i_IsVisible));
		}
	}
}
