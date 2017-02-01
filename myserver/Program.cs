using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketEngine;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace myserver
{
	class MainClass
	{

		private static readonly log4net.ILog log = log4net.LogManager.GetLogger
			(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static void Main(string[] args)
		{
			log.Debug("Setup app server");

			var bootstrap = BootstrapFactory.CreateBootstrap();

			if (!bootstrap.Initialize())
			{
				Console.WriteLine("Failed to initialize!");
				Console.ReadKey();
				return;
			}

			var result = bootstrap.Start();

			Console.WriteLine("Start result: {0}!", result);

			if (result == StartResult.Failed)
			{
				Console.WriteLine("Failed to start!");
				Console.ReadKey();
				return;
			}
			Console.WriteLine("Started fine!");
			Console.ReadKey();
			return;
		}

	}
}
