using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFacebookApp.Model
{
	public class DistanceBetweenTwoCoordinatesAdapter
	{
		public double Distance { get; private set; }
		public double CalculateDistance(double? i_LatitudeOfUser, double? i_LongitudeOfUser, double? i_LatitudeOfMatch, double? i_LongitudeOfMatch)
		{
			if (i_LatitudeOfUser == null || i_LongitudeOfUser == null || i_LatitudeOfMatch == null || i_LongitudeOfMatch == null)
			{
				throw new ArgumentNullException("While calculating distance, one of the inserted parameters is null.");
			}

			System.Device.Location.GeoCoordinate coordinatesOfUser = new System.Device.Location.GeoCoordinate((double)i_LatitudeOfUser, (double)i_LongitudeOfUser);
			System.Device.Location.GeoCoordinate coordinatesOfMatch = new System.Device.Location.GeoCoordinate((double)i_LatitudeOfMatch, (double)i_LongitudeOfMatch);

			Distance = coordinatesOfUser.GetDistanceTo(coordinatesOfMatch) / 1000;

			return Distance;
		}
	}
}
