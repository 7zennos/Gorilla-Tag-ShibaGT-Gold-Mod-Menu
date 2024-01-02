﻿using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GTAG_NotificationLib
{
	public class NotifiLib : MonoBehaviour
	{
		private void Init()
		{
			this.MainCamera = GameObject.Find("Main Camera");
			this.HUDObj = new GameObject();
			this.HUDObj2 = new GameObject();
			this.HUDObj2.name = "NOTIFICATIONLIB_HUD_OBJ";
			this.HUDObj.name = "NOTIFICATIONLIB_HUD_OBJ";
			this.HUDObj.AddComponent<Canvas>();
			this.HUDObj.AddComponent<CanvasScaler>();
			this.HUDObj.AddComponent<GraphicRaycaster>();
			this.HUDObj.GetComponent<Canvas>().enabled = true;
			this.HUDObj.GetComponent<Canvas>().renderMode = 2;
			this.HUDObj.GetComponent<Canvas>().worldCamera = this.MainCamera.GetComponent<Camera>();
			this.HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5f, 5f);
			this.HUDObj.GetComponent<RectTransform>().position = new Vector3(this.MainCamera.transform.position.x, this.MainCamera.transform.position.y, this.MainCamera.transform.position.z);
			this.HUDObj2.transform.position = new Vector3(this.MainCamera.transform.position.x, this.MainCamera.transform.position.y, this.MainCamera.transform.position.z - 4.6f);
			this.HUDObj.transform.parent = this.HUDObj2.transform;
			this.HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
			Vector3 eulerAngles = this.HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
			eulerAngles.y = -270f;
			this.HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
			this.HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(eulerAngles);
			this.Testtext = new GameObject
			{
				transform = 
				{
					parent = this.HUDObj.transform
				}
			}.AddComponent<Text>();
			this.Testtext.text = "";
			this.Testtext.fontSize = 10;
			this.Testtext.font = GameObject.Find("COC Text").GetComponent<Text>().font;
			this.Testtext.rectTransform.sizeDelta = new Vector2(260f, 70f);
			this.Testtext.alignment = 6;
			this.Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
			this.Testtext.rectTransform.localPosition = new Vector3(-1.2f, -0.7f, -0.6f);
			this.Testtext.material = this.AlertText;
			NotifiLib.NotifiText = this.Testtext;
		}

		private void FixedUpdate()
		{
			if (!this.HasInit && GameObject.Find("Main Camera") != null)
			{
				this.Init();
				this.HasInit = true;
			}
			this.HUDObj2.transform.position = new Vector3(this.MainCamera.transform.position.x, this.MainCamera.transform.position.y, this.MainCamera.transform.position.z);
			this.HUDObj2.transform.rotation = this.MainCamera.transform.rotation;
			if (this.Testtext.text != "")
			{
				this.NotificationDecayTimeCounter++;
				if (this.NotificationDecayTimeCounter > this.NotificationDecayTime)
				{
					this.Notifilines = null;
					this.newtext = "";
					this.NotificationDecayTimeCounter = 0;
					this.Notifilines = this.Testtext.text.Split(Environment.NewLine.ToCharArray()).Skip(1).ToArray<string>();
					foreach (string text in this.Notifilines)
					{
						if (text != "")
						{
							this.newtext = this.newtext + text + "\n";
						}
					}
					this.Testtext.text = this.newtext;
					return;
				}
			}
			else
			{
				this.NotificationDecayTimeCounter = 0;
			}
		}

		public static void SendNotification(string NotificationText)
		{
			if (NotifiLib.ropedelay < Time.time)
			{
				NotifiLib.ropedelay = Time.time + 0.05f;
				if (NotifiLib.IsEnabled)
				{
					if (!NotificationText.Contains(Environment.NewLine))
					{
						NotificationText += Environment.NewLine;
					}
					NotifiLib.NotifiText.text = NotifiLib.NotifiText.text + NotificationText;
					NotifiLib.PreviousNotifi = NotificationText;
				}
			}
		}

		public static void ClearAllNotifications()
		{
			NotifiLib.NotifiText.text = "";
		}

		public static void ClearPastNotifications(int amount)
		{
			string text = "";
			foreach (string text2 in NotifiLib.NotifiText.text.Split(Environment.NewLine.ToCharArray()).Skip(amount).ToArray<string>())
			{
				if (text2 != "")
				{
					text = text + text2 + "\n";
				}
			}
			NotifiLib.NotifiText.text = text;
		}

		private GameObject HUDObj;

		private GameObject HUDObj2;

		private GameObject MainCamera;

		private Text Testtext;

		private Material AlertText = new Material(Shader.Find("GUI/Text Shader"));

		private int NotificationDecayTime = 275;

		private int NotificationDecayTimeCounter = 275;

		public static int NoticationThreshold = 10;

		private string[] Notifilines;

		private string newtext;

		public static string PreviousNotifi;

		private bool HasInit;

		private static Text NotifiText;

		public static bool IsEnabled = true;

		public static float ropedelay;
	}
}
