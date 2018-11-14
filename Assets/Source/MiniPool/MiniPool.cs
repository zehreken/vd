using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace vd
{
	public enum PrefabName
	{
		Actor,
		Obstacle,
	}

	public static class MiniPool
	{
		private static readonly Dictionary<PrefabName, GameObject> Prefabs;
		private static readonly Dictionary<PrefabName, List<GameObject>> NameToObjectPool;
#if UNITY_EDITOR
		private static GameObject _infoObject;
#endif

		static MiniPool()
		{
			Prefabs = Resources.Load<PrefabDictionary>("PrefabDictionary").GetPrefabs();
			NameToObjectPool = new Dictionary<PrefabName, List<GameObject>>();
			foreach (var name in Enum.GetNames(typeof(PrefabName)))
			{
				NameToObjectPool.Add((PrefabName) Enum.Parse(typeof(PrefabName), name), new List<GameObject>());
			}

#if UNITY_EDITOR
			_infoObject = new GameObject("PoolInfo");
			_infoObject.AddComponent<PoolInfo>();
#endif
		}

		public static GameObject Create(PrefabName name, Vector3 pos)
		{
			var pool = NameToObjectPool[name];
			GameObject temp = null;
			for (int i = 0; i < pool.Count; i++)
			{
				if (!pool[i].activeInHierarchy)
				{
					pool[i].SetActive(true);
					pool[i].transform.localPosition = pos;
					temp = pool[i];
					break;
				}
			}

			if (temp == null)
			{
				temp = Object.Instantiate(Prefabs[name]);
				temp.transform.localPosition = pos;
				temp.name = name.ToString();
				pool.Add(temp);
			}

			return temp;
		}

		public static void SendToPool(this GameObject gameObject)
		{
			gameObject.SetActive(false);
		}

#if UNITY_EDITOR
		public static string GetInfo()
		{
			var s = "";
			foreach (var pair in NameToObjectPool)
			{
				s += pair.Key + ": " + pair.Value.Count;
				s += "\n";
			}

			return s;
		}
#endif
	}

	public class PoolInfo : MonoBehaviour
	{
	}
}