using FacebookWrapper.ObjectModel;

// App ID: 2246590548924227
namespace MyFacebookApp.Model
{
	public class AppEngine
	{
		private Job		m_Job;
		private Match	m_Match;
		private IDistance m_DistanceAdapter;

		public IDistance DistanceBetweenTwoCoordinatesAdapter
		{
			get
			{
				if (m_DistanceAdapter == null)
				{
					m_DistanceAdapter = new DistanceBetweenTwoCoordinatesAdapter();
				}

				return m_DistanceAdapter;
			}
		}

		public AppUser LoggedUser { get; private set; }

		public AppEngine(AppUser i_AppUser)
		{
			LoggedUser = i_AppUser;
		}

		public string ProfilePicture
		{
			get
			{
				return LoggedUser.ProfilePicture;
			}
		}

		public string FirstName
		{
			get
			{
				return LoggedUser.FirstName;
			}
		}

		public string LastName
		{
			get
			{
				return LoggedUser.LastName;
			}
		}

		public string City
		{
			get
			{
				return LoggedUser.City;
			}
		}

		public string Birthday
		{
			get
			{
				return LoggedUser.Birthday;
			}
		}

		public FacebookObjectCollection<Album> Albums
		{
			get
			{
				return LoggedUser.GetAlbums();
			}
		}

		public FacebookObjectCollection<Post> Posts
		{
			get
			{
				return LoggedUser.GetPosts();
			}
		}

		public FacebookObjectCollection<Page> LikedPages
		{
			get
			{
				return LoggedUser.GetLikedPages();
			}
		}

		public FacebookObjectCollection<Event> Events
		{
			get
			{
				return LoggedUser.GetEvents();
			}
		}

		public FacebookObjectCollection<AppUser> Friends
		{
			get
			{
				return LoggedUser.GetFriends();
			}
		}

		public WorkExperience[] WorkExperiences
		{
			get
			{
				return LoggedUser.GetWorkExperiences();
			}
		}

		public FacebookObjectCollection<AppUser> FindAMatch(bool i_ChoseGirls, bool i_ChoseBoys, string i_AgeRange)
		{
			if (m_Match == null)
			{
				m_Match = new Match(LoggedUser.GetFriends());
			}

			return m_Match.FindAMatch(i_ChoseGirls, i_ChoseBoys, i_AgeRange);
		}

		public FacebookObjectCollection<AppUser> FindHitechWorkersContacts()
		{
			if (m_Job == null)
			{
				m_Job = new Job(LoggedUser.GetFriends());
			}

			return m_Job.FindHitechWorkersContacts();
		}
	}
}
