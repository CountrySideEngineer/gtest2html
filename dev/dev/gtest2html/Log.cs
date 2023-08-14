using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html
{
	using Logger = CSEngineer.Logger.Log;

	internal static class Log
	{
		public static void TRACE(string message)
		{
#if DEBUG
			var logger = Logger.GetInstance();
			logger.TRACE(message);
#endif
		}

		public static void DEBUG(string message)
		{
#if DEBUG
			var logger = Logger.GetInstance();
			logger.DEBUG(message);
#endif
		}

		public static void INFO(string message)
		{
			var logger = Logger.GetInstance();
			logger.INFO(message);
		}

		public static void WARN(string message)
		{
			var logger = Logger.GetInstance();
			logger.WARN(message);
		}

		public static void ERROR(string message)
		{
			var logger = Logger.GetInstance();
			logger.ERROR(message);
		}

		public static void FATAL(string message)
		{
			var logger = Logger.GetInstance();
			logger.FATAL(message);
		}
	}
}
