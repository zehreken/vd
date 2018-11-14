using System.Collections.Generic;
using UnityEngine;

namespace vd
{
	public class PrefabDictionary : ScriptableObject
	{
		public PrefabName[] Names;
		public GameObject[] Prefabs;

		public Dictionary<PrefabName, GameObject> GetPrefabs()
		{
			var dictionary = new Dictionary<PrefabName, GameObject>();
			for (int i = 0; i < Names.Length; i++)
			{
				dictionary.Add(Names[i], Prefabs[i]);
			}

			return dictionary;
		}
	}
}