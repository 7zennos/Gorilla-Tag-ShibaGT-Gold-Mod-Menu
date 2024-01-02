using System;
using BepInEx;
using HarmonyLib;
using Loading;
using UnityEngine;

namespace Displyy_Template
{
	[BepInPlugin("goldmenuyhippe", "org.shibagtiskinda.shiba.fun", "1.0")]
	public class Plugin : BaseUnityPlugin
	{
		private void Awake()
		{
			if (!this.patchedHarmony && !Loader.loaded)
			{
				new Harmony("org.shibagtiskinda.shiba.fun").PatchAll();
				this.patchedHarmony = true;
				Loader.loaded = true;
			}
		}

		public const string Name = "goldmenuyhippe";

		public const string GUID = "org.shibagtiskinda.shiba.fun";

		public const string Version = "1.0";

		private bool patchedHarmony;

		private static GameObject Gameobject;

		[Serializable]
		public class LoginData
		{
			public string license;
		}
	}
}
