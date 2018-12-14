using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

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

			r_PanelToDisplayIn.Controls.Clear();
			foreach (Album currentAlbum in r_AlbumsOfUser)
			{
				if (currentAlbum.Count > 0)
				{
					PictureWrapper	currentAlbumPictureWrapper;
					PictureBox		currentAlbumPictureBox;

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
						currentAlbumPictureWrapper = new PictureWrapper(albumPictureURL);
						currentAlbumPictureBox = currentAlbumPictureWrapper.PictureBox;
						currentAlbumPictureBox.Cursor = Cursors.Hand;
						currentAlbumPictureBox.MouseEnter += new EventHandler(album_Enter);
						currentAlbumPictureBox.MouseLeave += new EventHandler(album_Leave);
						currentAlbumPictureBox.Click += (sender, e) => album_Click(currentAlbum);
						r_PanelToDisplayIn.Controls.Add(currentAlbumPictureBox);
					}
				}
			}
		}

		private void album_Leave(object sender, EventArgs e)
		{
			PictureBox albumLeft = sender as PictureBox;

			if (albumLeft != null)
			{
				albumLeft.BorderStyle = BorderStyle.None;
			}
		}

		private void album_Enter(object sender, EventArgs e)
		{
			PictureBox albumHovered = sender as PictureBox;

			if (albumHovered != null)
			{
				albumHovered.BorderStyle = BorderStyle.Fixed3D;
			}
		}

		private void album_Click(Album i_ClickedAlbum)
		{
			r_PanelToDisplayIn.Controls.Clear();
			if(r_PanelToDisplayIn.Parent is HomePanel)
			{
				AlbumClickedAction.Invoke();
			}

			foreach (Photo currentPhoto in i_ClickedAlbum.Photos)
			{
				PictureWrapper	currentPictureWrapper = new PictureWrapper(currentPhoto.PictureNormalURL);
				PictureBox		currentPhotoPictureBox = currentPictureWrapper.PictureBox;

				r_PanelToDisplayIn.Controls.Add(currentPhotoPictureBox);
			}
		}
	}
}
