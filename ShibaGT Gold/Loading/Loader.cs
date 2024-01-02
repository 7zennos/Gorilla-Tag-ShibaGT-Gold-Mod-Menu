using System;
using Displyy_Template;
using UnityEngine;

namespace Loading
{
	public class Loader : MonoBehaviour
	{
		public static void Load()
		{
			Loader.gameobject = new GameObject();
			Loader.gameobject.AddComponent<Plugin>();
			Object.DontDestroyOnLoad(Loader.gameobject);
		}

		private static GameObject gameobject;

		public static bool loaded;
	}
}
