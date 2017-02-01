using System;
using Ninject;

namespace odgame
{
	public class InjectorHelper
	{
		private static IKernel kernel;

		public static IKernel GetKernel()
		{
			return kernel;
		}

		public static void SetKernel(IKernel krnl)
		{
			kernel = krnl;
		}

		public static T Get<T>()
		{
			return kernel.Get<T>();
		}
	}
}
