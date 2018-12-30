using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using Facebook;

namespace MyFacebookApp.View
{
	internal class AlbumsManager
	{
		private readonly FacebookObjectCollection<Album>	r_AlbumsOfUser;
		private readonly Panel								r_PanelToDisplayIn;
		public Action										AlbumClickedAction;

		internal AlbumsManager(FacebookObjectCollection<Album> i_AlbumsOfUser, Panel i_PanelToDisplayIn)
		{
			r_AlbumsOfUser = i_AlbumsOfUser;
			r_PanelToDisplayIn = i_PanelToDisplayIn;
		}

		internal void DisplayAlbums()
		{	
			string albumPictureURL = string.Empty;
			bool hasShownExceptionMessage = false;

			lock (r_PanelToDisplayIn)
			{
				r_PanelToDisplayIn.Invoke(new Action(() => r_PanelToDisplayIn.Controls.Clear()));
				foreach (Album currentAlbum in r_AlbumsOfUser)
				{
					if (currentAlbum.Count > 0)
					{
						PictureWrapper currentAlbumPictureWrapper;
						PictureBox currentAlbumPictureBox;

						try
						{
							albumPictureURL = currentAlbum.CoverPhoto.PictureNormalURL;
						}
						catch (Facebook.FacebookApiException)
						{
							// current album has no cover photo, we handle this within PictureWrapper in the form of empty url string.
						}
						finally
						{
							try
							{
								currentAlbumPictureWrapper = new PictureWrapper(albumPictureURL);
								currentAlbumPictureBox = currentAlbumPictureWrapper.PictureBox;
								currentAlbumPictureBox.Enabled = false;
								currentAlbumPictureBox.Cursor = Cursors.Hand;
								currentAlbumPictureBox.MouseEnter += new EventHandler(album_Enter);
								currentAlbumPictureBox.MouseLeave += new EventHandler(album_Leave);
								currentAlbumPictureBox.Click += (sender, e) =>
								{
									FacebookView.CreateThread(() => album_Click(currentAlbum));
								};
								r_PanelToDisplayIn.Invoke(new Action(() => r_PanelToDisplayIn.Controls.Add(currentAlbumPictureBox)));
							}
							catch (FacebookApiLimitException ex)
							{
								if (!hasShownExceptionMessage)
								{
									hasShownExceptionMessage = true;
									MessageBox.Show(ex.Message);
								}
							}
						}
					}
				}

				foreach (Control currItem in r_PanelToDisplayIn.Controls)
				{
					currItem.Enabled = true;
				}
			}
		}

		private void album_Leave(object sender, EventArgs e)
		{
			PictureBox albumLeft = sender as PictureBox;

			if (albumLeft != null)
			{
				albumLeft.Invoke(new Action(() => albumLeft.BorderStyle = BorderStyle.None));			
			}
		}

		private void album_Enter(object sender, EventArgs e)
		{
			PictureBox albumHovered = sender as PictureBox;

			if (albumHovered != null)
			{
				albumHovered.Invoke(new Action(() => albumHovered.BorderStyle = BorderStyle.Fixed3D));			
			}
		}

		private void album_Click(Album i_ClickedAlbum)
		{
			bool hasShownExceptionMessage = false;

			lock (r_PanelToDisplayIn)
			{
				r_PanelToDisplayIn.Invoke(new Action(() => r_PanelToDisplayIn.Controls.Clear()));
				if (AlbumClickedAction != null)
				{
					AlbumClickedAction.Invoke();
				}

				try
				{
					foreach (Photo currentPhoto in i_ClickedAlbum.Photos)
					{
						try
						{
							PictureWrapper currentPictureWrapper = new PictureWrapper(currentPhoto.PictureNormalURL);
							PictureBox currentPhotoPictureBox = currentPictureWrapper.PictureBox;

							r_PanelToDisplayIn.Invoke(new Action(() => r_PanelToDisplayIn.Controls.Add(currentPhotoPictureBox)));
						}
						catch (FacebookApiLimitException ex)
						{
							if (!hasShownExceptionMessage)
							{
								hasShownExceptionMessage = true;
								MessageBox.Show(ex.Message);
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
}
