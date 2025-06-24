using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public sealed class FuckingEditorOnlyTagHelper : MonoBehaviour
	{
		[Button]
		private void DoShit()
		{
			GameObject[] editorOnlyGameObjects = GameObject.FindGameObjectsWithTag("EditorOnly");
			for (int i = 0, count = editorOnlyGameObjects.Length; i < count; i++)
			{
				editorOnlyGameObjects[i].tag = "Untagged";
			}
		}
	}
}