using UnityEditor;
using UnityEngine;

namespace vd
{
	public static class MenuItems
	{
		[MenuItem("vd/Clear PlayerPrefs")]
		public static void ClearPlayerPrefs()
		{
			PlayerPrefs.DeleteAll();
		}
	}
}