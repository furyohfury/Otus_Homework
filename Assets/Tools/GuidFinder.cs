using UnityEditor;
using UnityEngine;

public class GuidFinder
{
	[MenuItem("Tools/Find Asset by GUID")]
	public static void FindAssetByGUID()
	{
		string targetGUID = "098f57384b5148a5a26f4d98e6aa9064";
		string path = AssetDatabase.GUIDToAssetPath(targetGUID);

		if (!string.IsNullOrEmpty(path))
		{
			Debug.Log("Asset path: " + path);
			Object obj = AssetDatabase.LoadAssetAtPath<Object>(path);
			Selection.activeObject = obj;
		}
		else
		{
			Debug.LogWarning("GUID not found: " + targetGUID);
		}
	}
}