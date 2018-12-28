using System;
using FacebookWrapper.ObjectModel;
using static FacebookWrapper.ObjectModel.User;

namespace MyFacebookApp.Model
{
	public class AppUser
	{
		private readonly User r_LoggedInUser;

		internal AppUser(User i_LoggedInUser)
		{
			r_LoggedInUser = i_LoggedInUser;
		}

		public string ProfilePicture
		{
			get
			{
				string pictureURL;

				try
				{
					pictureURL = r_LoggedInUser.PictureNormalURL;
				}
				catch (Exception)
				{
					throw new Facebook.FacebookApiException("Couldn't fetch user's profile picture.");
				}

				return pictureURL;
			}
		}

		public string FirstName
		{
			get
			{
				string firstName;

				try
				{
					firstName = r_LoggedInUser.FirstName;
				}
				catch (Exception)
				{
					throw new Facebook.FacebookApiException("Couldn't fetch user's first name.");
				}

				return firstName;
			}
		}

		public string LastName
		{
			get
			{
				string lastName;

				try
				{
					lastName = r_LoggedInUser.LastName;
				}
				catch (Exception)
				{
					throw new Facebook.FacebookApiException("Couldn't fetch user's last name.");
				}

				return lastName;
			}
		}

		public string City
		{
			get
			{
				string cityName;

				try
				{
					cityName = r_LoggedInUser.Location.Name;
				}
				catch (Exception)
				{
					throw new Facebook.FacebookApiException("Couldn't fetch user's city.");
				}

				return cityName;
			}
		}

		public Location Location
		{
			get
			{
				Location location;

				try
				{
					location = r_LoggedInUser.Location.Location;
					if (location == null)
					{
						throw new Facebook.FacebookApiException("Couldn't fetch user's Location.");
					}
				}
				catch (Exception)
				{
					throw new Facebook.FacebookApiException("Couldn't fetch user's Location.");
				}

				return location;
			}
		}

		public string Birthday
		{
			get
			{
				string birthday;

				try
				{
					birthday = r_LoggedInUser.Birthday;
				}
				catch (Exception)
				{
					throw new Facebook.FacebookApiException("Couldn't fetch user's birthday.");
				}

				return birthday;
			}
		}

		internal FacebookObjectCollection<Page> GetLikedPages()
		{
			FacebookObjectCollection<Page> pages;

			try
			{
				pages = r_LoggedInUser.LikedPages;
			}
			catch (Exception)
			{
				throw new Facebook.FacebookApiException("Couldn't fetch user's pages.");
			}

			return pages;
		}

		public FacebookObjectCollection<Album> GetAlbums()
		{
			FacebookObjectCollection<Album> albums;

			try
			{
				albums = r_LoggedInUser.Albums;
			}
			catch (Exception)
			{
				throw new Facebook.FacebookApiException("Couldn't fetch user's albums.");
			}

			return albums;
		}

		internal eGender? GetGender()
		{
			eGender? usersGender;

			try
			{
				usersGender = r_LoggedInUser.Gender;
			}
			catch (Exception)
			{
				throw new Facebook.FacebookApiException("Couldn't fetch user's gender.");
			}

			return r_LoggedInUser.Gender;
		}

		internal FacebookObjectCollection<Event> GetEvents()
		{
			FacebookObjectCollection<Event> events;

			try
			{
				events = r_LoggedInUser.Events;
			}
			catch (Exception)
			{
				throw new Facebook.FacebookApiException("Couldn't fetch user's events.");
			}

			return events;
		}

		internal FacebookObjectCollection<Post> GetPosts()
		{
			FacebookObjectCollection<Post> posts;

			try
			{
				posts = r_LoggedInUser.Posts;
			}
			catch (Exception)
			{
				throw new Facebook.FacebookApiException("Couldn't fetch user's posts.");
			}

			return posts;
		}

		internal FacebookObjectCollection<AppUser> GetFriends()
		{
			FacebookObjectCollection<AppUser> friends = new FacebookObjectCollection<AppUser>();
			FacebookObjectCollection<User> userFriends;

			try
			{
				userFriends = r_LoggedInUser.Friends;
				foreach (User currentFriend in userFriends)
				{
					friends.Add(new AppUser(currentFriend));
				}
			}
			catch (Exception)
			{
				throw new Facebook.FacebookApiException("Couldn't fetch user's friends.");
			}

			return friends;
		}

		public Page GetWorkPlace()
		{
			WorkExperience[] allWorks;
			Page workPlace = null;

			try
			{
				allWorks = r_LoggedInUser.WorkExperiences;
				if (allWorks != null && allWorks.Length > 0)
				{
					if (r_LoggedInUser.WorkExperiences[r_LoggedInUser.WorkExperiences.Length - 1] != null)
					{
						workPlace = r_LoggedInUser.WorkExperiences[r_LoggedInUser.WorkExperiences.Length - 1].Employer;
					}
				}
			}
			catch (Exception)
			{
				throw new Facebook.FacebookApiException("Couldn't fetch user's work experience.");
			}

			return workPlace;
		}

		public WorkExperience[] GetWorkExperiences()
		{
			WorkExperience[] allWorks = null;

			try
			{
				allWorks = r_LoggedInUser.WorkExperiences;
			}
			catch (Exception)
			{
				throw new Facebook.FacebookApiException("Couldn't fetch user's work experiences.");
			}

			return allWorks;
		}

		internal eRelationshipStatus? GetRelationshipStatus()
		{
			eRelationshipStatus? userRelationshipStatus;

			try
			{
				userRelationshipStatus = r_LoggedInUser.RelationshipStatus;
			}
			catch (Exception)
			{
				throw new Facebook.FacebookApiException("Couldn't fetch user's relationship status.");
			}

			return r_LoggedInUser.RelationshipStatus;
		}
	}
}
