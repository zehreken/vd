using System;
using System.Collections.Generic;

namespace vd
{
	public static class MiniBus
	{
		private static readonly Dictionary<GameEvent, List<Action<Dictionary<string, object>>>> eventToActionMap = new Dictionary<GameEvent, List<Action<Dictionary<string, object>>>>();

		public static void SubscribeToEvent(GameEvent e, Action<Dictionary<string, object>> a)
		{
			if (!eventToActionMap.ContainsKey(e))
			{
				eventToActionMap.Add(e, new List<Action<Dictionary<string, object>>>());
			}

			eventToActionMap[e].Add(a);
		}

		public static void UnsubscribeFromEvent(GameEvent e, Action<Dictionary<string, object>> a)
		{
			if (eventToActionMap.ContainsKey(e))
			{
				eventToActionMap[e].Remove(a);
			}
		}

		public static void PublishEvent(GameEvent e, Dictionary<string, object> data = null)
		{
			if (eventToActionMap.ContainsKey(e))
			{
				foreach (var action in eventToActionMap[e])
				{
					action(data);
				}
			}
		}
	}
}