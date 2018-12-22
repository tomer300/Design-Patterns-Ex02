using System;
using System.Drawing;
using System.Windows.Forms;
using Facebook;

namespace MyFacebookApp.View
{
	public class PictureWrapper
	{
		public PictureBox PictureBox { get; private set; }

		public PictureWrapper(string i_PictureURL, int i_Width = 100, int i_Height = 100, PictureBoxSizeMode i_PictureBoxSizeMode = PictureBoxSizeMode.StretchImage)
		{
			PictureBox = new PictureBox { Width = i_Width, Height = i_Height };

			if (!string.IsNullOrEmpty(i_PictureURL))
			{
				try
				{
					PictureBox.Load(i_PictureURL);
				}
				catch (Exception ex)
				{
					throw new FacebookApiLimitException(string.Format("Couldnt load picture- {0}", ex.Message));
				}

				PictureBox.SizeMode = i_PictureBoxSizeMode;
			}
			else
			{
				createEmptyPhoto();
			}
		}

		private void createEmptyPhoto()
		{
			PictureBox.BackColor = System.Drawing.Color.Gray;
			PictureBox.Paint += new PaintEventHandler((sender, e) =>
			{
				const float		k_FontSize = 12;
				const string	k_NoPictureMessage = "No Picture";
				SizeF			noPictureMessageSize;
				PointF			locationToDraw = new PointF();

				e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
				noPictureMessageSize = e.Graphics.MeasureString(k_NoPictureMessage, new Font("Franklin Gothic Heavy", k_FontSize));
				locationToDraw.X = (PictureBox.Width / 2) - (noPictureMessageSize.Width / 2);
				locationToDraw.Y = (PictureBox.Height / (float)1.4) - (noPictureMessageSize.Height / (float)2);
				e.Graphics.DrawString(k_NoPictureMessage, new Font("Franklin Gothic Heavy", k_FontSize), Brushes.White, locationToDraw);
			});
		}
	}
}
