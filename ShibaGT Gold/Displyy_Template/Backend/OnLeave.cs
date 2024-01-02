using System;
using System.Threading;
using Displyy_Template.UI;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;

namespace Displyy_Template.Backend
{
	[HarmonyPatch(typeof(GorillaNot))]
	[HarmonyPatch("OnPlayerLeftRoom", 0)]
	internal class OnLeave : HarmonyPatch
	{
		private static void Prefix(Player otherPlayer)
		{
			new Thread(new ThreadStart(WristMenu.Red));
			if (otherPlayer != PhotonNetwork.LocalPlayer)
			{
				if (Mods.notifs)
				{
					NotifiLib.SendNotification("<color=blue>[ROOM]:</color> Player " + otherPlayer.NickName + " Left Lobby");
				}
				if (PhotonNetwork.IsMasterClient)
				{
					NotifiLib.SendNotification("<color=yellow>[ROOM]: YOU ARE NOW MASTER CLIENT!</color>");
				}
			}
			new Thread(new ThreadStart(WristMenu.Red));
		}
	}
}
