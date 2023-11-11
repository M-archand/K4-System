using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Nexd.MySQL;

namespace K4ryuuSystem
{
	public class Rank
	{
		public int Exp { get; set; }
		public string Color { get; set; } = "Default";
	}

	public class User
	{
		public int Points { get; set; }
		public string Rank { get; set; } = "None";
		public string RankColor { get; set; } = $"{ChatColors.Default}";
		public int RankPoints { get; set; } = 0;
		public bool SpawnedThisRound { get; set; } = false;
		public Dictionary<string, DateTime> Times { get; set; } = new Dictionary<string, DateTime>();
	}

	public class PlayerCache<T> : Dictionary<int, T>
	{
		public T this[CCSPlayerController controller]
		{
			get { return (T)this[controller.UserId!.Value]; }
			set { this[controller.UserId!.Value] = value; }
		}

		public T GetFromIndex(int index)
		{
			return (T)this[index - 1];
		}

		public bool ContainsPlayer(CCSPlayerController player)
		{
			return base.ContainsKey(player.UserId!.Value);
		}

		public bool RemovePlayer(CCSPlayerController player)
		{
			return base.Remove(player.UserId!.Value);
		}
	}

	public enum CHANGE_MODE
	{
		SET = 0,
		GIVE,
		REMOVE
	}

	public partial class K4System
	{
		MySqlDb? MySql = null;
		internal Dictionary<int, (int killStreak, DateTime lastKillTime)> playerKillStreaks = new Dictionary<int, (int, DateTime)>();
		private Dictionary<string, Rank> ranks = new Dictionary<string, Rank>();
		internal static PlayerCache<User> PlayerSummaries = new PlayerCache<User>();
		internal string noneRank = "None";
	}
}