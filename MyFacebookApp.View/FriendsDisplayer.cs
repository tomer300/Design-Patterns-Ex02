using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using MyFacebookApp.Model;

namespace MyFacebookApp.View
{
	public delegate void friendPictureClickEvent(object i_Sender, FriendsDisplayer.AppUserEventArgs i_EventArgs);
	public class FriendsDisplayer
	{
		private readonly FacebookObjectCollection<AppUser> r_Friends;
		private readonly Panel r_DisplayPanel;
		public event friendPictureClickEvent FriendOnClickDelegate;

		public FriendsDisplayer(FacebookObjectCollection<AppUser> i_Friends, Panel i_PanelToDisplayIn )
		{
			r_Friends = i_Friends;
			r_DisplayPanel = i_PanelToDisplayIn;
		}

		
		public void Display()
		{
			bool hasShownMessageBox = false;

			foreach (AppUser friend in r_Friends)
			{
				showFriendProfilePicture(friend, ref hasShownMessageBox);
			}
		}
		private void showFriendProfilePicture(AppUser i_Friend, ref bool io_HasShownMessageBox)
		{
			string profilePictureURL = string.Empty;
			string firstName = string.Empty;
			string lastName = string.Empty;

			try
			{
				firstName = i_Friend.FirstName;
				lastName = i_Friend.LastName;
				profilePictureURL = i_Friend.ProfilePicture;
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
				PictureWrapper			friendPictureWrapper = new PictureWrapper(profilePictureURL);
				DetailedProfilePicture	friendPicture = new DetailedProfilePicture(
					friendPictureWrapper.PictureBox,
					firstName,
					lastName);
				if(FriendOnClickDelegate != null)
				{
					friendPicture.FriendProfilePicture.Name = string.Format("{0} {1}", firstName, lastName);
					friendPicture.FriendProfilePicture.Cursor = Cursors.Hand;
					friendPicture.FriendProfilePicture.Click += (user,e) => FriendOnClickDelegate.Invoke(friendPicture.FriendProfilePicture, new AppUserEventArgs(i_Friend));
				}
				r_DisplayPanel.Controls.Add(friendPicture.FriendProfilePicture);
			}
		}
		public class AppUserEventArgs: EventArgs
		{
			public AppUser User { get; private set; }
			public AppUserEventArgs(AppUser i_User)
			{
				User = i_User;
			}
		}
	}
}
