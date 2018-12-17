namespace MyFacebookApp.View
{
	partial class UserDetailsPanel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label birthdayLabel;
			System.Windows.Forms.Label cityLabel;
			System.Windows.Forms.Label firstNameLabel;
			System.Windows.Forms.Label lastNameLabel;
			this.panelUserDetails = new System.Windows.Forms.Panel();
			this.birthdayLabel1 = new System.Windows.Forms.Label();
			this.cityLabel1 = new System.Windows.Forms.Label();
			this.firstNameLabel1 = new System.Windows.Forms.Label();
			this.lastNameLabel1 = new System.Windows.Forms.Label();
			this.profilePicturePictureBox = new System.Windows.Forms.PictureBox();
			this.appUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
			birthdayLabel = new System.Windows.Forms.Label();
			cityLabel = new System.Windows.Forms.Label();
			firstNameLabel = new System.Windows.Forms.Label();
			lastNameLabel = new System.Windows.Forms.Label();
			this.panelUserDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.profilePicturePictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.appUserBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// birthdayLabel
			// 
			birthdayLabel.AutoSize = true;
			birthdayLabel.Font = new System.Drawing.Font("Century Gothic", 12F);
			birthdayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			birthdayLabel.Location = new System.Drawing.Point(153, 86);
			birthdayLabel.Name = "birthdayLabel";
			birthdayLabel.Size = new System.Drawing.Size(93, 23);
			birthdayLabel.TabIndex = 27;
			birthdayLabel.Text = "Birthday:";
			// 
			// cityLabel
			// 
			cityLabel.AutoSize = true;
			cityLabel.Font = new System.Drawing.Font("Century Gothic", 12F);
			cityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			cityLabel.Location = new System.Drawing.Point(153, 60);
			cityLabel.Name = "cityLabel";
			cityLabel.Size = new System.Drawing.Size(52, 23);
			cityLabel.TabIndex = 29;
			cityLabel.Text = "City:";
			// 
			// firstNameLabel
			// 
			firstNameLabel.AutoSize = true;
			firstNameLabel.Font = new System.Drawing.Font("Century Gothic", 12F);
			firstNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			firstNameLabel.Location = new System.Drawing.Point(153, 14);
			firstNameLabel.Name = "firstNameLabel";
			firstNameLabel.Size = new System.Drawing.Size(116, 23);
			firstNameLabel.TabIndex = 31;
			firstNameLabel.Text = "First Name:";
			// 
			// lastNameLabel
			// 
			lastNameLabel.AutoSize = true;
			lastNameLabel.Font = new System.Drawing.Font("Century Gothic", 12F);
			lastNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			lastNameLabel.Location = new System.Drawing.Point(153, 37);
			lastNameLabel.Name = "lastNameLabel";
			lastNameLabel.Size = new System.Drawing.Size(120, 23);
			lastNameLabel.TabIndex = 33;
			lastNameLabel.Text = "Last Name:";
			// 
			// panelUserDetails
			// 
			this.panelUserDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
			this.panelUserDetails.Controls.Add(birthdayLabel);
			this.panelUserDetails.Controls.Add(this.birthdayLabel1);
			this.panelUserDetails.Controls.Add(cityLabel);
			this.panelUserDetails.Controls.Add(this.cityLabel1);
			this.panelUserDetails.Controls.Add(firstNameLabel);
			this.panelUserDetails.Controls.Add(this.firstNameLabel1);
			this.panelUserDetails.Controls.Add(lastNameLabel);
			this.panelUserDetails.Controls.Add(this.lastNameLabel1);
			this.panelUserDetails.Controls.Add(this.profilePicturePictureBox);
			this.panelUserDetails.Location = new System.Drawing.Point(0, 0);
			this.panelUserDetails.Name = "panelUserDetails";
			this.panelUserDetails.Size = new System.Drawing.Size(548, 130);
			this.panelUserDetails.TabIndex = 0;
			// 
			// birthdayLabel1
			// 
			this.birthdayLabel1.AutoSize = true;
			this.birthdayLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appUserBindingSource, "Birthday", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "\"N/A\""));
			this.birthdayLabel1.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.birthdayLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.birthdayLabel1.Location = new System.Drawing.Point(268, 86);
			this.birthdayLabel1.Name = "birthdayLabel1";
			this.birthdayLabel1.Size = new System.Drawing.Size(49, 23);
			this.birthdayLabel1.TabIndex = 28;
			this.birthdayLabel1.Text = "N/A";
			// 
			// cityLabel1
			// 
			this.cityLabel1.AutoSize = true;
			this.cityLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appUserBindingSource, "City", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "\"N/A\""));
			this.cityLabel1.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.cityLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.cityLabel1.Location = new System.Drawing.Point(268, 60);
			this.cityLabel1.Name = "cityLabel1";
			this.cityLabel1.Size = new System.Drawing.Size(49, 23);
			this.cityLabel1.TabIndex = 30;
			this.cityLabel1.Text = "N/A";
			// 
			// firstNameLabel1
			// 
			this.firstNameLabel1.AutoSize = true;
			this.firstNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appUserBindingSource, "FirstName", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "\"N/A\""));
			this.firstNameLabel1.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.firstNameLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.firstNameLabel1.Location = new System.Drawing.Point(268, 14);
			this.firstNameLabel1.Name = "firstNameLabel1";
			this.firstNameLabel1.Size = new System.Drawing.Size(49, 23);
			this.firstNameLabel1.TabIndex = 32;
			this.firstNameLabel1.Text = "N/A";
			// 
			// lastNameLabel1
			// 
			this.lastNameLabel1.AutoSize = true;
			this.lastNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appUserBindingSource, "LastName", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "\"N/A\""));
			this.lastNameLabel1.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.lastNameLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.lastNameLabel1.Location = new System.Drawing.Point(268, 37);
			this.lastNameLabel1.Name = "lastNameLabel1";
			this.lastNameLabel1.Size = new System.Drawing.Size(49, 23);
			this.lastNameLabel1.TabIndex = 34;
			this.lastNameLabel1.Text = "N/A";
			// 
			// profilePicturePictureBox
			// 
			this.profilePicturePictureBox.DataBindings.Add(new System.Windows.Forms.Binding("ImageLocation", this.appUserBindingSource, "ProfilePicture", true));
			this.profilePicturePictureBox.Location = new System.Drawing.Point(17, 14);
			this.profilePicturePictureBox.Name = "profilePicturePictureBox";
			this.profilePicturePictureBox.Size = new System.Drawing.Size(100, 100);
			this.profilePicturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.profilePicturePictureBox.TabIndex = 36;
			this.profilePicturePictureBox.TabStop = false;
			// 
			// appUserBindingSource
			// 
			this.appUserBindingSource.DataSource = typeof(MyFacebookApp.Model.AppUser);
			// 
			// UserDetailsPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.panelUserDetails);
			this.Name = "UserDetailsPanel";
			this.Size = new System.Drawing.Size(542, 130);
			this.panelUserDetails.ResumeLayout(false);
			this.panelUserDetails.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.profilePicturePictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.appUserBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelUserDetails;
		private System.Windows.Forms.Label birthdayLabel1;
		private System.Windows.Forms.BindingSource appUserBindingSource;
		private System.Windows.Forms.Label cityLabel1;
		private System.Windows.Forms.Label firstNameLabel1;
		private System.Windows.Forms.Label lastNameLabel1;
		private System.Windows.Forms.PictureBox profilePicturePictureBox;
	}
}
