namespace MyFacebookApp.View
{
	public class RoundedButton : System.Windows.Forms.Button
	{
		private const int k_Width = 130;
		private const int k_Height = 40;
		private readonly System.Drawing.Image r_BasicImage = Properties.Resources.basicRoundedButtonIcon as System.Drawing.Image;
		private readonly System.Drawing.Image r_HoverImage = Properties.Resources.hoverRoundedButtonIcon as System.Drawing.Image;
		private readonly System.Drawing.Image r_ClickImage = Properties.Resources.clickRoundedButtonIcon as System.Drawing.Image;

		public RoundedButton()
		{
			this.Width = k_Width;
			this.Height = k_Height;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BackgroundImage = Properties.Resources.basicRoundedButtonIcon;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.FlatAppearance.BorderSize = 0;
			this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MouseDown += RoundedButton_MouseDown;
			this.MouseUp += RoundedButton_MouseUp;
			this.MouseEnter += RoundedButton_MouseEnter;
			this.MouseLeave += RoundedButton_MouseLeave;
			this.Font = new System.Drawing.Font("Century Gothic", 12);
			this.ForeColor = System.Drawing.Color.FromArgb(41, 34, 62);
		}

		private void RoundedButton_MouseLeave(object sender, System.EventArgs e)
		{
			RoundedButton hoveredButton = sender as RoundedButton;

			if (hoveredButton != null)
			{
				hoveredButton.BackgroundImage = r_BasicImage;
			}
		}

		private void RoundedButton_MouseEnter(object sender, System.EventArgs e)
		{
			RoundedButton hoveredButton = sender as RoundedButton;

			if (hoveredButton != null)
			{
				hoveredButton.BackgroundImage = r_HoverImage;
			}
		}

		private void RoundedButton_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			RoundedButton clickedButton = sender as RoundedButton;

			if (clickedButton != null)
			{
				clickedButton.BackgroundImage = r_BasicImage;
			}
		}

		private void RoundedButton_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			RoundedButton clickedButton = sender as RoundedButton;

			if (clickedButton != null)
			{
				clickedButton.BackgroundImage = r_ClickImage;
			}
		}
	}
}