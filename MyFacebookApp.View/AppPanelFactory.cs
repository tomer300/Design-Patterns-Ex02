﻿using MyFacebookApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFacebookApp.View
{
	internal static class AppPanelFactory
	{
		public static AppScreenPanel CreateAppPanel(eAppPanel i_Panel, AppEngine i_AppEngine) {
			AppScreenPanel newPanel;

			switch (i_Panel)
			{
				case eAppPanel.HOME:
					{
						newPanel = new HomePanel(i_AppEngine);
						break;
					}
				case eAppPanel.JOB:
					{
						newPanel = new JobPanel(i_AppEngine);
						break;
					}
				case eAppPanel.MATCH:
					{
						newPanel = new MatchPanel(i_AppEngine);
						break;
					}
				default:
					{
						newPanel = null;
						break;
					}
					
					
			}

			return newPanel;
		}
		public enum eAppPanel{
			HOME,
			JOB,
			MATCH
		}
	}

}
