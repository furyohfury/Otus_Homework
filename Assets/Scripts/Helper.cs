using System;
using System.Net;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RealTime
{
	public class Helper : MonoBehaviour
	{
		[Button]
		public void ShowIP()
		{
			string hostName = Dns.GetHostName();
			Debug.Log(hostName);

			// Get the IP from GetHostByName method of dns class. 
			string IP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
			Debug.Log("IP Address is : " + IP);
		}

		[Button]
		public async void GetTimeByIP()
		{
			var r = await ServerTimeManager.GetServerTimeByIPAsync();
			Debug.Log(r.ToString("g"));
		}
	}
}