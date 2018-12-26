namespace MyFacebookApp.View
{
	partial class MatchPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchPanel));
			this.flowLayoutPanelMatchPictures = new System.Windows.Forms.FlowLayoutPanel();
			this.labelBetweenAges = new System.Windows.Forms.Label();
			this.comboBoxAgeRanges = new System.Windows.Forms.ComboBox();
			this.labelInterestedIn = new System.Windows.Forms.Label();
			this.checkBoxBoys = new System.Windows.Forms.CheckBox();
			this.checkBoxGirls = new System.Windows.Forms.CheckBox();
			this.userDetailsPanelLoggedUser = new MyFacebookApp.View.UserDetailsPanel();
			this.findAMatchRoundedButton = new MyFacebookApp.View.RoundedButton();
			this.panelUserDetailsMatch = new MyFacebookApp.View.UserDetailsPanel();
			this.labelDistanceTo = new System.Windows.Forms.Label();
			this.labelDistanceToInfo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// flowLayoutPanelMatchPictures
			// 
			this.flowLayoutPanelMatchPictures.AutoScroll = true;
			this.flowLayoutPanelMatchPictures.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flowLayoutPanelMatchPictures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.flowLayoutPanelMatchPictures.Location = new System.Drawing.Point(14, 326);
			this.flowLayoutPanelMatchPictures.Name = "flowLayoutPanelMatchPictures";
			this.flowLayoutPanelMatchPictures.Size = new System.Drawing.Size(908, 196);
			this.flowLayoutPanelMatchPictures.TabIndex = 13;
			// 
			// labelBetweenAges
			// 
			this.labelBetweenAges.AutoSize = true;
			this.labelBetweenAges.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBetweenAges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.labelBetweenAges.Location = new System.Drawing.Point(33, 174);
			this.labelBetweenAges.Name = "labelBetweenAges";
			this.labelBetweenAges.Size = new System.Drawing.Size(157, 23);
			this.labelBetweenAges.TabIndex = 12;
			this.labelBetweenAges.Text = "Between Ages:";
			// 
			// comboBoxAgeRanges
			// 
			this.comboBoxAgeRanges.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxAgeRanges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.comboBoxAgeRanges.FormattingEnabled = true;
			this.comboBoxAgeRanges.Items.AddRange(new object[] {
            "18-20",
            "21-25",
            "26-30",
            "31-35",
            "36-40",
            "41-45",
            "46-50",
            "50+"});
			this.comboBoxAgeRanges.Location = new System.Drawing.Point(37, 207);
			this.comboBoxAgeRanges.Name = "comboBoxAgeRanges";
			this.comboBoxAgeRanges.Size = new System.Drawing.Size(208, 31);
			this.comboBoxAgeRanges.TabIndex = 11;
			this.comboBoxAgeRanges.Text = "18-20";
			// 
			// labelInterestedIn
			// 
			this.labelInterestedIn.AutoSize = true;
			this.labelInterestedIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelInterestedIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.labelInterestedIn.Location = new System.Drawing.Point(33, 71);
			this.labelInterestedIn.Name = "labelInterestedIn";
			this.labelInterestedIn.Size = new System.Drawing.Size(136, 23);
			this.labelInterestedIn.TabIndex = 10;
			this.labelInterestedIn.Text = "Interested In:";
			// 
			// checkBoxBoys
			// 
			this.checkBoxBoys.AutoSize = true;
			this.checkBoxBoys.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxBoys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.checkBoxBoys.Location = new System.Drawing.Point(37, 139);
			this.checkBoxBoys.Name = "checkBoxBoys";
			this.checkBoxBoys.Size = new System.Drawing.Size(75, 27);
			this.checkBoxBoys.TabIndex = 9;
			this.checkBoxBoys.Text = "Boys";
			this.checkBoxBoys.UseVisualStyleBackColor = true;
			// 
			// checkBoxGirls
			// 
			this.checkBoxGirls.AutoSize = true;
			this.checkBoxGirls.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxGirls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.checkBoxGirls.Location = new System.Drawing.Point(37, 106);
			this.checkBoxGirls.Name = "checkBoxGirls";
			this.checkBoxGirls.Size = new System.Drawing.Size(71, 27);
			this.checkBoxGirls.TabIndex = 8;
			this.checkBoxGirls.Text = "Girls";
			this.checkBoxGirls.UseVisualStyleBackColor = true;
			// 
			// userDetailsPanelLoggedUser
			// 
			this.userDetailsPanelLoggedUser.Location = new System.Drawing.Point(277, 56);
			this.userDetailsPanelLoggedUser.Name = "userDetailsPanelLoggedUser";
			this.userDetailsPanelLoggedUser.Size = new System.Drawing.Size(542, 110);
			this.userDetailsPanelLoggedUser.TabIndex = 17;
			// 
			// findAMatchRoundedButton
			// 
			this.findAMatchRoundedButton.BackColor = System.Drawing.Color.Transparent;
			this.findAMatchRoundedButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("findAMatchRoundedButton.BackgroundImage")));
			this.findAMatchRoundedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.findAMatchRoundedButton.FlatAppearance.BorderSize = 0;
			this.findAMatchRoundedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.findAMatchRoundedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.findAMatchRoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.findAMatchRoundedButton.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.findAMatchRoundedButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(34)))), ((int)(((byte)(62)))));
			this.findAMatchRoundedButton.Location = new System.Drawing.Point(37, 255);
			this.findAMatchRoundedButton.Name = "findAMatchRoundedButton";
			this.findAMatchRoundedButton.Size = new System.Drawing.Size(201, 47);
			this.findAMatchRoundedButton.TabIndex = 16;
			this.findAMatchRoundedButton.Text = "Find me a match!";
			this.findAMatchRoundedButton.UseVisualStyleBackColor = false;
			this.findAMatchRoundedButton.Click += new System.EventHandler(this.findMeAMatchButton_Click);
			// 
			// panelUserDetailsMatch
			// 
			this.panelUserDetailsMatch.Location = new System.Drawing.Point(277, 192);
			this.panelUserDetailsMatch.Name = "panelUserDetailsMatch";
			this.panelUserDetailsMatch.Size = new System.Drawing.Size(548, 110);
			this.panelUserDetailsMatch.TabIndex = 15;
			this.panelUserDetailsMatch.Visible = false;
			// 
			// labelDistanceTo
			// 
			this.labelDistanceTo.AutoSize = true;
			this.labelDistanceTo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDistanceTo.ForeColor = System.Drawing.Color.Salmon;
			this.labelDistanceTo.Location = new System.Drawing.Point(431, 174);
			this.labelDistanceTo.Name = "labelDistanceTo";
			this.labelDistanceTo.Size = new System.Drawing.Size(133, 23);
			this.labelDistanceTo.TabIndex = 18;
			this.labelDistanceTo.Text = "Distance To: ";
			this.labelDistanceTo.Visible = false;
			// 
			// labelDistanceToInfo
			// 
			this.labelDistanceToInfo.AutoSize = true;
			this.labelDistanceToInfo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDistanceToInfo.ForeColor = System.Drawing.Color.Salmon;
			this.labelDistanceToInfo.Location = new System.Drawing.Point(570, 174);
			this.labelDistanceToInfo.Name = "labelDistanceToInfo";
			this.labelDistanceToInfo.Size = new System.Drawing.Size(49, 23);
			this.labelDistanceToInfo.TabIndex = 19;
			this.labelDistanceToInfo.Text = "N/A";
			this.labelDistanceToInfo.Visible = false;
			// 
			// MatchPanel
			// 
			this.Controls.Add(this.labelDistanceToInfo);
			this.Controls.Add(this.labelDistanceTo);
			this.Controls.Add(this.userDetailsPanelLoggedUser);
			this.Controls.Add(this.findAMatchRoundedButton);
			this.Controls.Add(this.panelUserDetailsMatch);
			this.Controls.Add(this.flowLayoutPanelMatchPictures);
			this.Controls.Add(this.labelBetweenAges);
			this.Controls.Add(this.comboBoxAgeRanges);
			this.Controls.Add(this.labelInterestedIn);
			this.Controls.Add(this.checkBoxBoys);
			this.Controls.Add(this.checkBoxGirls);
			this.Name = "MatchPanel";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMatchPictures;
		private System.Windows.Forms.Label labelBetweenAges;
		private System.Windows.Forms.ComboBox comboBoxAgeRanges;
		private System.Windows.Forms.Label labelInterestedIn;
		private System.Windows.Forms.CheckBox checkBoxBoys;
		private System.Windows.Forms.CheckBox checkBoxGirls;
		private MyFacebookApp.View.UserDetailsPanel panelUserDetailsMatch;
		private MyFacebookApp.View.RoundedButton findAMatchRoundedButton;
		private UserDetailsPanel userDetailsPanelLoggedUser;
		private System.Windows.Forms.Label labelDistanceTo;
		private System.Windows.Forms.Label labelDistanceToInfo;
	}
}
