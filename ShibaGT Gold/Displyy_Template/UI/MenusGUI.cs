using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BepInEx;
using Displyy_Template.Backend;
using GorillaLocomotion;
using GorillaNetworking;
using Photon.Pun;
using UnityEngine;

namespace Displyy_Template.UI
{
	internal class MenusGUI : MonoBehaviour
	{
		private void Start()
		{
			if (File.Exists("GoldPrefs\\WASDPrefsMovement.txt"))
			{
				MenusGUI.savedFCMovmentSpeed = float.Parse(File.ReadAllText("GoldPrefs\\WASDPrefsMovement.txt"), CultureInfo.InvariantCulture.NumberFormat);
				MenusGUI.FCMovmentSpeed = MenusGUI.savedFCMovmentSpeed;
			}
			if (File.Exists("GoldPrefs\\WASDPrefsJump.txt"))
			{
				MenusGUI.savedFCJumpSpeed = float.Parse(File.ReadAllText("GoldPrefs\\WASDPrefsJump.txt"), CultureInfo.InvariantCulture.NumberFormat);
				MenusGUI.FCJumpSpeed = MenusGUI.savedFCJumpSpeed;
			}
			if (File.Exists("GoldPrefs\\WASDPrefsRotation.txt"))
			{
				MenusGUI.savedFcRotation = float.Parse(File.ReadAllText("GoldPrefs\\WASDPrefsRotation.txt"), CultureInfo.InvariantCulture.NumberFormat);
				MenusGUI.FcRotation = MenusGUI.savedFcRotation;
			}
		}

		private void OnGUI()
		{
			if (MenusGUI.arrayliston)
			{
				foreach (ButtonInfo buttonInfo in WristMenu.buttons)
				{
					bool? enabled = buttonInfo.enabled;
					bool flag = true;
					if (enabled.GetValueOrDefault() == flag & enabled != null)
					{
						if (this.labelText == null)
						{
							this.labelText += buttonInfo.buttonText;
						}
						else
						{
							this.labelText = this.labelText + "\n" + buttonInfo.buttonText;
						}
						GUI.color = Color.Lerp(Color.cyan, Color.magenta, Mathf.PingPong(Time.time + (float)WristMenu.buttons.IndexOf(buttonInfo) / ((float)WristMenu.buttons.Count / 2f) - 1f, 1f));
					}
				}
				foreach (ButtonInfo buttonInfo2 in WristMenu.settingsbuttons)
				{
					bool? enabled = buttonInfo2.enabled;
					bool flag = true;
					if (enabled.GetValueOrDefault() == flag & enabled != null)
					{
						if (this.labelText == null)
						{
							this.labelText += buttonInfo2.buttonText;
						}
						else
						{
							this.labelText = this.labelText + "\n" + buttonInfo2.buttonText;
						}
						GUI.color = Color.Lerp(Color.cyan, Color.magenta, Mathf.PingPong(Time.time + (float)WristMenu.buttons.IndexOf(buttonInfo2) / ((float)WristMenu.buttons.Count / 2f) - 1f, 1f));
					}
				}
				this.labelStyle = new GUIStyle(GUI.skin.label);
				this.labelStyle.alignment = 2;
				this.labelStyle.fontSize = 21;
				float num = 500f;
				float num2 = 999f;
				float num3 = (float)Screen.width - num - 10f;
				float num4 = 50f;
				string[] value = (from line in this.labelText.Split(new char[]
				{
					'\n'
				})
				orderby -this.labelStyle.CalcSize(new GUIContent(line)).x
				select line).ToArray<string>();
				string text = string.Join("\n", value);
				this.labelText = text;
				GUI.Label(new Rect(num3, num4, num, num2), this.labelText, this.labelStyle);
				GUI.Label(new Rect(num3, 10f, num, num2), "Click F3 To Close", this.labelStyle);
				this.labelText = null;
			}
			if (this.on)
			{
				GUI.backgroundColor = Color.Lerp(Mods.firstcolor, Mods.secondcolor, Mathf.PingPong(Time.time, 1f));
				GUI.contentColor = Color.Lerp(Mods.firstcolor, Mods.secondcolor, Mathf.PingPong(Time.time, 1f));
				GUI.color = Color.Lerp(Mods.firstcolor, Mods.secondcolor, Mathf.PingPong(Time.time, 1f));
				int num5 = Mathf.RoundToInt(1f / Time.deltaTime);
				this.GuiRect = GUI.Window(9999, this.GuiRect, new GUI.WindowFunction(this.MainWindowFunction), "<color=white>gold [f2 to close]</color> <color=yellow>FPS: " + num5.ToString() + "</color>");
			}
		}

		public void MainWindowFunction(int WindowId)
		{
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
			GUI.Box(new Rect(0f, 0f, 97f, 232f), "");
			if (GUI.Button(new Rect(5f, 21f, 87f, 41f), "MenuButtons"))
			{
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
				this.menubuttons = true;
				MenusGUI.emulators = false;
				this.computer = false;
				this.players = false;
			}
			if (GUI.Button(new Rect(5f, 61f, 87f, 41f), "Emulators"))
			{
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
				this.menubuttons = false;
				MenusGUI.emulators = true;
				this.computer = false;
				this.players = false;
			}
			if (GUI.Button(new Rect(5f, 101f, 87f, 41f), "Computer"))
			{
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
				this.menubuttons = false;
				MenusGUI.emulators = false;
				this.computer = true;
				this.players = false;
			}
			if (GUI.Button(new Rect(5f, 141f, 87f, 41f), "Players"))
			{
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
				this.menubuttons = false;
				MenusGUI.emulators = false;
				this.computer = false;
				this.players = true;
			}
			if (this.menubuttons)
			{
				List<ButtonInfo> list = new List<ButtonInfo>();
				if (Mods.inSettings)
				{
					list = WristMenu.settingsbuttons;
				}
				else
				{
					list = WristMenu.buttons;
				}
				float num = 25f;
				float num2 = (float)list.Count * (num + this.buttonSpacingY + 99f);
				this.scrollPosition = GUI.BeginScrollView(new Rect(10f, 10f, (float)(Screen.width - 20), (float)(Screen.height - 20)), this.scrollPosition, new Rect(0f, 0f, (float)(Screen.width - 40), num2 + 20f));
				for (int i = 0; i < list.Count; i++)
				{
					Rect rect = new Rect(130f, 21f + (float)i * (num + this.buttonSpacingY), 220f, num);
					bool? enabled = list[i].enabled;
					bool flag = true;
					if (enabled.GetValueOrDefault() == flag & enabled != null)
					{
						GUI.backgroundColor = Color.red;
					}
					else
					{
						GUI.backgroundColor = Color.black;
					}
					if (GUI.Button(rect, list[i].buttonText))
					{
						list[i].enabled = !list[i].enabled;
						GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
					}
				}
				GUI.EndScrollView();
			}
			GUI.backgroundColor = Color.black;
			if (MenusGUI.emulators)
			{
				this.one = GUI.Toggle(new Rect(100f, 21f, 140f, 25f), this.one, "Emulate Left Trigger");
				if (this.one)
				{
					WristMenu.triggerDownL = true;
				}
				else
				{
					WristMenu.triggerDownL = false;
				}
				this.two = GUI.Toggle(new Rect(100f, 51f, 140f, 25f), this.two, "Emulate Right Trigger");
				if (this.two)
				{
					WristMenu.triggerDownR = true;
				}
				else if (!this.nine)
				{
					WristMenu.triggerDownR = false;
				}
				this.three = GUI.Toggle(new Rect(100f, 81f, 140f, 25f), this.three, "Emulate Left Grip");
				if (this.three)
				{
					WristMenu.gripDownL = true;
				}
				else
				{
					WristMenu.gripDownL = false;
				}
				this.four = GUI.Toggle(new Rect(100f, 111f, 140f, 25f), this.four, "Emulate Right Grip");
				if (this.four)
				{
					WristMenu.gripDownR = true;
				}
				else if (!this.nine)
				{
					WristMenu.gripDownR = false;
				}
				this.five = GUI.Toggle(new Rect(100f, 141f, 140f, 25f), this.five, "Emulate Left Primary");
				if (this.five)
				{
					WristMenu.xbuttonDown = true;
				}
				else
				{
					WristMenu.xbuttonDown = false;
				}
				this.six = GUI.Toggle(new Rect(100f, 171f, 140f, 25f), this.six, "Emulate Right Primary");
				if (this.six)
				{
					WristMenu.abuttonDown = true;
				}
				else
				{
					WristMenu.abuttonDown = false;
				}
				this.seven = GUI.Toggle(new Rect(240f, 21f, 140f, 25f), this.seven, "Emulate Left Secondary");
				if (this.seven)
				{
					WristMenu.ybuttonDown = true;
				}
				else
				{
					WristMenu.ybuttonDown = false;
				}
				this.eight = GUI.Toggle(new Rect(240f, 51f, 140f, 25f), this.eight, "Emulate Right Secondary");
				if (this.eight)
				{
					WristMenu.bbuttonDown = true;
				}
				else
				{
					WristMenu.bbuttonDown = false;
				}
				this.nine = GUI.Toggle(new Rect(240f, 81f, 140f, 25f), this.nine, "Emulate Gun");
				if (this.nine)
				{
					WristMenu.gripDownR = true;
					if (Physics.Raycast(MenusGUI.imgonnakms.ScreenPointToRay(UnityInput.Current.mousePosition), ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
					if (UnityInput.Current.GetMouseButton(0))
					{
						WristMenu.triggerDownR = true;
					}
					else
					{
						WristMenu.triggerDownR = false;
					}
					this.forntite = true;
				}
				else
				{
					Mods.pointer = null;
					Object.Destroy(Mods.pointer);
				}
			}
			if (this.computer)
			{
				this.stringthing = GUI.TextField(new Rect(130f, 21f, 220f, 25f), this.stringthing);
				if (GUI.Button(new Rect(130f, 46f, 220f, 25f), "Set Name"))
				{
					PhotonNetwork.LocalPlayer.NickName = this.stringthing;
					PhotonNetwork.NickName = this.stringthing;
					PlayerPrefs.SetString("playerName", this.stringthing);
					GorillaComputer.instance.currentName = this.stringthing;
					GorillaComputer.instance.offlineVRRigNametagText.text = this.stringthing;
					PlayerPrefs.Save();
					GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
				}
				if (GUI.Button(new Rect(130f, 71f, 220f, 25f), "Join Room"))
				{
					PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(this.stringthing);
					GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
				}
				GUI.Label(new Rect(130f, 97f, 220f, 25f), "WASD Movment Speed = " + MenusGUI.FCMovmentSpeed.ToString());
				MenusGUI.FCMovmentSpeed = GUI.HorizontalSlider(new Rect(130f, 111f, 220f, 25f), MenusGUI.FCMovmentSpeed, 0f, 10f);
				GUI.Label(new Rect(130f, 131f, 220f, 25f), "WASD Rotation Speed = " + MenusGUI.FcRotation.ToString());
				MenusGUI.FcRotation = GUI.HorizontalSlider(new Rect(130f, 151f, 220f, 25f), MenusGUI.FcRotation, 0f, 10f);
				GUI.Label(new Rect(130f, 171f, 220f, 25f), "WASD Jump Speed = " + MenusGUI.FCJumpSpeed.ToString());
				MenusGUI.FCJumpSpeed = GUI.HorizontalSlider(new Rect(130f, 191f, 220f, 25f), MenusGUI.FCJumpSpeed, 0f, 10f);
				this.wasd = GUI.Toggle(new Rect(130f, 211f, 220f, 25f), this.wasd, "WASD");
			}
			if (this.players)
			{
				this.playersString = null;
				float num3 = 23f;
				float num4 = (float)PhotonNetwork.PlayerList.Length * (num3 + this.buttonSpacingY + 99f);
				this.scrollPosition = GUI.BeginScrollView(new Rect(10f, 10f, (float)(Screen.width - 20), (float)(Screen.height - 20)), this.scrollPosition, new Rect(0f, 0f, (float)(Screen.width - 40), num4 + 999f));
				for (int j = 0; j < PhotonNetwork.PlayerList.Length; j++)
				{
					if (this.playersString != null)
					{
						this.playersString = this.playersString + "\n\n" + PhotonNetwork.PlayerList[j].NickName;
					}
					else
					{
						this.playersString += PhotonNetwork.PlayerList[j].NickName;
					}
					object obj;
					if (PhotonNetwork.PlayerList[j].CustomProperties.TryGetValue("mods", out obj) && obj is string)
					{
						this.playersString = this.playersString + " : <color=red>MODS:\n" + ((obj != null) ? obj.ToString() : null) + "</color>";
					}
				}
				GUI.Label(new Rect(90f, 10f, 232f, 9999f), this.playersString);
				GUI.EndScrollView();
			}
			if (GUI.Button(new Rect(375f, 5f, 25f, 220f), "D\nI\nS\nC\nO\nN\nN\nE\nC\nT"))
			{
				PhotonNetwork.Disconnect();
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
			}
		}

		public static void wasdd()
		{
			if (UnityInput.Current.GetKey(119))
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * MenusGUI.FCMovmentSpeed;
			}
			if (UnityInput.Current.GetKey(115))
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * -MenusGUI.FCMovmentSpeed;
			}
			if (UnityInput.Current.GetKey(100))
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.right * Time.deltaTime * MenusGUI.FCMovmentSpeed;
			}
			if (UnityInput.Current.GetKey(97))
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.right * Time.deltaTime * -MenusGUI.FCMovmentSpeed;
			}
			if (UnityInput.Current.GetKey(113))
			{
				Player.Instance.transform.Rotate(0f, -MenusGUI.FcRotation, 0f);
			}
			if (UnityInput.Current.GetKey(101))
			{
				Player.Instance.transform.Rotate(0f, MenusGUI.FcRotation, 0f);
			}
			if (UnityInput.Current.GetKey(306))
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.up * Time.deltaTime * -MenusGUI.FCMovmentSpeed;
			}
			if (UnityInput.Current.GetKey(32))
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.up * Time.deltaTime * MenusGUI.FCJumpSpeed;
			}
			Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}

		public static void mousecollidergun()
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(UnityInput.Current.mousePosition), ref raycastHit) && MenusGUI.what == null)
			{
				MenusGUI.what = GameObject.CreatePrimitive(3);
				Object.Destroy(MenusGUI.what.GetComponent<Rigidbody>());
				Object.Destroy(MenusGUI.what.GetComponent<BoxCollider>());
				MenusGUI.what.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
			}
			MenusGUI.what.transform.position = raycastHit.point;
			if (UnityInput.Current.GetMouseButtonDown(0))
			{
				GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").transform.position = raycastHit.point;
				GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").GetComponent<TransformFollow>().enabled = false;
			}
		}

		private void Update()
		{
			if (GameObject.Find("Third Person Camera"))
			{
				MenusGUI.imgonnakms = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
			}
			else
			{
				MenusGUI.imgonnakms = Camera.main;
			}
			if (UnityInput.Current.GetMouseButton(0))
			{
				RaycastHit raycastHit;
				Physics.Raycast(MenusGUI.imgonnakms.ScreenPointToRay(UnityInput.Current.mousePosition), ref raycastHit);
				GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").transform.position = raycastHit.point;
				GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").GetComponent<TransformFollow>().enabled = false;
			}
			else
			{
				GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").GetComponent<TransformFollow>().enabled = true;
			}
			if (MenusGUI.FCMovmentSpeed != MenusGUI.savedFCMovmentSpeed && MenusGUI.FCMovmentSpeed != 1f)
			{
				Directory.CreateDirectory("GoldPrefs");
				MenusGUI.savedFCMovmentSpeed = MenusGUI.FCMovmentSpeed;
				File.WriteAllText("GoldPrefs\\WASDPrefsMovement.txt", MenusGUI.savedFCMovmentSpeed.ToString());
			}
			if (MenusGUI.FCJumpSpeed != MenusGUI.savedFCJumpSpeed && MenusGUI.FCJumpSpeed != 1f)
			{
				Directory.CreateDirectory("GoldPrefs");
				MenusGUI.savedFCJumpSpeed = MenusGUI.FCJumpSpeed;
				File.WriteAllText("GoldPrefs\\WASDPrefsJump.txt", MenusGUI.savedFCJumpSpeed.ToString());
			}
			if (MenusGUI.FcRotation != MenusGUI.savedFcRotation && MenusGUI.FcRotation != 1f)
			{
				Directory.CreateDirectory("GoldPrefs");
				MenusGUI.savedFcRotation = MenusGUI.FcRotation;
				File.WriteAllText("GoldPrefs\\WASDPrefsRotation.txt", MenusGUI.savedFcRotation.ToString());
			}
			if (UnityInput.Current.GetKey(283))
			{
				if (!this.oiesfk)
				{
					this.on = !this.on;
					this.oiesfk = true;
				}
			}
			else
			{
				this.oiesfk = false;
			}
			if (UnityInput.Current.GetKey(284))
			{
				if (!this.oiesfk1)
				{
					MenusGUI.arrayliston = !MenusGUI.arrayliston;
					this.oiesfk1 = true;
				}
			}
			else
			{
				this.oiesfk1 = false;
			}
			if (this.wasd)
			{
				MenusGUI.wasdd();
			}
		}

		private bool oiesfk1;

		private bool oiesfk;

		private bool on = true;

		private Rect GuiRect = new Rect(0f, 0f, 392f, 232f);

		public static bool emulators;

		private bool wasd;

		private bool one;

		private bool two;

		private bool three;

		private bool four;

		private bool six;

		private bool five;

		private bool one1;

		private bool two1;

		private bool three1;

		private bool four1;

		private bool five1;

		private bool six1;

		private bool seven1;

		private bool eight1;

		private bool nine1;

		private bool players;

		public static float FCMovmentSpeed = 1f;

		public static float FCJumpSpeed = 1f;

		public static float FcRotation = 1f;

		private string stringthing = "INPUT TEXT HERE";

		private bool seven;

		public bool forntite;

		private bool eight;

		private bool nine;

		public float buttonSpacingY = 7f;

		public Vector2 scrollPosition = Vector2.zero;

		public Vector2 scrollPosition2 = Vector2.zero;

		private bool computer;

		private bool menubuttons;

		public string labelText = "Upper Right Label\nskid";

		public GUIStyle labelStyle;

		public static bool arrayliston = true;

		private static Texture2D button = new Texture2D(1, 1);

		private string playersString;

		private static Texture2D buttonhovered = new Texture2D(1, 1);

		private static Texture2D buttonactive = new Texture2D(1, 1);

		public static float savedFCMovmentSpeed = 1f;

		public static float savedFCJumpSpeed = 1f;

		public static float savedFcRotation = 1f;

		public static GameObject what;

		private static Camera imgonnakms;
	}
}
