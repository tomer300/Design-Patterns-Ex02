using System;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using MyFacebookApp.Model;
using Facebook;

namespace MyFacebookApp.View
{
	public partial class HomePanel : AppScreenPanel
	{
		private AlbumsManager m_AlbumsManager;

		internal HomePanel(AppEngine i_AppEngine) : base(i_AppEngine)
		{
			InitializeComponent();
			FacebookView.CreateThread(fetchInitialDetails);
			if(AppSettings.Settings.RememberUser)
			{
				FacebookView.CreateThread(ShowAllDetails);
			}
		}

		protected override void fetchInitialDetails()
		{
			base.fetchInitialDetails();
			fetchLikedPages();
		}

		private void friendsButton_Click(object sender, EventArgs e)
		{
			FacebookView.CreateThread(fetchFriends);
		}

		private void ShowAllDetails()
		{
			FacebookView.CreateThread(displayAlbums);
			FacebookView.CreateThread(fetchPosts);
			FacebookView.CreateThread(fetchFriends);
			FacebookView.CreateThread(fetchEvents);
		}

		private void fetchFriends()
		{
			try
			{
				friendsRoundedButton.Invoke(new Action(() => friendsRoundedButton.Enabled = false));
				FriendsDisplayer displayer = new FriendsDisplayer(r_AppEngine.Friends, flowLayoutPanelFriends);
				displayer.Display();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void fetchLikedPages()
		{
			try
			{
				FacebookObjectCollection<Page> likedPages = r_AppEngine.LikedPages;

				if (!listBoxLikedPages.InvokeRequired)
				{
					pageBindingSource.DataSource = likedPages;
				}
				else
				{
					listBoxLikedPages.Invoke(new Action(() => pageBindingSource.DataSource = likedPages));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void albumsButton_Click(object sender, EventArgs e)
		{
			FacebookView.CreateThread(displayAlbums);
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
				albumsRoundedButton.Invoke(new Action(() => albumsRoundedButton.Text = "Albums"));
				m_AlbumsManager.DisplayAlbums();
			}
		}

		private void albumsButtonChangeDescription()
		{
			albumsRoundedButton.Invoke(new Action(() => albumsRoundedButton.Text = "Back To Albums"));
		}

		private void eventsButton_Click(object sender, EventArgs e)
		{
			FacebookView.CreateThread(fetchEvents);
		}

		private void fetchEvents()
		{
			try
			{
				eventsRoundedButton.Invoke(new Action(() => eventsRoundedButton.Enabled = false));
				FacebookObjectCollection<Event> events = r_AppEngine.Events;

				if (!listBoxEvents.InvokeRequired)
				{
					eventBindingSource.DataSource = events;
				}
				else
				{
					listBoxEvents.Invoke(new Action(() => eventBindingSource.DataSource = events));
				}

				if (eventBindingSource.Count == 0)
				{
					MessageBox.Show("No Events to retrieve :(");
				}
			}
			catch (Exception exEvents)
			{
				MessageBox.Show(string.Format("Error! could'nt fetch events - {0}.", exEvents.Message));
			}
}

		private void fetchPosts()
		{
			FacebookObjectCollection<Post> allPosts;
			bool hasShownExceptionMessage = false;

			postsRoundedButton.Invoke(new Action(() => postsRoundedButton.Enabled = false));
			tableLayoutPanelPosts.Invoke(new Action(() => tableLayoutPanelPosts.Controls.Clear()));
			tableLayoutPanelPosts.Invoke(new Action(() => tableLayoutPanelPosts.RowStyles.Clear()));
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
							try
							{
								PictureWrapper postPictureWrapper = new PictureWrapper(currentPost.PictureURL);
								PictureBox postPicture = postPictureWrapper.PictureBox;

								tableLayoutPanelPosts.Invoke(new Action(() => tableLayoutPanelPosts.Controls.Add(postPicture)));
								isLegalPost = true;
							}
							catch(FacebookApiLimitException ex)
							{
								if(!hasShownExceptionMessage)
								{
									hasShownExceptionMessage = true;
									MessageBox.Show(ex.Message);
								}
							}
						}

						if (isLegalPost == true)
						{
							Label seperator = new Label { Text = " ", AutoSize = true };

							tableLayoutPanelPosts.Invoke(new Action(() => tableLayoutPanelPosts.Controls.Add(postDetails)));
							tableLayoutPanelPosts.Invoke(new Action(() => tableLayoutPanelPosts.Controls.Add(seperator)));
						}
					}
				}
				else
				{
					MessageBox.Show("No Posts to retrieve :(");
				}
			}
			catch (Exception exPosts)
			{
				MessageBox.Show(string.Format("Error! could'nt fetch posts - {0}.", exPosts.Message));
			}
		}

		private void addPostData(string i_Content, ref bool io_IsLegalPost)
		{
			if (i_Content.Length > 0)
			{
				Label message = new Label { Text = i_Content, AutoSize = true };

				tableLayoutPanelPosts.Invoke(new Action(() => tableLayoutPanelPosts.Controls.Add(message)));
				io_IsLegalPost = true;
			}
		}

		private void postsButton_Click(object sender, EventArgs e)
		{
			FacebookView.CreateThread(fetchPosts);
		}

		public override void AddButtons(ICollection<ButtonBase> i_Buttons)
		{
			foreach(ButtonBase buttonToAdd in i_Buttons)
			{
				r_ButtonAttacher.AddButton(buttonToAdd, this, panelHomePageTop);
			}
		}
	}
}
