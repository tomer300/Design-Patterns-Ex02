using FacebookWrapper.ObjectModel;

// App ID: 2246590548924227
namespace MyFacebookApp.Model
{
	public class AppEngine
	{
		private readonly AppUser		r_LoggedUser;
		private Job						m_Job;
		private Match					m_Match;

		public AppEngine(AppUser i_AppUser)
		{
			r_LoggedUser = i_AppUser;
		}

		public string GetProfilePicture()
		{
			return r_LoggedUser.GetProfilePicture();
		}

		public string GetFirstName()
		{
			return r_LoggedUser.GetFirstName();
		}

		public string GetLastName()
		{
			return r_LoggedUser.GetLastName();
		}

		public FacebookObjectCollection<Album> GetAlbums()
		{
			return r_LoggedUser.GetAlbums();
		}

		public FacebookObjectCollection<AppUser> FindHitechWorkersContacts()
		{
			if (m_Job == null)
			{
				m_Job = new Job(r_LoggedUser.GetFriends());
			}

			return m_Job.FindHitechWorkersContacts();
		}

		public FacebookObjectCollection<Event> GetEvents()
		{
			return r_LoggedUser.GetEvents();
		}

		public FacebookObjectCollection<Post> GetPosts()
		{
			return r_LoggedUser.GetPosts();
		}

		public FacebookObjectCollection<AppUser> GetFriends()
		{
			return r_LoggedUser.GetFriends();
		}

		public string GetCity()
		{
			return r_LoggedUser.GetCity();
		}

		public string GetBirthday()
		{
			return r_LoggedUser.GetBirthday();
		}

		public FacebookObjectCollection<AppUser> FindAMatch(bool i_ChoseGirls, bool i_ChoseBoys, string i_AgeRange)
		{
			if (m_Match == null)
			{
				m_Match = new Match(r_LoggedUser.GetFriends());
			}

			return m_Match.FindAMatch(i_ChoseGirls, i_ChoseBoys, i_AgeRange);
		}
	}
}
