using UnityEngine;
using UnityEditor;

namespace vd
{
	public class MakeScriptableObject
	{
		[MenuItem("vd/Create/GameData")]
		public static void CreateGameData()
		{
			GameData asset = ScriptableObject.CreateInstance<GameData>();

			AssetDatabase.CreateAsset(asset, "Assets/Resources/GameData.asset");
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = asset;
		}

		[MenuItem("vd/Create/PrefabDictionary")]
		public static void CreatePrefabDictionary()
		{
			PrefabDictionary asset = ScriptableObject.CreateInstance<PrefabDictionary>();

			AssetDatabase.CreateAsset(asset, "Assets/Resources/PrefabDictionary.asset");
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = asset;
		}

		[MenuItem("vd/Create/AudioDictionary")]
		public static void CreateAudioDictionary()
		{
			AudioDictionary asset = ScriptableObject.CreateInstance<AudioDictionary>();

			AssetDatabase.CreateAsset(asset, "Assets/Resources/AudioDictionary.asset");
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = asset;
		}
	}
}