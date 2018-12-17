using System;
using FacebookWrapper;

namespace MyFacebookApp.Model
{
	public sealed class FacebookManager
	{
		private FacebookManager()
		{
		}

		public static AppEngine Login()
		{
				LoginResult loginResult = FacebookService.Login(
				/*"user_relationships",
				"user_relationship_details",
				"user_work_history",*/
				"2246590548924227",
				"public_profile",
				"user_birthday",
				"user_gender",
				"user_friends",
				"user_events",
				"user_hometown",
				"user_likes",
				"user_location",
				"user_tagged_places",
				"user_photos",
				"user_posts");

			// The documentation regarding facebook login and permissions can be found here:	 
			// https://developers.facebook.com/docs/facebook-login/permissions#reference
			if (!string.IsNullOrEmpty(loginResult.AccessToken))
			{
				AppSettings.Settings.LastAccessToken = loginResult.AccessToken;
				return new AppEngine(new AppUser(loginResult.LoggedInUser));
			}
			else
			{
				throw new Exception(loginResult.ErrorMessage);
			}
		}

		public static void Logout()
		{
			FacebookService.Logout(null);
		}

		public static AppEngine AutoLogin()
		{
			AppEngine appEngine = null;

			if(AppSettings.Settings.RememberUser && !string.IsNullOrEmpty(AppSettings.Settings.LastAccessToken))
			{
				LoginResult loginResult = FacebookService.Connect(AppSettings.Settings.LastAccessToken);
				appEngine = new AppEngine(new AppUser(loginResult.LoggedInUser));
			}

			return appEngine;
		}
	}
}
