using System;
using System.Linq;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

using odgame;

namespace mylobby
{
	public class ServerModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind(x => x.FromThisAssembly()
			.SelectAllClasses()
			.InheritedFrom<IGameCommand>()
			.BindSelection((type, baseTypes) => new[] { typeof(IGameCommand) }));

			Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
			Bind<ISessionFactory>().To<SessionFactory>().InSingletonScope();

		}
	}
}
