using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace MyFacebookApp.Model
{
	public sealed class AppSettings
	{
		private const string k_FileName = "\\appSettings.xml";
		private static readonly string sr_PathOfSettingsFile = Environment.CurrentDirectory + k_FileName;
		private static readonly object sr_SettingLock = new object();
		private static AppSettings m_Settings = null;

		public static AppSettings Settings
		{
			get
			{
				if (m_Settings == null)
				{
					lock (sr_SettingLock)
					{
						if (m_Settings == null)
						{
							m_Settings = loadAppSettings();
						}
					}
				}

				return m_Settings;
			}
		}

		public Point Location { get; set; }

		public string LastAccessToken { get; set; } = string.Empty;

		public bool RememberUser { get; set; } = false;

		private AppSettings()
		{
		}

		private static AppSettings loadAppSettings()
		{
			AppSettings loadedSettings = null;

			if (File.Exists(sr_PathOfSettingsFile) && new FileInfo(sr_PathOfSettingsFile).Length > 0)
			{
				using (Stream stream = new FileStream(sr_PathOfSettingsFile, FileMode.Open))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
					loadedSettings = serializer.Deserialize(stream) as AppSettings;
				}
			}
			else
			{
				loadedSettings = new AppSettings();
			}

			return loadedSettings;
		}

		public void SaveAppSettings()
		{
			FileMode	fileMode;

			fileMode = File.Exists(sr_PathOfSettingsFile) ? FileMode.Truncate : FileMode.CreateNew;

			if (!RememberUser)
			{
				LastAccessToken = null;
			}

			using (Stream stream = new FileStream(sr_PathOfSettingsFile, fileMode))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
				serializer.Serialize(stream, this);
			}
		}
	}
}