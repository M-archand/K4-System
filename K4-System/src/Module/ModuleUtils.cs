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

			if (Config.GeneralSettings.LoadMessages)
				this.Logger.LogInformation("Initializing '{0}'", this.GetType().Name);

			//** ? Register Module Parts */

			Initialize_Commands();
			Initialize_Events();
		}

		public void Release(bool hotReload)
		{
			if (Config.GeneralSettings.LoadMessages)
				this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
		}
	}
}