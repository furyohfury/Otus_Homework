using System.Net.NetworkInformation;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PlayFabSystem
{
	internal static class PlayfabLogger
	{
		public static UniTask LoginWithUsername(string username)
		{
			var cts = new UniTaskCompletionSource();
			var request = new LoginWithCustomIDRequest()
			              {
				              CustomId = username, CreateAccount = true, TitleId = "1ABD51", InfoRequestParameters =
					              new GetPlayerCombinedInfoRequestParams()
					              {
						              GetPlayerProfile = true
					              }
			              };
			PlayFabClientAPI.LoginWithCustomID(request, result => OnLoginSuccess(result, cts), error => OnLoginError(error, cts));
			return cts.Task;
		}

		private static void OnLoginSuccess(LoginResult _, UniTaskCompletionSource cts)
		{
			Debug.Log("Successfully logged");
			cts.TrySetResult();
		}

		private static void OnLoginError(PlayFabError playFabError, UniTaskCompletionSource cts)
		{
			Debug.LogError("Login failed");
			Debug.LogError(playFabError.GenerateErrorReport());
			cts.TrySetException(new NetworkInformationException());
		}
	}
}