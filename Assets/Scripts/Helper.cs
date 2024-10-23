using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RealTime
{
	public class Helper : MonoBehaviour
	{
		private void Start()
		{
			Application.targetFrameRate = 60;
		}


		[Button]
		public void ShowIP()
		{
			string hostName = Dns.GetHostName();
			Debug.Log(hostName);

			// Get the IP from GetHostByName method of dns class. 
			string IP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
			// Debug.Log(Dns.GetHostEntry(Dns.GetHostName())
			// .AddressList
			// 	.First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
			// 	.ToString());
			foreach (var address in Dns.GetHostEntry(hostName).AddressList)
			{
				Debug.Log(address);
			}
			
			
		}

		[Button]
		public void ShowDateTimeNow()
		{
			Debug.Log(DateTime.Now.ToString("dd/MM/yy HH:mm:ss"));
		}
		
		[Button]
		public void ShowTimezone()
		{
			Debug.Log(TimeZoneInfo.Local.DisplayName);
			Debug.Log(TimeZoneInfo.Local.Id);
			Debug.Log(TimeZoneInfo.Local.StandardName);
		}

		[Button]
		public void ShowPath()
		{
			Debug.Log(Path.Combine(Application.persistentDataPath, "ChestData.json"));
		}
	}
}