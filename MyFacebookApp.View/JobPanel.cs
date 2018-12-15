using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using MyFacebookApp.Model;

namespace MyFacebookApp.View
{
	public partial class JobPanel : UserControl
	{
		private readonly AppEngine	r_AppEngine;
		private int					m_LastChosenContactIndex;

		public JobPanel(AppEngine i_AppEngine)
		{
			InitializeComponent();
			r_AppEngine = i_AppEngine;
		}

		public void AddLogoutButton(Button i_LogoutButton)
		{
			Controls.Add(i_LogoutButton);
		}

		public void AddBackToHomeButton(Button i_BackToHomeButton)
		{
			Controls.Add(i_BackToHomeButton);
		}

		private void findAJobButton_Click(object sender, EventArgs e)
		{
			FacebookObjectCollection<AppUser>	hitechWorkerContacts;
			bool								hasShownMessageBox = false;

			listBoxJobs.Items.Clear();
			flowLayoutPanelContactPhotos.Controls.Clear();
			try
			{
				hitechWorkerContacts = r_AppEngine.GetFriends(); //r_AppEngine.FindHitechWorkersContacts();
				if (hitechWorkerContacts != null && hitechWorkerContacts.Count > 0)
				{
					foreach (AppUser currentContact in hitechWorkerContacts)
					{
						addContactToListBoxJobs(currentContact, ref hasShownMessageBox);
					}
					FriendsDisplayer displayer = new FriendsDisplayer(hitechWorkerContacts, flowLayoutPanelContactPhotos);
					displayer.FriendOnClickDelegate += contactPic_Click;
					displayer.Display();

				}
				else
				{
					MessageBox.Show("Couldnt fetch work experience.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			listBoxJobs.SelectedIndexChanged += new EventHandler(contactInfo_Click);
		}

		private void addContactToListBoxJobs(AppUser i_CurrentContact, ref bool io_HasShownMessageBox)
		{
			string contactFullName = string.Empty;
			string contactFirstName = string.Empty;
			string contactLastName = string.Empty;
			string workPlace = string.Empty;

			try
			{
				contactFirstName = i_CurrentContact.GetFirstName();
				contactLastName = i_CurrentContact.GetLastName();
				workPlace = i_CurrentContact.GetWorkPlace()?.Name;
			}
			catch (Exception ex)
			{
				if (!io_HasShownMessageBox)
				{
					MessageBox.Show(ex.Message);
					io_HasShownMessageBox = true;
				}
			}
			finally
			{

				contactFullName = string.Format("{0} {1}", contactFirstName, contactLastName);
				listBoxJobs.Items.Add(
					new ContactItem(new KeyValuePair<string, string>(
						contactFullName,
						string.Format("{0} works at", contactFullName, workPlace))));
			}
		}

		private void contactInfo_Click(object sender, EventArgs e)
		{
			PictureBox	lastChosenContactPhoto = flowLayoutPanelContactPhotos.Controls[m_LastChosenContactIndex] as PictureBox;
			ContactItem contactClicked;
			PictureBox	contactPicture;
			string		contactName = string.Empty;

			if (lastChosenContactPhoto != null)
			{
				lastChosenContactPhoto.BorderStyle = BorderStyle.None;
			}

			m_LastChosenContactIndex = listBoxJobs.SelectedIndex;
			contactClicked = listBoxJobs.Items[m_LastChosenContactIndex] as ContactItem;
			if (contactClicked != null)
			{
				contactName = contactClicked.Contact.Key;
				foreach (Control currentPicture in flowLayoutPanelContactPhotos.Controls)
				{
					contactPicture = currentPicture as PictureBox;
					if (contactPicture != null)
					{
						if (contactPicture.Name.Equals(contactName))
						{
							contactPicture.BorderStyle = BorderStyle.Fixed3D;
							contactPicture.Focus();
						}
					}
				}
			}
		}

		private void contactPic_Click(object sender, EventArgs e)
		{
			PictureBox	clickedContact = sender as PictureBox;
			ContactItem currentContactInfo;
			string		contactName;

			if (clickedContact != null)
			{
				contactName = clickedContact.Name;
				foreach (object currentItem in listBoxJobs.Items)
				{
					currentContactInfo = currentItem as ContactItem;
					if (currentContactInfo != null)
					{
						if (currentContactInfo.Contact.Key.Equals(contactName))
						{
							listBoxJobs.SetSelected(listBoxJobs.Items.IndexOf(currentItem), true);
							break;
						}
					}
				}
			}
		}

		private class ContactItem
		{
			public KeyValuePair<string, string> Contact { get; private set; }

			public ContactItem(KeyValuePair<string, string> i_Contact)
			{
				Contact = i_Contact;
			}

			public override string ToString()
			{
				return Contact.Value;
			}
		}
	}
}
