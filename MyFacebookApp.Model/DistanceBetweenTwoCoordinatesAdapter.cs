using System;

namespace MyFacebookApp.Model
{
	public class DistanceBetweenTwoCoordinatesAdapter : IDistance
	{
		private System.Device.Location.GeoCoordinate m_CoordinatesOfUser;
		private System.Device.Location.GeoCoordinate m_CoordinatesOfMatch;

		public double Distance { get; private set; }

		public double GetDistanceTo(double? i_LatitudeOfUser, double? i_LongitudeOfUser, double? i_LatitudeOfMatch, double? i_LongitudeOfMatch)
		{
			if (i_LatitudeOfUser == null || i_LongitudeOfUser == null || i_LatitudeOfMatch == null || i_LongitudeOfMatch == null)
			{
				throw new ArgumentNullException("While calculating distance, one of the inserted parameters is null.");
			}

			m_CoordinatesOfUser = new System.Device.Location.GeoCoordinate((double)i_LatitudeOfUser, (double)i_LongitudeOfUser);
			m_CoordinatesOfMatch = new System.Device.Location.GeoCoordinate((double)i_LatitudeOfMatch, (double)i_LongitudeOfMatch);
			Distance = m_CoordinatesOfUser.GetDistanceTo(m_CoordinatesOfMatch);

			return Distance;
		}
	}
}
