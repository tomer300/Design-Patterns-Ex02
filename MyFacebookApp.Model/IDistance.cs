using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFacebookApp.Model
{
	public interface IDistance
	{
		double GetDistanceTo(double? i_LatitudeOfUser, double? i_LongitudeOfUser, double? i_LatitudeOfMatch, double? i_LongitudeOfMatch);
	}
}
