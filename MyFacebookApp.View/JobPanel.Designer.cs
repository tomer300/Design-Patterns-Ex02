namespace MyFacebookApp.View
{
	partial class JobPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobPanel));
			this.flowLayoutPanelContactPhotos = new System.Windows.Forms.FlowLayoutPanel();
			this.listBoxJobs = new System.Windows.Forms.ListBox();
			this.labelInformation = new System.Windows.Forms.Label();
			this.findAJobRoundedButton = new MyFacebookApp.View.RoundedButton();
			this.SuspendLayout();
			// 
			// flowLayoutPanelContactPhotos
			// 
			this.flowLayoutPanelContactPhotos.AutoScroll = true;
			this.flowLayoutPanelContactPhotos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.flowLayoutPanelContactPhotos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelContactPhotos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.flowLayoutPanelContactPhotos.Location = new System.Drawing.Point(101, 347);
			this.flowLayoutPanelContactPhotos.Name = "flowLayoutPanelContactPhotos";
			this.flowLayoutPanelContactPhotos.Size = new System.Drawing.Size(732, 168);
			this.flowLayoutPanelContactPhotos.TabIndex = 5;
			// 
			// listBoxJobs
			// 
			this.listBoxJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
			this.listBoxJobs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxJobs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.listBoxJobs.FormattingEnabled = true;
			this.listBoxJobs.ItemHeight = 23;
			this.listBoxJobs.Location = new System.Drawing.Point(208, 183);
			this.listBoxJobs.Name = "listBoxJobs";
			this.listBoxJobs.Size = new System.Drawing.Size(529, 142);
			this.listBoxJobs.TabIndex = 4;
			// 
			// labelInformation
			// 
			this.labelInformation.AutoSize = true;
			this.labelInformation.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.labelInformation.Location = new System.Drawing.Point(174, 65);
			this.labelInformation.Name = "labelInformation";
			this.labelInformation.Size = new System.Drawing.Size(706, 30);
			this.labelInformation.TabIndex = 6;
			this.labelInformation.Text = "Find friends who can help you in your job - hunt in Hi-Tech!";
			this.labelInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// findAJobRoundedButton
			// 
			this.findAJobRoundedButton.BackColor = System.Drawing.Color.Transparent;
			this.findAJobRoundedButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("findAJobRoundedButton.BackgroundImage")));
			this.findAJobRoundedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.findAJobRoundedButton.FlatAppearance.BorderSize = 0;
			this.findAJobRoundedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.findAJobRoundedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.findAJobRoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.findAJobRoundedButton.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.findAJobRoundedButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(34)))), ((int)(((byte)(62)))));
			this.findAJobRoundedButton.Location = new System.Drawing.Point(358, 121);
			this.findAJobRoundedButton.Name = "findAJobRoundedButton";
			this.findAJobRoundedButton.Size = new System.Drawing.Size(186, 45);
			this.findAJobRoundedButton.TabIndex = 7;
			this.findAJobRoundedButton.Text = "Find me a job!";
			this.findAJobRoundedButton.UseVisualStyleBackColor = false;
			this.findAJobRoundedButton.Click += new System.EventHandler(this.findAJobButton_Click);
			// 
			// JobPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
			this.Controls.Add(this.findAJobRoundedButton);
			this.Controls.Add(this.labelInformation);
			this.Controls.Add(this.flowLayoutPanelContactPhotos);
			this.Controls.Add(this.listBoxJobs);
			this.Name = "JobPanel";
			this.Size = new System.Drawing.Size(936, 537);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContactPhotos;
		private System.Windows.Forms.ListBox listBoxJobs;
		private System.Windows.Forms.Label labelInformation;
		private MyFacebookApp.View.RoundedButton findAJobRoundedButton;
	}
}
