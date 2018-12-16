using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using MyFacebookApp.Model;

namespace MyFacebookApp.View
{
	public partial class HomePanel : UserControl
	{
		private readonly AppEngine	r_AppEngine;
		private AlbumsManager		m_AlbumsManager;

		public HomePanel(AppEngine i_AppEngine)
		{
			InitializeComponent();
			r_AppEngine = i_AppEngine;
			fetchInitialDetails();
		}

		public bool RememberMeStatus
		{
			get
			{
				return checkBoxRememberMe.Checked;
			}

			set
			{
				checkBoxRememberMe.Checked = value;
			}
		}

		private void friendsButton_Click(object sender, EventArgs e)
		{
			fetchFriends();
		}

		internal void ShowAllDetails()
		{
			try
			{
				displayAlbums();
				fetchPosts();
				fetchEvents();
				fetchFriends();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void fetchFriends()
		{
			flowLayoutPanelFriends.Controls.Clear();
			try
			{
				FriendsDisplayer displayer = new FriendsDisplayer(r_AppEngine.Friends, flowLayoutPanelFriends);
				displayer.Display();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		private void fetchInitialDetails()
		{
			string profilePictureURL = string.Empty;
			string firstName = string.Empty;
			string lastName = string.Empty;
			string cityName = string.Empty;
			string birthday = string.Empty;

			try
			{
				profilePictureURL = r_AppEngine.ProfilePicture;
				firstName = r_AppEngine.FirstName;
				lastName = r_AppEngine.LastName;
				cityName = r_AppEngine.City;
				birthday = r_AppEngine.Birthday;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				panelUserDetails.SetAllUserDetails(profilePictureURL, firstName, lastName, cityName, birthday);
			}
		}

		private void albumsButton_Click(object sender, EventArgs e)
		{
			displayAlbums();
		}

		private void displayAlbums()
		{
			if (m_AlbumsManager == null)
			{
				try
				{
					FacebookObjectCollection<Album> usersAlbums = r_AppEngine.Albums;

					if (usersAlbums != null && usersAlbums.Count > 0)
					{
						m_AlbumsManager = new AlbumsManager(r_AppEngine.Albums, flowLayoutPanelAlbums);
						m_AlbumsManager.AlbumClickedAction += albumsButtonChangeDescription;
						m_AlbumsManager.DisplayAlbums();
					}
					else
					{
						MessageBox.Show("User has no albums.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				albumsRoundedButton.Text = "Albums";
				m_AlbumsManager.DisplayAlbums();
			}
		}

		private void albumsButtonChangeDescription()
		{
			albumsRoundedButton.Text = "Back To Albums";
		}

		private void eventsButton_Click(object sender, EventArgs e)
		{
			try
			{
				fetchEvents();
			}
			catch (Exception exEvents)
			{
				MessageBox.Show(string.Format("Error! could'nt fetch events - {0}.", exEvents.Message));
			}
		}

		private void fetchEvents()
		{
			FacebookObjectCollection<Event> allEvents;

			listBoxEvents.Items.Clear();
			try
			{
				allEvents = r_AppEngine.Events;
				if (allEvents != null && allEvents.Count > 0)
				{
					listBoxEvents.DisplayMember = "Name";
					foreach (Event fbEvent in allEvents)
					{
						listBoxEvents.Items.Add(fbEvent);
					}
				}
				else
				{
					MessageBox.Show("No Events to retrieve :(");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void fetchPosts()
		{
			FacebookObjectCollection<Post> allPosts;

			tableLayoutPanelPosts.Controls.Clear();
			tableLayoutPanelPosts.RowStyles.Clear();
			try
			{
				allPosts = r_AppEngine.Posts;
				if (allPosts != null && allPosts.Count > 0)
				{
					foreach (Post currentPost in allPosts)
					{
						bool	isLegalPost = false;
						Label	postDetails;

						postDetails = new Label
						{
							Text = string.Format(
							"Posted at: {0}{1}Post Type: {2}{3}",
							currentPost.CreatedTime.ToString(),
							Environment.NewLine,
							currentPost.Type,
							Environment.NewLine)
						};
						postDetails.AutoSize = true;

						if (currentPost.Message != null)
						{
							addPostData(currentPost.Message, ref isLegalPost);
						}

						if (currentPost.Caption != null)
						{
							addPostData(currentPost.Caption, ref isLegalPost);
						}

						if (currentPost.Type == Post.eType.photo)
						{
							PictureWrapper	postPictureWrapper = new PictureWrapper(currentPost.PictureURL);
							PictureBox		postPicture = postPictureWrapper.PictureBox;

							tableLayoutPanelPosts.Controls.Add(postPicture);
							isLegalPost = true;
						}

						if (isLegalPost == true)
						{
							Label seperator = new Label { Text = " ", AutoSize = true };

							tableLayoutPanelPosts.Controls.Add(postDetails);
							tableLayoutPanelPosts.Controls.Add(seperator);
						}
					}
				}
				else
				{
					MessageBox.Show("No Posts to retrieve :(");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void addPostData(string i_Content, ref bool io_IsLegalPost)
		{
			if (i_Content.Length > 0)
			{
				Label message = new Label { Text = i_Content, AutoSize = true };

				tableLayoutPanelPosts.Controls.Add(message);
				io_IsLegalPost = true;
			}
		}

		private void postsButton_Click(object sender, EventArgs e)
		{
			try
			{
				fetchPosts();
			}
			catch (Exception exPosts)
			{
				MessageBox.Show(string.Format("Error! could'nt fetch posts - {0}.", exPosts.Message));
			}
		}

		public void AddLogoutButton(Button i_LogoutButton)
		{
			panelHomePageTop.Controls.Add(i_LogoutButton);
		}
	}
}
