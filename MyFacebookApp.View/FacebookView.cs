using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using MyFacebookApp.Model;

namespace MyFacebookApp.View
{
	public partial class FacebookView : Form
	{
		private AppEngine m_AppEngine;

		public FacebookView()
		{
			InitializeComponent();
			createMutualScreenButtons();
 		}

		internal static void CreateThread(ThreadStart i_Method)
		{
			Thread thread = new Thread(i_Method);
			thread.IsBackground = true;
			thread.Start();
		}

		private void createMutualScreenButtons()
		{
			this.logoutButton = new RoundedButton();
			this.backToHomeButton = new RoundedButton();
			this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
			//
			// logoutButton
			// 
			this.logoutButton.Enabled = false;
			this.logoutButton.Location = new System.Drawing.Point(788, 10);
			this.logoutButton.Name = "logoutButton";
			this.logoutButton.Size = new System.Drawing.Size(135, 35);
			this.logoutButton.TabIndex = 10;
			this.logoutButton.Text = "Logout";
			this.logoutButton.UseVisualStyleBackColor = true;
			this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
			// 
			// backToHomeButton
			// 
			this.backToHomeButton.Location = new System.Drawing.Point(-1, 10);
			this.backToHomeButton.Name = "backToHomeButton";
			this.backToHomeButton.Size = new System.Drawing.Size(135, 35);
			this.backToHomeButton.TabIndex = 2;
			this.backToHomeButton.Text = "Back To Home";
			this.backToHomeButton.UseVisualStyleBackColor = true;
			this.backToHomeButton.Click += new System.EventHandler(this.backToHomePage);
			// 
			// checkBoxRememberMe
			// 
			this.checkBoxRememberMe.AutoSize = true;
			this.checkBoxRememberMe.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxRememberMe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
			this.checkBoxRememberMe.Location = new System.Drawing.Point(615, 11);
			this.checkBoxRememberMe.Name = "checkBoxRememberMe";
			this.checkBoxRememberMe.Size = new System.Drawing.Size(177, 27);
			this.checkBoxRememberMe.TabIndex = 1;
			this.checkBoxRememberMe.Text = "Remember Me";
			this.checkBoxRememberMe.UseVisualStyleBackColor = true;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			try
			{
				if (AppSettings.Settings.RememberUser)
				{
					m_AppEngine = FacebookManager.AutoLogin();

					if (m_AppEngine != null)
					{
						createHomePanel();
						loadSettings();
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Couldn't load settings.");
			}
		}

		private void loadSettings()
		{
			this.Location = AppSettings.Settings.Location;
			this.checkBoxRememberMe.Checked = AppSettings.Settings.RememberUser;
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			try
			{
				saveSettings();
			}
			catch (Exception)
			{
				MessageBox.Show("Couldn't save settings.");
			}
		}

		private void saveSettings()
		{
			if (panelHomePage != null)
			{
				AppSettings.Settings.RememberUser = checkBoxRememberMe.Checked;
			}

			AppSettings.Settings.Location = this.Location;
			AppSettings.Settings.SaveAppSettings();
		}

		private void findJobButton_Click(object sender, EventArgs e)
		{
			List<ButtonBase> buttons;

			panelJob = AppScreenFactory.CreateAppPanel(AppScreenFactory.eAppPanel.JOB, m_AppEngine);
			buttons = createListForButtonsToAdd();
			buttons.Add(backToHomeButton);
			panelJob.AddButtons(buttons);
			panelMain.Controls.Clear();
			panelMain.Controls.Add(panelJob);
		}

		private List<ButtonBase> createListForButtonsToAdd()
		{
			List<ButtonBase> buttonsToAdd = new List<ButtonBase>();
			buttonsToAdd.Add(logoutButton);
			buttonsToAdd.Add(checkBoxRememberMe);
			return buttonsToAdd;
		}

		private void backToHomePage(object sender, EventArgs e)
		{
			List<ButtonBase> buttons;

			panelMain.Controls.Clear();
			buttons = createListForButtonsToAdd();
			panelHomePage.AddButtons(buttons);
			panelMain.Controls.Add(panelHomePage);
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			try
			{
				m_AppEngine = FacebookManager.Login();
				createHomePanel();
			}
			catch (Exception exLogin)
			{
				MessageBox.Show(string.Format("Error! could'nt login - {0}.", exLogin.Message));
			}
		}

		private void createHomePanel()
		{
			List<ButtonBase> buttons;

			buttons = createListForButtonsToAdd();
			panelHomePage = AppScreenFactory.CreateAppPanel(AppScreenFactory.eAppPanel.HOME, m_AppEngine);
			panelHomePage.AddButtons(buttons);
			this.panelMain.Controls.Clear();
			this.panelMain.Controls.Add(this.panelHomePage);
			setAppButtonsEnabledStatus(true);
		}

		private void setAppButtonsEnabledStatus(bool i_IsEnabled)
		{
			findJobAppButton.Enabled = i_IsEnabled;
			findAMatchAppButton.Enabled = i_IsEnabled;
			logoutButton.Enabled = i_IsEnabled;
		}

		private void findAMatchAppButton_Click(object sender, EventArgs e)
		{
			List<ButtonBase> buttons;

			panelMatch = AppScreenFactory.CreateAppPanel(AppScreenFactory.eAppPanel.MATCH, m_AppEngine);
			buttons = createListForButtonsToAdd();
			buttons.Add(backToHomeButton);
			panelMatch.AddButtons(buttons);
			panelMain.Controls.Clear();
			panelMain.Controls.Add(panelMatch);
		}
		
		private void logoutButton_Click(object sender, EventArgs e)
		{
			FacebookManager.Logout();
			panelMain.Controls.Clear();
			setAppButtonsEnabledStatus(false);
		}
	}
}
