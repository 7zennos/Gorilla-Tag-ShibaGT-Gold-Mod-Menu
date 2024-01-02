using System;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace Displyy_Template.Backend
{
	[HarmonyPatch(typeof(GorillaNot), "SendReport")]
	internal class anticheatnotif : MonoBehaviour
	{
		private static bool Prefix(string susReason, string susId, string susNick)
		{
			if (susId == PhotonNetwork.LocalPlayer.UserId)
			{
				NotifiLib.SendNotification("<color=red>[ANTICHEAT] REPORTED FOR: " + susReason + "</color>");
			}
			return false;
		}
	}
}
