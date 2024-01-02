using System;
using HarmonyLib;
using UnityEngine;

namespace Displyy_Template.Backend
{
	[HarmonyPatch(typeof(VRRig), "OnDisable")]
	internal class GhostPatch : MonoBehaviour
	{
		public static bool Prefix(VRRig __instance)
		{
			return !(__instance == GorillaTagger.Instance.offlineVRRig);
		}
	}
}
