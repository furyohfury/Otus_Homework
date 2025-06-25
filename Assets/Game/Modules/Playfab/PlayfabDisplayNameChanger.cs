using System.Net.NetworkInformation;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace PlayFabSystem
{
	internal static class PlayfabDisplayNameChanger
	{
		public static UniTask ChangeDisplayName(string username)
		{
			var cts = new UniTaskCompletionSource();
			var displayNameRequest = new UpdateUserTitleDisplayNameRequest()
			                         {
				                         DisplayName = username
			                         };
			PlayFabClientAPI.UpdateUserTitleDisplayName(displayNameRequest,
				result => OnDisplayNameChanged(result, cts),
				error => OnDisplayNameChangeError(error, cts)
			);

			return cts.Task;
		}

		private static void OnDisplayNameChanged(UpdateUserTitleDisplayNameResult result, UniTaskCompletionSource cts)
		{
			Debug.Log("Display name changed");
			cts.TrySetResult();
		}

		private static void OnDisplayNameChangeError(PlayFabError error, UniTaskCompletionSource cts)
		{
			Debug.LogError($"Couldnt change display name + {error.GenerateErrorReport()}");
			cts.TrySetException(new NetworkInformationException());
		}
	}
}