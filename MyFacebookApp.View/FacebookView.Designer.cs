namespace MyFacebookApp.View
{
	partial class FacebookView
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelMain = new System.Windows.Forms.Panel();
			this.findJobAppButton = new System.Windows.Forms.Button();
			this.findAMatchAppButton = new System.Windows.Forms.Button();
			this.panelMainButtons = new System.Windows.Forms.Panel();
			this.loginAppButton = new System.Windows.Forms.Button();
			this.panelFaceBookTitle = new System.Windows.Forms.Panel();
			this.labelAppName = new System.Windows.Forms.Label();
			this.panelShadowColorLight = new System.Windows.Forms.Panel();
			this.panelShadowColorDark = new System.Windows.Forms.Panel();
			this.panelMainButtons.SuspendLayout();
			this.panelFaceBookTitle.SuspendLayout();
			this.panelShadowColorLight.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Location = new System.Drawing.Point(222, 3);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(936, 533);
			this.panelMain.TabIndex = 1;
			// 
			// findJobAppButton
			// 
			this.findJobAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.findJobAppButton.Enabled = false;
			this.findJobAppButton.FlatAppearance.BorderSize = 0;
			this.findJobAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.findJobAppButton.Image = global::MyFacebookApp.View.Properties.Resources.jobButtonIcon;
			this.findJobAppButton.Location = new System.Drawing.Point(3, 204);
			this.findJobAppButton.Name = "findJobAppButton";
			this.findJobAppButton.Size = new System.Drawing.Size(216, 103);
			this.findJobAppButton.TabIndex = 3;
			this.findJobAppButton.Text = "Find A Job";
			this.findJobAppButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.findJobAppButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.findJobAppButton.UseVisualStyleBackColor = true;
			this.findJobAppButton.Click += new System.EventHandler(this.findJobButton_Click);
			// 
			// findAMatchAppButton
			// 
			this.findAMatchAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.findAMatchAppButton.Enabled = false;
			this.findAMatchAppButton.FlatAppearance.BorderSize = 0;
			this.findAMatchAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.findAMatchAppButton.Image = global::MyFacebookApp.View.Properties.Resources.dateButtonIcon;
			this.findAMatchAppButton.Location = new System.Drawing.Point(3, 313);
			this.findAMatchAppButton.Name = "findAMatchAppButton";
			this.findAMatchAppButton.Size = new System.Drawing.Size(216, 103);
			this.findAMatchAppButton.TabIndex = 4;
			this.findAMatchAppButton.Text = "Find A Match";
			this.findAMatchAppButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.findAMatchAppButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.findAMatchAppButton.UseVisualStyleBackColor = true;
			this.findAMatchAppButton.Click += new System.EventHandler(this.findAMatchAppButton_Click);
			// 
			// panelMainButtons
			// 
			this.panelMainButtons.Controls.Add(this.loginAppButton);
			this.panelMainButtons.Controls.Add(this.findAMatchAppButton);
			this.panelMainButtons.Controls.Add(this.findJobAppButton);
			this.panelMainButtons.Controls.Add(this.panelFaceBookTitle);
			this.panelMainButtons.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelMainButtons.Location = new System.Drawing.Point(0, 0);
			this.panelMainButtons.Name = "panelMainButtons";
			this.panelMainButtons.Size = new System.Drawing.Size(216, 536);
			this.panelMainButtons.TabIndex = 0;
			// 
			// loginAppButton
			// 
			this.loginAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.loginAppButton.FlatAppearance.BorderSize = 0;
			this.loginAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loginAppButton.Image = global::MyFacebookApp.View.Properties.Resources.loginButtonIcon;
			this.loginAppButton.Location = new System.Drawing.Point(3, 95);
			this.loginAppButton.Name = "loginAppButton";
			this.loginAppButton.Size = new System.Drawing.Size(216, 103);
			this.loginAppButton.TabIndex = 5;
			this.loginAppButton.Text = "Login With Facebook";
			this.loginAppButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.loginAppButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.loginAppButton.UseVisualStyleBackColor = true;
			this.loginAppButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// panelFaceBookTitle
			// 
			this.panelFaceBookTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(158)))), ((int)(((byte)(166)))));
			this.panelFaceBookTitle.Controls.Add(this.labelAppName);
			this.panelFaceBookTitle.Location = new System.Drawing.Point(0, 0);
			this.panelFaceBookTitle.Name = "panelFaceBookTitle";
			this.panelFaceBookTitle.Size = new System.Drawing.Size(216, 95);
			this.panelFaceBookTitle.TabIndex = 0;
			// 
			// labelAppName
			// 
			this.labelAppName.AutoSize = true;
			this.labelAppName.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
			this.labelAppName.Location = new System.Drawing.Point(-1, 33);
			this.labelAppName.Name = "labelAppName";
			this.labelAppName.Size = new System.Drawing.Size(217, 34);
			this.labelAppName.TabIndex = 0;
			this.labelAppName.Text = "Facebook App";
			this.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelShadowColorLight
			// 
			this.panelShadowColorLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(56)))));
			this.panelShadowColorLight.Controls.Add(this.panelShadowColorDark);
			this.panelShadowColorLight.Location = new System.Drawing.Point(214, 0);
			this.panelShadowColorLight.Name = "panelShadowColorLight";
			this.panelShadowColorLight.Size = new System.Drawing.Size(5, 537);
			this.panelShadowColorLight.TabIndex = 1;
			// 
			// panelShadowColorDark
			// 
			this.panelShadowColorDark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
			this.panelShadowColorDark.Location = new System.Drawing.Point(-2, 0);
			this.panelShadowColorDark.Name = "panelShadowColorDark";
			this.panelShadowColorDark.Size = new System.Drawing.Size(5, 537);
			this.panelShadowColorDark.TabIndex = 2;
			// 
			// FacebookView
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
			this.ClientSize = new System.Drawing.Size(1158, 536);
			this.Controls.Add(this.panelShadowColorLight);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.panelMainButtons);
			this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FacebookView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Facebook App";
			this.panelMainButtons.ResumeLayout(false);
			this.panelFaceBookTitle.ResumeLayout(false);
			this.panelFaceBookTitle.PerformLayout();
			this.panelShadowColorLight.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Button findJobAppButton;
		private System.Windows.Forms.Button findAMatchAppButton;
		private System.Windows.Forms.Panel panelMainButtons;
		private System.Windows.Forms.Button loginAppButton;
		private System.Windows.Forms.Panel panelFaceBookTitle;
		private System.Windows.Forms.Label labelAppName;
		private System.Windows.Forms.Panel panelShadowColorLight;
		private System.Windows.Forms.Panel panelShadowColorDark;
		private System.Windows.Forms.CheckBox checkBoxRememberMe;
		private MyFacebookApp.View.AppScreenPanel panelHomePage;
		private MyFacebookApp.View.AppScreenPanel panelJob;
		private MyFacebookApp.View.AppScreenPanel panelMatch;
		private MyFacebookApp.View.RoundedButton logoutButton;
		private MyFacebookApp.View.RoundedButton backToHomeButton;
	}
}