namespace K4System
{
	using Microsoft.Extensions.Logging;

	using CounterStrikeSharp.API.Core.Plugin;

	public partial class ModuleUtils : IModuleUtils
	{
		public ModuleUtils(ILogger<ModuleUtils> logger, IPluginContext pluginContext)
		{
			this.Logger = logger;
			this.pluginContext = pluginContext;
		}

		public void Initialize(bool hotReload)
		{
			this.plugin = (pluginContext.Plugin as Plugin)!;
			this.Config = plugin.Config;

			this.Logger.LogInformation("Initializing '{0}'", this.GetType().Name);

			//** ? Register Module Parts */

			Initialize_Commands();
		}

		public void Release(bool hotReload)
		{
			this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
		}
	}
}