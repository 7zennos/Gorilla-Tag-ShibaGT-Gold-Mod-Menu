using System;
using dark.efijiPOIWikjek;
using Displyy_Template.Backend;
using Displyy_Template.UI;
using GorillaLocomotion;
using GTAG_NotificationLib;
using HarmonyLib;
using UnityEngine;

namespace Displyy_Template
{
	[HarmonyPatch(typeof(Player), "FixedUpdate")]
	internal class UpdatePatch
	{
		private static void Postfix()
		{
			if (!UpdatePatch.alreadyInit)
			{
				UpdatePatch.alreadyInit = true;
				UpdatePatch.Gameobject = new GameObject();
				UpdatePatch.Gameobject.AddComponent<Plugin>();
				UpdatePatch.Gameobject.AddComponent<WristMenu>();
				UpdatePatch.Gameobject.AddComponent<RigShit>();
				UpdatePatch.Gameobject.AddComponent<Mods>();
				UpdatePatch.Gameobject.AddComponent<MenusGUI>();
				UpdatePatch.Gameobject.AddComponent<GhostPatch>();
				UpdatePatch.Gameobject.AddComponent<NotifiLib>();
				Mods.Load();
				Mods.LoadOnButtons();
				Object.DontDestroyOnLoad(UpdatePatch.Gameobject);
			}
		}

		private static bool alreadyInit;

		public static GameObject Gameobject;
	}
}
