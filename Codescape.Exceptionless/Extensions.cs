using System;
using System.Configuration;
using Exceptionless;

namespace Codescape.Exceptionless
{
	public static class Extensions
	{
		public static bool LoggingEnabled(this ExceptionlessClient client)
		{
			var logEnabled = ConfigurationManager.AppSettings["ExceptionlessLoggingEnabled"];
			if (!string.IsNullOrEmpty(logEnabled) && logEnabled.ToLower() == "true")
				return true;

			return false;
		}

		public static void Log(this ExceptionlessClient client, string logMessage, string source = null, LogLevels level = LogLevels.Info)
		{
			if (client.LoggingEnabled())
				client.CreateLog(source, logMessage, level.Text()).Submit();
		}

		public static void LogWithTags(this ExceptionlessClient client, string logMessage, string[] tags, string source = null, LogLevels level = LogLevels.Info)
		{
			if (client.LoggingEnabled())
				client.CreateLog(source, logMessage, level.Text())
					.AddTags(tags)
					.Submit();
		}
		
		private static string Text(this LogLevels level)
		{
			return Enum.GetName(typeof(LogLevels), level);
		}
	}

	public enum LogLevels
	{
		Info,
		Warn,
		Error,
		Critical
	}

}
