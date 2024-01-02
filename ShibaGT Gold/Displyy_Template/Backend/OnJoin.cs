using System;
using System.Threading;
using Displyy_Template.UI;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Realtime;

namespace Displyy_Template.Backend
{
	[HarmonyPatch(typeof(GorillaNot))]
	[HarmonyPatch("OnPlayerEnteredRoom", 0)]
	internal class OnJoin : HarmonyPatch
	{
		private static void Prefix(Player newPlayer)
		{
			new Thread(new ThreadStart(WristMenu.Red));
			if (Mods.notifs)
			{
				NotifiLib.SendNotification("<color=blue>[ROOM]:</color> Player " + newPlayer.NickName + " Joined Lobby");
			}
			new Thread(new ThreadStart(WristMenu.Red));
			new Thread(new ThreadStart(WristMenu.Red));
			new Thread(new ThreadStart(WristMenu.Red));
			new Thread(new ThreadStart(WristMenu.Red));
		}
	}
}
