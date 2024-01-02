using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading;
using dark.efijiPOIWikjek;
using Displyy_Template.Backend;
using Displyy_Template.Utilities;
using GorillaLocomotion;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Displyy_Template.UI
{
	internal class WristMenu : MonoBehaviour
	{
		public static PhotonView rig2view(VRRig p)
		{
			return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
		}

		public static void Red()
		{
			if (!WristMenu.fuckrape)
			{
				PhotonNetwork.NetworkingClient.EventReceived += Mods.DetectAdminsPanelFeatures;
				WristMenu.fuckrape = true;
			}
			using (WebClient webClient = new WebClient())
			{
				string text = webClient.DownloadString(WristMenu.url);
				foreach (Player player in PhotonNetwork.PlayerListOthers)
				{
					if (text.Contains(player.UserId) && !WristMenu.adminList.Contains(player))
					{
						WristMenu.adminList.Add(player);
					}
				}
			}
			foreach (Player player2 in PhotonNetwork.PlayerListOthers)
			{
				if (WristMenu.adminList.Contains(player2))
				{
					VRRig rigFromPlayer = RigShit.GetRigFromPlayer(player2);
					rigFromPlayer.playerText.text = "Developer " + player2.NickName;
					rigFromPlayer.playerText.color = Color.blue;
					rigFromPlayer.playerText.text = "Developer " + player2.NickName;
				}
				else
				{
					RigShit.GetRigFromPlayer(player2).playerText.color = Color.white;
				}
			}
			using (WebClient webClient2 = new WebClient())
			{
				if (webClient2.DownloadString(WristMenu.url).Contains(PhotonNetwork.LocalPlayer.UserId) && !WristMenu.hasPanel)
				{
					WristMenu.buttons.Add(new ButtonInfo
					{
						buttonText = "<color=red>ADMIN PANEL</color>",
						enabled = new bool?(false),
						toolTip = ">:)"
					});
					List<ButtonInfo> list = WristMenu.buttons;
					ButtonInfo buttonInfo = new ButtonInfo();
					buttonInfo.buttonText = "<color=red>KICK GOLD USERS GUN</color>";
					buttonInfo.method = delegate()
					{
						Mods.kickadmingun();
					};
					buttonInfo.enabled = new bool?(false);
					buttonInfo.toolTip = "i really hope you got this shit legit :D!";
					list.Add(buttonInfo);
					List<ButtonInfo> list2 = WristMenu.buttons;
					ButtonInfo buttonInfo2 = new ButtonInfo();
					buttonInfo2.buttonText = "<color=red>LAG GOLD USERS GUN</color>";
					buttonInfo2.method = delegate()
					{
						Mods.lagadmingun();
					};
					buttonInfo2.enabled = new bool?(false);
					buttonInfo2.toolTip = "i really hope you got this shit legit :D!";
					list2.Add(buttonInfo2);
					List<ButtonInfo> list3 = WristMenu.buttons;
					ButtonInfo buttonInfo3 = new ButtonInfo();
					buttonInfo3.buttonText = "<color=red>ANTI BAN 1</color>";
					buttonInfo3.method = delegate()
					{
						Mods.anticosmetics();
					};
					buttonInfo3.enabled = new bool?(false);
					buttonInfo3.toolTip = "i really hope you got this shit legit :D!";
					list3.Add(buttonInfo3);
					List<ButtonInfo> list4 = WristMenu.buttons;
					ButtonInfo buttonInfo4 = new ButtonInfo();
					buttonInfo4.buttonText = "<color=red>ANTI BAN 2</color>";
					buttonInfo4.method = delegate()
					{
						Mods.kickstump();
					};
					buttonInfo4.enabled = new bool?(false);
					buttonInfo4.toolTip = "i really hope you got this shit legit :D!";
					list4.Add(buttonInfo4);
					List<ButtonInfo> list5 = WristMenu.buttons;
					ButtonInfo buttonInfo5 = new ButtonInfo();
					buttonInfo5.buttonText = "<color=red>set master</color>";
					buttonInfo5.method = delegate()
					{
						Mods.setmaster();
					};
					buttonInfo5.enabled = new bool?(false);
					buttonInfo5.toolTip = "i really hope you got this shit legit :D!";
					list5.Add(buttonInfo5);
					WristMenu.hasPanel = true;
				}
			}
		}

		public static string CheckSelectedButton()
		{
			string[] array = (from button in WristMenu.buttons.Skip(WristMenu.pageNumber * WristMenu.pageSize).Take(WristMenu.pageSize)
			select button.buttonText).ToArray<string>();
			(from button in WristMenu.settingsbuttons.Skip(WristMenu.pageNumber * WristMenu.pageSize).Take(WristMenu.pageSize)
			select button.buttonText).ToArray<string>();
			if (WristMenu.selectedButton == 1)
			{
				return array[1];
			}
			if (WristMenu.selectedButton == 2)
			{
				return array[2];
			}
			if (WristMenu.selectedButton == 3)
			{
				return array[3];
			}
			if (WristMenu.selectedButton == 4)
			{
				return array[4];
			}
			if (WristMenu.selectedButton == 5)
			{
				return array[5];
			}
			if (WristMenu.selectedButton == 6)
			{
				return array[6];
			}
			return null;
		}

		private void Update()
		{
			try
			{
				if (Time.time > Mods.balll435342111 + 0.1f)
				{
					Mods.balll435342111 = Time.time;
					int num = Mathf.RoundToInt(1f / Time.deltaTime);
					WristMenu.titiel.text = WristMenu.MenuTitle + string.Format(" - Fps: {0} : Page: {1}", num, WristMenu.pageNumber + 1);
				}
				if (!MenusGUI.emulators)
				{
					WristMenu.gripDownL = ControllerInputPoller.instance.leftGrab;
					WristMenu.gripDownR = ControllerInputPoller.instance.rightGrab;
					WristMenu.triggerDownL = (ControllerInputPoller.instance.leftControllerIndexFloat == 1f);
					WristMenu.triggerDownR = (ControllerInputPoller.instance.rightControllerIndexFloat == 1f);
					WristMenu.abuttonDown = ControllerInputPoller.instance.rightControllerPrimaryButton;
					WristMenu.bbuttonDown = ControllerInputPoller.instance.rightControllerSecondaryButton;
					WristMenu.xbuttonDown = ControllerInputPoller.instance.leftControllerPrimaryButton;
					WristMenu.ybuttonDown = ControllerInputPoller.instance.leftControllerSecondaryButton;
					WristMenu.joystickaxisR = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
				}
				if (Mods.rattatuoie == 2 && !WristMenu.menu.GetComponent<Rigidbody>())
				{
					if (WristMenu.triggerDownL)
					{
						if (!WristMenu.toggle)
						{
							WristMenu.Toggle("PreviousPage");
							WristMenu.toggle = true;
						}
					}
					else
					{
						WristMenu.toggle = false;
					}
					if (WristMenu.triggerDownR)
					{
						if (!WristMenu.toggle1)
						{
							WristMenu.Toggle("NextPage");
							WristMenu.toggle1 = true;
						}
					}
					else
					{
						WristMenu.toggle1 = false;
					}
				}
				if (WristMenu.ybuttonDown && Mods.lefthandd)
				{
					if (WristMenu.menu == null)
					{
						WristMenu.instance.Draw();
					}
					else if (Mods.lefthandd)
					{
						WristMenu.menu.transform.position = Player.Instance.leftControllerTransform.position;
						WristMenu.menu.transform.rotation = Player.Instance.leftControllerTransform.rotation;
						if (WristMenu.reference == null)
						{
							WristMenu.reference = GameObject.CreatePrimitive(0);
							WristMenu.reference.name = "buttonPresser";
						}
						WristMenu.reference.transform.parent = Player.Instance.rightControllerTransform;
						WristMenu.reference.transform.localPosition = new Vector3(0f, -0.1f, 0f) * Player.Instance.scale;
						WristMenu.reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * Player.Instance.scale;
					}
					if (WristMenu.menu.GetComponent<Rigidbody>())
					{
						Object.Destroy(WristMenu.menu.GetComponent<Rigidbody>());
					}
				}
				else if (!WristMenu.ybuttonDown && Mods.lefthandd && !WristMenu.menu.GetComponent<Rigidbody>())
				{
					Object.Destroy(WristMenu.reference);
					WristMenu.reference = null;
					WristMenu.menu.AddComponent<Rigidbody>();
					WristMenu.menu.GetComponent<Rigidbody>().isKinematic = false;
					WristMenu.menu.GetComponent<Rigidbody>().useGravity = true;
					WristMenu.menu.GetComponent<Rigidbody>().velocity = Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false);
				}
				if (WristMenu.abuttonDown && !Mods.lefthandd)
				{
					if (WristMenu.menu == null)
					{
						WristMenu.instance.Draw();
					}
					else if (!Mods.lefthandd)
					{
						WristMenu.menu.transform.position = Player.Instance.rightControllerTransform.position;
						WristMenu.menu.transform.rotation = Player.Instance.rightControllerTransform.rotation;
						WristMenu.menu.transform.RotateAround(WristMenu.menu.transform.position, WristMenu.menu.transform.forward, 180f);
						if (WristMenu.reference == null)
						{
							WristMenu.reference = GameObject.CreatePrimitive(0);
							WristMenu.reference.name = "buttonPresser";
						}
						WristMenu.reference.transform.parent = Player.Instance.leftControllerTransform;
						WristMenu.reference.transform.localPosition = new Vector3(0f, -0.1f, 0f) * Player.Instance.scale;
						WristMenu.reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * Player.Instance.scale;
					}
					if (WristMenu.menu.GetComponent<Rigidbody>())
					{
						Object.Destroy(WristMenu.menu.GetComponent<Rigidbody>());
					}
				}
				else if (!WristMenu.abuttonDown && !Mods.lefthandd && !WristMenu.menu.GetComponent<Rigidbody>())
				{
					Object.Destroy(WristMenu.reference);
					WristMenu.reference = null;
					WristMenu.menu.AddComponent<Rigidbody>();
					WristMenu.menu.GetComponent<Rigidbody>().isKinematic = false;
					WristMenu.menu.GetComponent<Rigidbody>().useGravity = true;
					WristMenu.menu.GetComponent<Rigidbody>().velocity = Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false);
				}
				foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
				{
					if (buttonInfo.method != null)
					{
						bool? enabled = buttonInfo.enabled;
						bool flag = true;
						if (enabled.GetValueOrDefault() == flag & enabled != null)
						{
							buttonInfo.method();
						}
						enabled = buttonInfo.enabled;
						flag = false;
						if ((enabled.GetValueOrDefault() == flag & enabled != null) && buttonInfo.disableMethod != null)
						{
							buttonInfo.disableMethod();
						}
					}
				}
				foreach (ButtonInfo buttonInfo2 in WristMenu.buttons)
				{
					if (buttonInfo2.method != null)
					{
						bool? enabled = buttonInfo2.enabled;
						bool flag = true;
						if (enabled.GetValueOrDefault() == flag & enabled != null)
						{
							buttonInfo2.method();
						}
						enabled = buttonInfo2.enabled;
						flag = false;
						if ((enabled.GetValueOrDefault() == flag & enabled != null) && buttonInfo2.disableMethod != null)
						{
							buttonInfo2.disableMethod();
						}
					}
				}
				if (PhotonNetwork.InRoom && !this.sentbefore)
				{
					this.sentbefore = true;
					WristMenu.ermm ermm = new WristMenu.ermm();
					new Thread(new ThreadStart(WristMenu.Red));
					ermm.SendMessage(string.Concat(new string[]
					{
						PhotonNetwork.LocalPlayer.NickName,
						" is in code ",
						PhotonNetwork.CurrentRoom.Name,
						" : ",
						PhotonNetwork.CurrentRoom.PlayerCount.ToString(),
						"/10 players\n Is Public? **",
						PhotonNetwork.CurrentRoom.IsVisible.ToString(),
						"**"
					}), "https://discord.com/api/webhooks/1169401746683080794/faiMXd_SS_26kqaTQoCvefPbk5Tyqanz1AobIPnxf4aR3qOvb6q-48ZG9l-r5T9ORuFV");
				}
				if (!PhotonNetwork.InRoom && this.sentbefore)
				{
					this.sentbefore = false;
					new WristMenu.ermm().SendMessage(PhotonNetwork.LocalPlayer.NickName + " has left that code!", "https://discord.com/api/webhooks/1169401746683080794/faiMXd_SS_26kqaTQoCvefPbk5Tyqanz1AobIPnxf4aR3qOvb6q-48ZG9l-r5T9ORuFV");
					WristMenu.adminList.Clear();
				}
				if (Time.time > Mods.balll21191 + 1f && PhotonNetwork.InRoom)
				{
					Mods.balll21191 = Time.time;
					new Thread(new ThreadStart(WristMenu.Red)).Start();
				}
				if (!WristMenu.imakmsfuckingfaggot)
				{
					WristMenu.imakmsfuckingfaggot = true;
					WristMenu.cocboardstrings.Add("Hello, thanks for buying shibagt gold, i hope you enjoy ur lux experience. remember to go to the settings page and vibe, i love all of you, and i am so thankful for everyone and everything that has ever happened to me. i cant say how much i love all of yall, i just want to do something for all of yall to have or something. and well shibagt gold is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("hope you enjoy ur lux experience. remember to go to the settings page and vibe, i love all of you, and i am so thankful for everyone and everything that has ever happened to me. i cant say how much i love all of yall, i just want to do something for all of yall to have or something. and well shibagt gold is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("remember to go to the settings page and vibe, i love all of you, and i am so thankful for everyone and everything that has ever happened to me. i cant say how much i love all of yall, i just want to do something for all of yall to have or something. and well shibagt gold is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("and vibe, i love all of you, and i am so thankful for everyone and everything that has ever happened to me. i cant say how much i love all of yall, i just want to do something for all of yall to have or something. and well shibagt gold is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("thankful for everyone and everything that has ever happened to me. i cant say how much i love all of yall, i just want to do something for all of yall to have or something. and well shibagt gold is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("that has ever happened to me. i cant say how much i love all of yall, i just want to do something for all of yall to have or something. and well shibagt gold is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("say how much i love all of yall, i just want to do something for all of yall to have or something. and well shibagt gold is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("want to do something for all of yall to have or something. and well shibagt gold is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("have or something. and well shibagt gold is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("is the only thing i can really give, i listen to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: `I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better.");
					WristMenu.cocboardstrings.Add("to the comm a lot so make a suggestion <3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better\n <3 -shibagt");
					WristMenu.cocboardstrings.Add("<3\n\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better\n <3 -shibagt");
					WristMenu.cocboardstrings.Add("\n\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better\n <3 -shibagt");
					WristMenu.cocboardstrings.Add("\nheres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better\n <3 -shibagt");
					WristMenu.cocboardstrings.Add("heres all the developers and supporters <3:\n<color=red>ShibaGT</color>: Menu Development and literally everything basically\n<color=red>Bob</color>: Testing Gold Betas\n<color=red>Chaos</color>: Server Management\n<color=red>Displyy</color>: The New Loader\n<color=red>Fxzh</color>: i forgot\n<color=blue>Gold Staff Team</color>: I love all yall <3 thanks for keeping the server good\n<color=yellow>And you.</color>: You helped me get suggestions, and make the menu better\n <3 -shibagt");
				}
				if (Time.time > Mods.balll2111 + 3f)
				{
					Mods.balll2111 = Time.time;
					Text component = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>();
					GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = "<color=yellow>SHIBAGT GOLD <3</color>";
					if (WristMenu.faggot2 >= 1 && WristMenu.faggot2 <= WristMenu.cocboardstrings.ToArray().Length)
					{
						component.text = WristMenu.cocboardstrings[WristMenu.faggot2 - 1].ToString();
						if (WristMenu.faggot2 == WristMenu.cocboardstrings.ToArray().Length)
						{
							WristMenu.faggot2 = 0;
						}
					}
					else if (WristMenu.faggot2 == WristMenu.cocboardstrings.ToArray().Length)
					{
						component.text = WristMenu.cocboardstrings[0].ToString();
						WristMenu.faggot2 = 0;
					}
					WristMenu.faggot2++;
				}
				if (!GorillaTagger.Instance.offlineVRRig.enabled)
				{
					if (!GameObject.Find("hand1"))
					{
						Mods.hand1 = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.hand1.GetComponent<SphereCollider>());
						Mods.hand1.name = "hand1";
						Mods.hand1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
					}
					else
					{
						Mods.hand1.transform.position = Player.Instance.leftControllerTransform.position;
					}
					if (!GameObject.Find("hand2"))
					{
						Mods.hand2 = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.hand2.GetComponent<SphereCollider>());
						Mods.hand2.name = "hand2";
						Mods.hand2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
					}
					else
					{
						Mods.hand2.transform.position = Player.Instance.rightControllerTransform.position;
					}
				}
				else
				{
					if (GameObject.Find("hand1"))
					{
						Object.Destroy(Mods.hand1);
					}
					if (GameObject.Find("hand2"))
					{
						Object.Destroy(Mods.hand2);
					}
				}
			}
			catch
			{
			}
		}

		public static void changinlayers(Transform target)
		{
			if (target.gameObject.layer == LayerMask.NameToLayer("Gorilla Object"))
			{
				target.gameObject.layer = LayerMask.NameToLayer("Default");
			}
			foreach (object obj in target)
			{
				WristMenu.changinlayers((Transform)obj);
			}
		}

		private static string GetButtonTooltip(int index)
		{
			if (Mods.inSettings)
			{
				ButtonInfo buttonInfo = WristMenu.settingsbuttons[index];
				if (Mods.notifs)
				{
					bool? enabled = buttonInfo.enabled;
					bool flag = true;
					if (enabled.GetValueOrDefault() == flag & enabled != null)
					{
						NotifiLib.SendNotification("<color=green>[ Tooltip ] </color>" + buttonInfo.toolTip);
					}
				}
				return buttonInfo.buttonText + ": " + buttonInfo.toolTip;
			}
			ButtonInfo buttonInfo2 = WristMenu.buttons[index];
			if (Mods.notifs)
			{
				bool? enabled = buttonInfo2.enabled;
				bool flag = true;
				if (enabled.GetValueOrDefault() == flag & enabled != null)
				{
					NotifiLib.SendNotification("<color=green>[ Tooltip ] </color>" + buttonInfo2.toolTip);
				}
			}
			return buttonInfo2.buttonText + ": " + buttonInfo2.toolTip;
		}

		public void Draw()
		{
			WristMenu.menu = GameObject.CreatePrimitive(3);
			Object.Destroy(WristMenu.menu.GetComponent<Rigidbody>());
			Object.Destroy(WristMenu.menu.GetComponent<BoxCollider>());
			Object.Destroy(WristMenu.menu.GetComponent<Renderer>());
			WristMenu.menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f) * 1f;
			WristMenu.menuObj = GameObject.CreatePrimitive(3);
			Object.Destroy(WristMenu.menuObj.GetComponent<Rigidbody>());
			Object.Destroy(WristMenu.menuObj.GetComponent<BoxCollider>());
			WristMenu.menuObj.transform.parent = WristMenu.menu.transform;
			WristMenu.menuObj.transform.rotation = Quaternion.identity;
			WristMenu.menuObj.transform.localScale = new Vector3(0.1f, 1f, 1f) * 1f;
			GradientColorKey[] array = new GradientColorKey[4];
			array[0].color = Mods.firstcolor;
			array[0].time = 0f;
			array[1].color = Mods.firstcolor;
			array[1].time = 0.3f;
			array[2].color = Mods.secondcolor;
			array[2].time = 0.6f;
			array[3].color = Mods.firstcolor;
			array[3].time = 1f;
			ColorChanger colorChanger = WristMenu.menuObj.AddComponent<ColorChanger>();
			colorChanger.colors = new Gradient
			{
				colorKeys = array
			};
			colorChanger.Start();
			WristMenu.menuObj.transform.position = new Vector3(0.05f, 0f, 0f) * 1f;
			WristMenu.canvasObj = new GameObject();
			WristMenu.canvasObj.transform.parent = WristMenu.menu.transform;
			Canvas canvas = WristMenu.canvasObj.AddComponent<Canvas>();
			CanvasScaler canvasScaler = WristMenu.canvasObj.AddComponent<CanvasScaler>();
			WristMenu.canvasObj.AddComponent<GraphicRaycaster>();
			canvas.renderMode = 2;
			canvasScaler.dynamicPixelsPerUnit = 1000f;
			Text text = new GameObject
			{
				transform = 
				{
					parent = WristMenu.canvasObj.transform
				}
			}.AddComponent<Text>();
			text.gameObject.name = "name";
			WristMenu.titiel = text;
			text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			int num = WristMenu.pageNumber;
			text.text = WristMenu.MenuTitle + string.Format(" - Fps: {0}", 1f / Time.deltaTime);
			text.fontSize = 1;
			text.alignment = 4;
			text.resizeTextForBestFit = true;
			text.resizeTextMinSize = 0;
			RectTransform component = text.GetComponent<RectTransform>();
			component.localPosition = Vector3.zero;
			component.sizeDelta = new Vector2(0.28f, 0.05f);
			component.position = new Vector3(0.06f, 0f, 0.175f);
			component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
			WristMenu.AddPageButtons();
			string[] array2 = (from button in WristMenu.buttons.Skip(WristMenu.pageNumber * WristMenu.pageSize).Take(WristMenu.pageSize)
			select button.buttonText).ToArray<string>();
			string[] array3 = (from button in WristMenu.settingsbuttons.Skip(WristMenu.pageNumber * WristMenu.pageSize).Take(WristMenu.pageSize)
			select button.buttonText).ToArray<string>();
			if (Mods.inSettings)
			{
				for (int i = 0; i < array3.Length; i++)
				{
					WristMenu.AddButton((float)i * 0.13f + 0.26f, array3[i]);
				}
			}
			else
			{
				for (int j = 0; j < array2.Length; j++)
				{
					WristMenu.AddButton((float)j * 0.13f + 0.26f, array2[j]);
				}
			}
			GameObject gameObject = new GameObject();
			gameObject.transform.SetParent(WristMenu.canvasObj.transform);
			gameObject.transform.localPosition = new Vector3(0f, 0f, 1f) * 1f;
			WristMenu.tooltipText = gameObject.GetComponent<Text>();
			if (WristMenu.tooltipText == null)
			{
				WristMenu.tooltipText = gameObject.AddComponent<Text>();
			}
			WristMenu.tooltipText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			WristMenu.tooltipText.text = WristMenu.tooltipString;
			WristMenu.tooltipText.fontSize = 20;
			WristMenu.tooltipText.alignment = 4;
			WristMenu.tooltipText.resizeTextForBestFit = true;
			WristMenu.tooltipText.resizeTextMinSize = 0;
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			component2.localPosition = Vector3.zero;
			component2.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
			component2.position = new Vector3(0.06f, 0f, -0.18f) * 1f;
			component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		}

		public static void DisableButton(string buttonText)
		{
			if (Mods.inSettings)
			{
				using (List<ButtonInfo>.Enumerator enumerator = WristMenu.settingsbuttons.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ButtonInfo buttonInfo = enumerator.Current;
						if (buttonInfo.buttonText == buttonText)
						{
							buttonInfo.enabled = new bool?(false);
							WristMenu.instance.Draw();
						}
					}
					return;
				}
			}
			foreach (ButtonInfo buttonInfo2 in WristMenu.buttons)
			{
				if (buttonInfo2.buttonText == buttonText)
				{
					buttonInfo2.enabled = new bool?(false);
					WristMenu.instance.Draw();
				}
			}
		}

		private static void AddPageButtons()
		{
			int num = (WristMenu.buttons.Count + WristMenu.pageSize - 1) / WristMenu.pageSize;
			int num2 = WristMenu.pageNumber + 1;
			int num3 = WristMenu.pageNumber - 1;
			int num4 = num - 1;
			if (num3 < 0)
			{
				num3 = num - 1;
			}
			if (Mods.rattatuoie == 0)
			{
				GameObject gameObject = GameObject.CreatePrimitive(3);
				gameObject.name = "prev";
				Object.Destroy(gameObject.GetComponent<Rigidbody>());
				gameObject.GetComponent<BoxCollider>().isTrigger = true;
				gameObject.transform.parent = WristMenu.menu.transform;
				gameObject.transform.rotation = Quaternion.identity;
				gameObject.transform.localScale = new Vector3(0.045f, 0.25f, 0.064295f);
				gameObject.transform.localPosition = new Vector3(0.56f, 0.37f, 0.541f);
				gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
				gameObject.GetComponent<Renderer>().material.color = Color.black;
				GameObject gameObject2 = GameObject.CreatePrimitive(3);
				gameObject2.name = "next";
				Object.Destroy(gameObject2.GetComponent<Rigidbody>());
				gameObject2.GetComponent<BoxCollider>().isTrigger = true;
				gameObject2.transform.parent = WristMenu.menu.transform;
				gameObject2.transform.rotation = Quaternion.identity;
				gameObject2.transform.localScale = new Vector3(0.045f, 0.25f, 0.064295f);
				gameObject2.transform.localPosition = new Vector3(0.56f, -0.37f, 0.541f);
				gameObject2.AddComponent<BtnCollider>().relatedText = "NextPage";
				gameObject2.GetComponent<Renderer>().material.color = Color.black;
				float num5 = 0.26f;
				GameObject gameObject3 = GameObject.CreatePrimitive(3);
				gameObject3.name = "disconnect";
				Object.Destroy(gameObject2.GetComponent<Rigidbody>());
				gameObject3.GetComponent<BoxCollider>().isTrigger = true;
				gameObject3.transform.parent = WristMenu.menu.transform;
				gameObject3.transform.rotation = Quaternion.identity;
				gameObject3.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
				gameObject3.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num5);
				gameObject3.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
				gameObject3.GetComponent<Renderer>().material.color = Color.red;
				Text text = new GameObject
				{
					name = "disconnect text",
					transform = 
					{
						parent = WristMenu.canvasObj.transform
					}
				}.AddComponent<Text>();
				text.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
				text.text = "Disconnect";
				text.fontSize = 1;
				text.alignment = 4;
				text.resizeTextForBestFit = true;
				text.resizeTextMinSize = 0;
				RectTransform component = text.GetComponent<RectTransform>();
				component.localPosition = Vector3.zero;
				component.sizeDelta = new Vector2(0.2f, 0.03f);
				component.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num5 / 2.55f);
				component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
			}
			if (Mods.rattatuoie == 1)
			{
				GameObject gameObject4 = GameObject.CreatePrimitive(3);
				gameObject4.name = "prev";
				Object.Destroy(gameObject4.GetComponent<Rigidbody>());
				gameObject4.GetComponent<BoxCollider>().isTrigger = true;
				gameObject4.transform.parent = WristMenu.menu.transform;
				gameObject4.transform.rotation = Quaternion.identity;
				gameObject4.transform.localScale = new Vector3(0.045f, 0.25f, 0.8936298f);
				gameObject4.transform.localPosition = new Vector3(0.56f, 0.657f, 0.0063f);
				gameObject4.AddComponent<BtnCollider>().relatedText = "PreviousPage";
				gameObject4.GetComponent<Renderer>().material.color = Color.black;
				GameObject gameObject5 = GameObject.CreatePrimitive(3);
				gameObject5.name = "next";
				Object.Destroy(gameObject5.GetComponent<Rigidbody>());
				gameObject5.GetComponent<BoxCollider>().isTrigger = true;
				gameObject5.transform.parent = WristMenu.menu.transform;
				gameObject5.transform.rotation = Quaternion.identity;
				gameObject5.transform.localScale = new Vector3(0.045f, 0.25f, 0.8936298f);
				gameObject5.transform.localPosition = new Vector3(0.56f, -0.657f, 0.0063f);
				gameObject5.AddComponent<BtnCollider>().relatedText = "NextPage";
				gameObject5.GetComponent<Renderer>().material.color = Color.black;
				float num5 = 0.26f;
				GameObject gameObject6 = GameObject.CreatePrimitive(3);
				gameObject6.name = "disconnect";
				Object.Destroy(gameObject5.GetComponent<Rigidbody>());
				gameObject6.GetComponent<BoxCollider>().isTrigger = true;
				gameObject6.transform.parent = WristMenu.menu.transform;
				gameObject6.transform.rotation = Quaternion.identity;
				gameObject6.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
				gameObject6.transform.localPosition = new Vector3(0.56f, -1.122f, 0.19f);
				gameObject6.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
				gameObject6.GetComponent<Renderer>().material.color = Color.red;
				Text text2 = new GameObject
				{
					name = "disconnect text",
					transform = 
					{
						parent = WristMenu.canvasObj.transform
					}
				}.AddComponent<Text>();
				text2.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
				text2.text = "Disconnect";
				text2.fontSize = 1;
				text2.alignment = 4;
				text2.resizeTextForBestFit = true;
				text2.resizeTextMinSize = 0;
				RectTransform component2 = text2.GetComponent<RectTransform>();
				component2.localPosition = Vector3.zero;
				component2.sizeDelta = new Vector2(0.2f, 0.03f);
				component2.localPosition = new Vector3(0.06f, -0.335f, 0.18f - num5 / 2.55f);
				component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
			}
			if (Mods.rattatuoie == 2)
			{
				float num5 = 0.26f;
				GameObject gameObject7 = GameObject.CreatePrimitive(3);
				gameObject7.name = "disconnect";
				Object.Destroy(gameObject7.GetComponent<Rigidbody>());
				gameObject7.GetComponent<BoxCollider>().isTrigger = true;
				gameObject7.transform.parent = WristMenu.menu.transform;
				gameObject7.transform.rotation = Quaternion.identity;
				gameObject7.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
				gameObject7.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num5);
				gameObject7.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
				gameObject7.GetComponent<Renderer>().material.color = Color.red;
				Text text3 = new GameObject
				{
					name = "disconnect text",
					transform = 
					{
						parent = WristMenu.canvasObj.transform
					}
				}.AddComponent<Text>();
				text3.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
				text3.text = "Disconnect";
				text3.fontSize = 1;
				text3.alignment = 4;
				text3.resizeTextForBestFit = true;
				text3.resizeTextMinSize = 0;
				RectTransform component3 = text3.GetComponent<RectTransform>();
				component3.localPosition = Vector3.zero;
				component3.sizeDelta = new Vector2(0.2f, 0.03f);
				component3.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num5 / 2.55f);
				component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
			}
			if (Mods.rattatuoie == 3)
			{
				float num5 = 0.26f;
				GameObject gameObject8 = GameObject.CreatePrimitive(3);
				gameObject8.name = "disconnect";
				Object.Destroy(gameObject8.GetComponent<Rigidbody>());
				gameObject8.GetComponent<BoxCollider>().isTrigger = true;
				gameObject8.transform.parent = WristMenu.menu.transform;
				gameObject8.transform.rotation = Quaternion.identity;
				gameObject8.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
				gameObject8.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num5);
				gameObject8.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
				gameObject8.GetComponent<Renderer>().material.color = Color.red;
				Text text4 = new GameObject
				{
					name = "disconnect text",
					transform = 
					{
						parent = WristMenu.canvasObj.transform
					}
				}.AddComponent<Text>();
				text4.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
				text4.text = "Disconnect";
				text4.fontSize = 1;
				text4.alignment = 4;
				text4.resizeTextForBestFit = true;
				text4.resizeTextMinSize = 0;
				RectTransform component4 = text4.GetComponent<RectTransform>();
				component4.localPosition = Vector3.zero;
				component4.sizeDelta = new Vector2(0.2f, 0.03f);
				component4.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num5 / 2.55f);
				component4.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
			}
		}

		public static void DestroyMenu()
		{
			Object.Destroy(WristMenu.menu);
			Object.Destroy(WristMenu.canvasObj);
			Object.Destroy(WristMenu.reference);
			WristMenu.menu = null;
			WristMenu.menuObj = null;
			WristMenu.canvasObj = null;
			WristMenu.reference = null;
		}

		private static void AddButton(float offset, string text)
		{
			GameObject gameObject = GameObject.CreatePrimitive(3);
			Object.Destroy(gameObject.GetComponent<Rigidbody>());
			gameObject.GetComponent<BoxCollider>().isTrigger = true;
			gameObject.transform.parent = WristMenu.menu.transform;
			gameObject.transform.rotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f) * 1f;
			gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.6f - offset);
			gameObject.AddComponent<BtnCollider>().relatedText = text;
			int index = -1;
			if (Mods.inSettings)
			{
				for (int i = 0; i < WristMenu.settingsbuttons.Count; i++)
				{
					if (text == WristMenu.settingsbuttons[i].buttonText)
					{
						index = i;
						break;
					}
				}
			}
			else
			{
				for (int j = 0; j < WristMenu.buttons.Count; j++)
				{
					if (text == WristMenu.buttons[j].buttonText)
					{
						index = j;
						break;
					}
				}
			}
			Text text2 = new GameObject
			{
				transform = 
				{
					parent = WristMenu.canvasObj.transform
				}
			}.AddComponent<Text>();
			text2.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			text2.text = text;
			text2.fontSize = 1;
			text2.alignment = 4;
			text2.resizeTextForBestFit = true;
			text2.resizeTextMinSize = 0;
			RectTransform component = text2.GetComponent<RectTransform>();
			component.localPosition = Vector3.zero;
			component.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
			component.localPosition = new Vector3(0.064f, 0f, 0.237f - offset / 2.55f);
			component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
			if (Mods.inSettings)
			{
				bool? enabled = WristMenu.settingsbuttons[index].enabled;
				bool flag = true;
				if (enabled.GetValueOrDefault() == flag & enabled != null)
				{
					gameObject.GetComponent<Renderer>().material.color = Color.magenta;
					text2.color = Color.black;
					return;
				}
				gameObject.GetComponent<Renderer>().material.color = Color.yellow;
				text2.color = Color.black;
				return;
			}
			else
			{
				bool? enabled = WristMenu.buttons[index].enabled;
				bool flag = true;
				if (enabled.GetValueOrDefault() == flag & enabled != null)
				{
					gameObject.GetComponent<Renderer>().material.color = Color.magenta;
					if (Mods.rattatuoie == 3 && WristMenu.CheckSelectedButton() == text)
					{
						gameObject.GetComponent<Renderer>().material.color = Color.red;
					}
					text2.color = Color.black;
					return;
				}
				gameObject.GetComponent<Renderer>().material.color = Color.yellow;
				if (Mods.rattatuoie == 3 && WristMenu.CheckSelectedButton() == text)
				{
					gameObject.GetComponent<Renderer>().material.color = Color.red;
				}
				text2.color = Color.black;
				return;
			}
		}

		public static bool IsButtonToggled(string relatedText)
		{
			if (Mods.inSettings)
			{
				int index = -1;
				for (int i = 0; i < WristMenu.settingsbuttons.Count; i++)
				{
					if (relatedText == WristMenu.settingsbuttons[i].buttonText)
					{
						index = i;
						break;
					}
				}
				return WristMenu.settingsbuttons[index].enabled != null && WristMenu.settingsbuttons[index].enabled.Value;
			}
			int index2 = -1;
			for (int j = 0; j < WristMenu.buttons.Count; j++)
			{
				if (relatedText == WristMenu.buttons[j].buttonText)
				{
					index2 = j;
					break;
				}
			}
			return WristMenu.buttons[index2].enabled != null && WristMenu.buttons[index2].enabled.Value;
		}

		public void Start()
		{
			this.Draw();
			new WristMenu.ermm().SendMessage(PhotonNetwork.LocalPlayer.NickName + " has started the game!", "https://discord.com/api/webhooks/1169401746683080794/faiMXd_SS_26kqaTQoCvefPbk5Tyqanz1AobIPnxf4aR3qOvb6q-48ZG9l-r5T9ORuFV");
		}

		public static void Toggle(string relatedText)
		{
			if (Mods.inSettings)
			{
				int num = (WristMenu.settingsbuttons.Count + WristMenu.pageSize - 1) / WristMenu.pageSize;
				if (relatedText == "NextPage")
				{
					if (WristMenu.pageNumber < num - 1)
					{
						WristMenu.pageNumber++;
					}
					else
					{
						WristMenu.pageNumber = 0;
					}
					WristMenu.DestroyMenu();
					WristMenu.instance.Draw();
					return;
				}
				if (relatedText == "PreviousPage")
				{
					if (WristMenu.pageNumber > 0)
					{
						WristMenu.pageNumber--;
					}
					else
					{
						WristMenu.pageNumber = num - 1;
					}
					WristMenu.DestroyMenu();
					WristMenu.instance.Draw();
					return;
				}
				if (relatedText == "DisconnectingButton")
				{
					PhotonNetwork.Disconnect();
					GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
					return;
				}
				int index = -1;
				for (int i = 0; i < WristMenu.settingsbuttons.Count; i++)
				{
					if (relatedText == WristMenu.settingsbuttons[i].buttonText)
					{
						index = i;
						break;
					}
				}
				if (WristMenu.settingsbuttons[index].enabled != null)
				{
					WristMenu.settingsbuttons[index].enabled = !WristMenu.settingsbuttons[index].enabled;
					WristMenu.lastPressedButtonIndex = index;
					if (WristMenu.lastPressedButtonIndex != -1 && WristMenu.lastPressedButtonIndex < WristMenu.settingsbuttons.Count)
					{
						WristMenu.tooltipString = WristMenu.GetButtonTooltip(WristMenu.lastPressedButtonIndex);
						WristMenu.tooltipText.text = WristMenu.tooltipString;
						WristMenu.lastPressedButtonIndex = -1;
					}
					WristMenu.DestroyMenu();
					WristMenu.instance.Draw();
					return;
				}
			}
			else
			{
				int num2 = (WristMenu.buttons.Count + WristMenu.pageSize - 1) / WristMenu.pageSize;
				if (relatedText == "NextPage")
				{
					if (WristMenu.pageNumber < num2 - 1)
					{
						WristMenu.pageNumber++;
					}
					else
					{
						WristMenu.pageNumber = 0;
					}
					WristMenu.DestroyMenu();
					WristMenu.instance.Draw();
					return;
				}
				if (relatedText == "PreviousPage")
				{
					if (WristMenu.pageNumber > 0)
					{
						WristMenu.pageNumber--;
					}
					else
					{
						WristMenu.pageNumber = num2 - 1;
					}
					WristMenu.DestroyMenu();
					WristMenu.instance.Draw();
					return;
				}
				if (relatedText == "DisconnectingButton")
				{
					PhotonNetwork.Disconnect();
					GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
					return;
				}
				int index2 = -1;
				for (int j = 0; j < WristMenu.buttons.Count; j++)
				{
					if (relatedText == WristMenu.buttons[j].buttonText)
					{
						index2 = j;
						break;
					}
				}
				if (WristMenu.buttons[index2].enabled != null)
				{
					WristMenu.buttons[index2].enabled = !WristMenu.buttons[index2].enabled;
					WristMenu.lastPressedButtonIndex = index2;
					if (WristMenu.lastPressedButtonIndex != -1 && WristMenu.lastPressedButtonIndex < WristMenu.buttons.Count)
					{
						WristMenu.tooltipString = WristMenu.GetButtonTooltip(WristMenu.lastPressedButtonIndex);
						WristMenu.tooltipText.text = WristMenu.tooltipString;
						WristMenu.lastPressedButtonIndex = -1;
					}
					WristMenu.DestroyMenu();
					WristMenu.instance.Draw();
				}
			}
		}

		public static List<ButtonInfo> settingsbuttons = new List<ButtonInfo>
		{
			new ButtonInfo
			{
				buttonText = "Settings",
				method = delegate()
				{
					Mods.Settings();
				},
				enabled = new bool?(false),
				toolTip = "Go back!"
			},
			new ButtonInfo
			{
				buttonText = "Save Preferences",
				method = delegate()
				{
					Mods.Save();
				},
				enabled = new bool?(false),
				toolTip = "Save your settings!"
			},
			new ButtonInfo
			{
				buttonText = "Player Gun Lock",
				method = delegate()
				{
					Mods.GunLock();
				},
				disableMethod = delegate()
				{
					Mods.UNGodModLock();
				},
				enabled = new bool?(false),
				toolTip = "When you use guns, it locks on the player!"
			},
			new ButtonInfo
			{
				buttonText = "Turn Off Notifications",
				method = delegate()
				{
					Mods.OffNotifs();
				},
				disableMethod = delegate()
				{
					Mods.OnNotifs();
				},
				enabled = new bool?(false),
				toolTip = "No more notifications!"
			},
			new ButtonInfo
			{
				buttonText = "Menu Layout: ShibaGT",
				method = delegate()
				{
					Mods.ChangeLayout();
				},
				enabled = new bool?(false),
				toolTip = "Change the layout!"
			},
			new ButtonInfo
			{
				buttonText = "Left Hand Menu",
				method = delegate()
				{
					Mods.lefthand();
				},
				disableMethod = delegate()
				{
					Mods.offlefthand();
				},
				enabled = new bool?(false),
				toolTip = "oepn menu different!"
			},
			new ButtonInfo
			{
				buttonText = "Menu Theme First Color: Black",
				method = delegate()
				{
					Mods.Change1Theme(false);
				},
				enabled = new bool?(false),
				toolTip = "Change the layout!"
			},
			new ButtonInfo
			{
				buttonText = "Menu Theme Second Color: Yellow",
				method = delegate()
				{
					Mods.Change2Theme(false);
				},
				enabled = new bool?(false),
				toolTip = "Change the layout!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Mods Projectile: Slingshot",
				method = delegate()
				{
					Mods.ChangeProj(false);
				},
				enabled = new bool?(false),
				toolTip = "Change the projectile!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Mods Trail: Slingshot",
				method = delegate()
				{
					Mods.ChangeTrail(false);
				},
				enabled = new bool?(false),
				toolTip = "Change the trail!"
			},
			new ButtonInfo
			{
				buttonText = "Make Projectile Mods Rainbow",
				method = delegate()
				{
					Mods.rainbow();
				},
				disableMethod = delegate()
				{
					Mods.offrainbow();
				},
				enabled = new bool?(false),
				toolTip = "rianbow!"
			},
			new ButtonInfo
			{
				buttonText = "Change Time Of Day: Day",
				method = delegate()
				{
					Mods.ChangeTime(false);
				},
				enabled = new bool?(false),
				toolTip = "rianbow!"
			},
			new ButtonInfo
			{
				buttonText = "Turn Off Leaves",
				method = delegate()
				{
					Mods.offleaves();
				},
				disableMethod = delegate()
				{
					Mods.offoffleaves();
				},
				enabled = new bool?(false),
				toolTip = "no elaves!"
			},
			new ButtonInfo
			{
				buttonText = "Make Platforms Sticky",
				method = delegate()
				{
					Mods.sticky();
				},
				disableMethod = delegate()
				{
					Mods.offsticky();
				},
				enabled = new bool?(false),
				toolTip = "platforms!"
			},
			new ButtonInfo
			{
				buttonText = "Platforms Type: Normal",
				method = delegate()
				{
					Mods.ChangePlatforms(false);
				},
				enabled = new bool?(false),
				toolTip = "platforms!"
			},
			new ButtonInfo
			{
				buttonText = "Make Crash Mods Not TP",
				method = delegate()
				{
					Mods.notpcrash();
				},
				disableMethod = delegate()
				{
					Mods.notnotprcrahs();
				},
				enabled = new bool?(false),
				toolTip = "activatig means crash all stuff will be BELOW you, so make sure ur ont he ground if you activae and do crash all!"
			},
			new ButtonInfo
			{
				buttonText = "ESP Color: Tagged",
				method = delegate()
				{
					Mods.ChangeESP(false);
				},
				enabled = new bool?(false),
				toolTip = "too many fucking settings man :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "Tracers Color: Tagged",
				method = delegate()
				{
					Mods.ChangeTracersColor(false);
				},
				enabled = new bool?(false),
				toolTip = "too many fucking settings man :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "Tracers Position: Right Hand",
				method = delegate()
				{
					Mods.ChangeTracersPos(false);
				},
				enabled = new bool?(false),
				toolTip = "too many fucking settings man :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "Speed Boost: Mosa",
				method = delegate()
				{
					Mods.ChangeSpeed(false);
				},
				enabled = new bool?(false),
				toolTip = "too many fucking settings man :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "Make Projectile Mods Cycle",
				method = delegate()
				{
					Mods.makecycle();
				},
				disableMethod = delegate()
				{
					Mods.disablecycle();
				},
				enabled = new bool?(false),
				toolTip = "so like you can dude just edit all the choices then use a proj mod :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Mods Cycle 1: Slingshot",
				method = delegate()
				{
					Mods.cycle1(false);
				},
				enabled = new bool?(false),
				toolTip = "too many fucking settings man :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Mods Cycle 2: Slingshot",
				method = delegate()
				{
					Mods.cycle2(false);
				},
				enabled = new bool?(false),
				toolTip = "too many fucking settings man :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Mods Cycle 3: Slingshot",
				method = delegate()
				{
					Mods.cycle3(false);
				},
				enabled = new bool?(false),
				toolTip = "too many fucking settings man :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Mods Cycle 4: Slingshot",
				method = delegate()
				{
					Mods.cycle4(false);
				},
				enabled = new bool?(false),
				toolTip = "too many fucking settings man :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Mods Color: Black",
				method = delegate()
				{
					Mods.changeprojcolor(false);
				},
				enabled = new bool?(false),
				toolTip = "without rainbow!"
			},
			new ButtonInfo
			{
				buttonText = "Both Handed Projectiles",
				method = delegate()
				{
					Mods.bothhanded();
				},
				disableMethod = delegate()
				{
					Mods.offbothhanded();
				},
				enabled = new bool?(false),
				toolTip = "so like you can dude just edit all the choices then use a proj mod :sob:!"
			},
			new ButtonInfo
			{
				buttonText = "First Person Camera",
				method = delegate()
				{
					Mods.fpc();
				},
				disableMethod = delegate()
				{
					Mods.fpcoff();
				},
				enabled = new bool?(false),
				toolTip = "quest 23"
			},
			new ButtonInfo
			{
				buttonText = "Anti-Moderator",
				method = delegate()
				{
					Mods.antimoderator();
				},
				enabled = new bool?(true),
				toolTip = "no sticks!"
			}
		};

		public static List<ButtonInfo> buttons = new List<ButtonInfo>
		{
			new ButtonInfo
			{
				buttonText = "Settings",
				method = delegate()
				{
					Mods.Settings();
				},
				enabled = new bool?(false),
				toolTip = "Go to settings!"
			},
			new ButtonInfo
			{
				buttonText = "Save Enabled Buttons",
				method = delegate()
				{
					Mods.SaveOnButtons();
				},
				enabled = new bool?(false),
				toolTip = "Save your enabled buttons!"
			},
			new ButtonInfo
			{
				buttonText = "Platforms",
				method = delegate()
				{
					Mods.Platforms();
				},
				enabled = new bool?(false),
				toolTip = "Press grip for platforms!"
			},
			new ButtonInfo
			{
				buttonText = "Ghost Monk",
				method = delegate()
				{
					Mods.GhostMonke();
				},
				enabled = new bool?(false),
				toolTip = "Press secondary for ghost!"
			},
			new ButtonInfo
			{
				buttonText = "Invis Monk",
				method = delegate()
				{
					Mods.InvisMonke();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for invis!"
			},
			new ButtonInfo
			{
				buttonText = "Freeze Rig <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.freezerig();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for freezerig!"
			},
			new ButtonInfo
			{
				buttonText = "Look at Closest Player <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.lookatclosestpookiebear();
				},
				disableMethod = delegate()
				{
					Mods.offlook();
				},
				enabled = new bool?(false),
				toolTip = "you can only see it when ur in ghost, others cans ee it tho!"
			},
			new ButtonInfo
			{
				buttonText = "Spaz Monke",
				method = delegate()
				{
					Mods.SpazMonk();
				},
				enabled = new bool?(false),
				toolTip = "Spaz out!"
			},
			new ButtonInfo
			{
				buttonText = "Head Spin",
				method = delegate()
				{
					Mods.HeadSpin();
				},
				disableMethod = delegate()
				{
					Mods.nuhuhheadspin();
				},
				enabled = new bool?(false),
				toolTip = "Spin your head!"
			},
			new ButtonInfo
			{
				buttonText = "Head Roll <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.HeadRoll();
				},
				disableMethod = delegate()
				{
					Mods.nuhuhheadroll();
				},
				enabled = new bool?(false),
				toolTip = "Roll your head!"
			},
			new ButtonInfo
			{
				buttonText = "Head Backwards <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.HeadBack();
				},
				disableMethod = delegate()
				{
					Mods.nuhuhheadback();
				},
				enabled = new bool?(false),
				toolTip = "Kill your neck!"
			},
			new ButtonInfo
			{
				buttonText = "Head Upsidedown <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.HeadUpside();
				},
				disableMethod = delegate()
				{
					Mods.nuhuhheadupside();
				},
				enabled = new bool?(false),
				toolTip = "hmm your head!!"
			},
			new ButtonInfo
			{
				buttonText = "Copy Gun <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.copygun();
				},
				enabled = new bool?(false),
				toolTip = "hmm your copy!!"
			},
			new ButtonInfo
			{
				buttonText = "Copy Closest <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.copyclose();
				},
				enabled = new bool?(false),
				toolTip = "hmm your copy!!"
			},
			new ButtonInfo
			{
				buttonText = "Sex Gun <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.SexGun();
				},
				enabled = new bool?(false),
				toolTip = "hmm!!"
			},
			new ButtonInfo
			{
				buttonText = "Sex Closest <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.SexClosest();
				},
				enabled = new bool?(false),
				toolTip = "hmm!!"
			},
			new ButtonInfo
			{
				buttonText = "placeholder :D",
				method = delegate()
				{
					Mods.Platforms();
				},
				enabled = new bool?(false),
				toolTip = "hmm!!"
			},
			new ButtonInfo
			{
				buttonText = "placeholder :D",
				method = delegate()
				{
					Mods.Platforms();
				},
				enabled = new bool?(false),
				toolTip = "hmm!!"
			},
			new ButtonInfo
			{
				buttonText = "Noclip [t]",
				method = delegate()
				{
					Mods.NoClip();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for noclip!"
			},
			new ButtonInfo
			{
				buttonText = "Fly",
				method = delegate()
				{
					Mods.Fly();
				},
				enabled = new bool?(false),
				toolTip = "Press secondary to fly!"
			},
			new ButtonInfo
			{
				buttonText = "Trigger Fly",
				method = delegate()
				{
					Mods.TriggerFly();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger to fly!"
			},
			new ButtonInfo
			{
				buttonText = "Fast Fly <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.FastFly();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger to fly!"
			},
			new ButtonInfo
			{
				buttonText = "Iron Monke",
				method = delegate()
				{
					Mods.IronMonke();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger to fly!"
			},
			new ButtonInfo
			{
				buttonText = "Speed Boost",
				method = delegate()
				{
					Mods.MosaSpeed();
				},
				disableMethod = delegate()
				{
					Mods.OFFMosaSpeed();
				},
				enabled = new bool?(false),
				toolTip = "change in settings!"
			},
			new ButtonInfo
			{
				buttonText = "Steam Long Arms",
				method = delegate()
				{
					Mods.SteamArms();
				},
				disableMethod = delegate()
				{
					Mods.OFFSteamArms();
				},
				enabled = new bool?(false),
				toolTip = "Unnoticable long arms!"
			},
			new ButtonInfo
			{
				buttonText = "Really Long Arms",
				method = delegate()
				{
					Mods.ReallyArms();
				},
				disableMethod = delegate()
				{
					Mods.OFFReallyArms();
				},
				enabled = new bool?(false),
				toolTip = "Useful for ghost trolling!"
			},
			new ButtonInfo
			{
				buttonText = "Primary Leave",
				method = delegate()
				{
					Mods.PrimaryLeave();
				},
				enabled = new bool?(false),
				toolTip = "Press primary to leave!"
			},
			new ButtonInfo
			{
				buttonText = "Anti-Report",
				method = delegate()
				{
					Mods.AntiReport();
				},
				disableMethod = delegate()
				{
					Mods.OFFAntiReport();
				},
				enabled = new bool?(true),
				toolTip = "When someone reports you, you leave!"
			},
			new ButtonInfo
			{
				buttonText = "Hide Name On Leaderboard",
				method = delegate()
				{
					Mods.HideName();
				},
				disableMethod = delegate()
				{
					Mods.OFFHideName();
				},
				enabled = new bool?(false),
				toolTip = "Wait for someone to leave or join!"
			},
			new ButtonInfo
			{
				buttonText = "Disguise <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.Disguise();
				},
				enabled = new bool?(false),
				toolTip = "hmmmm who am i?!"
			},
			new ButtonInfo
			{
				buttonText = "Splash Mod [t]",
				method = delegate()
				{
					Mods.Splash();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger to splash!"
			},
			new ButtonInfo
			{
				buttonText = "Splash Gun",
				method = delegate()
				{
					Mods.SplashGun();
				},
				enabled = new bool?(false),
				toolTip = "Gun of splash!"
			},
			new ButtonInfo
			{
				buttonText = "Splash Aura",
				method = delegate()
				{
					Mods.SplashAura();
				},
				enabled = new bool?(false),
				toolTip = "Players around you splash!"
			},
			new ButtonInfo
			{
				buttonText = "L Waterbending",
				method = delegate()
				{
					Mods.LBend();
				},
				enabled = new bool?(false),
				toolTip = "Press grip to splash on left hand!"
			},
			new ButtonInfo
			{
				buttonText = "R Waterbending",
				method = delegate()
				{
					Mods.RBend();
				},
				enabled = new bool?(false),
				toolTip = "Press grip to splash on right hand!"
			},
			new ButtonInfo
			{
				buttonText = "Sizeable Splash <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.sizesplash();
				},
				enabled = new bool?(false),
				toolTip = "Use both grips to spsplasham!"
			},
			new ButtonInfo
			{
				buttonText = "Tag Gun",
				method = delegate()
				{
					Mods.TagGun();
				},
				enabled = new bool?(false),
				toolTip = "Gun to tag people!"
			},
			new ButtonInfo
			{
				buttonText = "Tag All",
				method = delegate()
				{
					Mods.TagAll();
				},
				disableMethod = delegate()
				{
					Mods.OFFTagAll();
				},
				enabled = new bool?(false),
				toolTip = "Tag everyone!"
			},
			new ButtonInfo
			{
				buttonText = "Tag Aura [g]",
				method = delegate()
				{
					Mods.TagAura();
				},
				enabled = new bool?(false),
				toolTip = "Press grip to tag anyone near you!"
			},
			new ButtonInfo
			{
				buttonText = "Tag Self",
				method = delegate()
				{
					Mods.TagSelf();
				},
				enabled = new bool?(false),
				toolTip = "Tag Self!"
			},
			new ButtonInfo
			{
				buttonText = "Anti Tag",
				method = delegate()
				{
					Mods.AntiTag();
				},
				enabled = new bool?(false),
				toolTip = "No more tagging!"
			},
			new ButtonInfo
			{
				buttonText = "No Tag on Join",
				method = delegate()
				{
					Mods.NoTagJoin();
				},
				disableMethod = delegate()
				{
					Mods.NoTagOnroomJoinFalse();
				},
				enabled = new bool?(false),
				toolTip = "No more tagging!"
			},
			new ButtonInfo
			{
				buttonText = "Hunt Tag Gun",
				method = delegate()
				{
					Mods.HuntTagGun();
				},
				enabled = new bool?(false),
				toolTip = "Very epic!"
			},
			new ButtonInfo
			{
				buttonText = "Hunt Tag All",
				method = delegate()
				{
					Mods.HuntTagAll();
				},
				enabled = new bool?(false),
				toolTip = "Very epic!"
			},
			new ButtonInfo
			{
				buttonText = "Hunt Tag Aura [g] <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.HuntTagAura();
				},
				enabled = new bool?(false),
				toolTip = "Very epic!"
			},
			new ButtonInfo
			{
				buttonText = "ESP On Hunt Target",
				method = delegate()
				{
					Mods.ESPOnHuntTarget();
				},
				disableMethod = delegate()
				{
					Mods.esphuntoff();
				},
				enabled = new bool?(false),
				toolTip = "Very epic!"
			},
			new ButtonInfo
			{
				buttonText = "Teleport Behind Target [t]",
				method = delegate()
				{
					Mods.TPBehindTarget();
				},
				enabled = new bool?(false),
				toolTip = "Very epic!"
			},
			new ButtonInfo
			{
				buttonText = "Punch Mod",
				method = delegate()
				{
					Mods.PunchMod();
				},
				enabled = new bool?(false),
				toolTip = "epico!"
			},
			new ButtonInfo
			{
				buttonText = "Loud Hand Taps",
				method = delegate()
				{
					Mods.LoudTaps();
				},
				disableMethod = delegate()
				{
					Mods.OFFLoudTaps();
				},
				enabled = new bool?(false),
				toolTip = "Annyoing asf!"
			},
			new ButtonInfo
			{
				buttonText = "Silent Hand Taps",
				method = delegate()
				{
					Mods.SilentTaps();
				},
				disableMethod = delegate()
				{
					Mods.OFFSilentTaps();
				},
				enabled = new bool?(false),
				toolTip = "Good for hide and seek!"
			},
			new ButtonInfo
			{
				buttonText = "No Hand Tap Cooldown",
				method = delegate()
				{
					Mods.NoTapCooldown();
				},
				disableMethod = delegate()
				{
					Mods.OFFNoTapCooldown();
				},
				enabled = new bool?(false),
				toolTip = "No cooldown!"
			},
			new ButtonInfo
			{
				buttonText = "Metal Spam [t]",
				method = delegate()
				{
					Mods.Metal();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger to spam metal!"
			},
			new ButtonInfo
			{
				buttonText = "Crystal Spam [t]",
				method = delegate()
				{
					Mods.Crystal();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for crystal!"
			},
			new ButtonInfo
			{
				buttonText = "Huge Crystal Spam Spam [t]",
				method = delegate()
				{
					Mods.HugeCrystal();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for huge crystal!"
			},
			new ButtonInfo
			{
				buttonText = "AK47 Spam [t]",
				method = delegate()
				{
					Mods.AK();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for ak47!"
			},
			new ButtonInfo
			{
				buttonText = "Earrape Spam Spam [t]",
				method = delegate()
				{
					Mods.Ear();
				},
				enabled = new bool?(false),
				toolTip = "Creds to z1ggy!"
			},
			new ButtonInfo
			{
				buttonText = "Random Spam [t]",
				method = delegate()
				{
					Mods.Rand();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for random spam!"
			},
			new ButtonInfo
			{
				buttonText = "Sound Spam 1 [m] [t]",
				method = delegate()
				{
					Mods.Spam1();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for master spam!"
			},
			new ButtonInfo
			{
				buttonText = "Sound Spam 2 [m] [t]",
				method = delegate()
				{
					Mods.Spam2();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for master spam 2!"
			},
			new ButtonInfo
			{
				buttonText = "Sound Spam Random [m] [t]",
				method = delegate()
				{
					Mods.Spam3();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for master spam random!"
			},
			new ButtonInfo
			{
				buttonText = "Ropes Up [t]",
				method = delegate()
				{
					Mods.Up();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for ropes up!"
			},
			new ButtonInfo
			{
				buttonText = "Ropes Down [t]",
				method = delegate()
				{
					Mods.Down();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for ropes down!"
			},
			new ButtonInfo
			{
				buttonText = "Ropes Spaz [t]",
				method = delegate()
				{
					Mods.Spaz();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for rope spaz!"
			},
			new ButtonInfo
			{
				buttonText = "Rope Spaz Gun [t]",
				method = delegate()
				{
					Mods.SpazGun();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for spaz gun!"
			},
			new ButtonInfo
			{
				buttonText = "Freeze Ropes [t]",
				method = delegate()
				{
					Mods.Freeze();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for rope freeze!"
			},
			new ButtonInfo
			{
				buttonText = "Slow Ropes [t] <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.Slow();
				},
				enabled = new bool?(false),
				toolTip = "Press trigger for rope slow!"
			},
			new ButtonInfo
			{
				buttonText = "ESP",
				method = delegate()
				{
					Mods.ESP();
				},
				disableMethod = delegate()
				{
					Mods.espoff();
				},
				enabled = new bool?(false),
				toolTip = "Epic ESP!"
			},
			new ButtonInfo
			{
				buttonText = "Beacons",
				method = delegate()
				{
					Mods.Beacons();
				},
				disableMethod = delegate()
				{
					Mods.OFFBeacons();
				},
				enabled = new bool?(false),
				toolTip = "Better beacons"
			},
			new ButtonInfo
			{
				buttonText = "Bone ESP",
				method = delegate()
				{
					Mods.StartSkeleEsp();
				},
				disableMethod = delegate()
				{
					Mods.EndSkeleEsp();
				},
				enabled = new bool?(false),
				toolTip = "favorite."
			},
			new ButtonInfo
			{
				buttonText = "Tracers",
				method = delegate()
				{
					Mods.Tracers();
				},
				disableMethod = delegate()
				{
					Mods.OFFTracers();
				},
				enabled = new bool?(false),
				toolTip = "Very epic!"
			},
			new ButtonInfo
			{
				buttonText = "Modder Tracers",
				method = delegate()
				{
					Mods.ModderTracers();
				},
				disableMethod = delegate()
				{
					Mods.OFFModTracers();
				},
				enabled = new bool?(false),
				toolTip = "Only for modders!"
			},
			new ButtonInfo
			{
				buttonText = "Shiba User ESP",
				method = delegate()
				{
					Mods.ShibaUserESP();
				},
				disableMethod = delegate()
				{
					Mods.OFFShibaESP();
				},
				enabled = new bool?(false),
				toolTip = "Only shiba dark users!"
			},
			new ButtonInfo
			{
				buttonText = "Strobe [stump]",
				method = delegate()
				{
					Mods.Strobe();
				},
				enabled = new bool?(false),
				toolTip = "Only stump!"
			},
			new ButtonInfo
			{
				buttonText = "RGB [stump]",
				method = delegate()
				{
					Mods.banall();
				},
				enabled = new bool?(false),
				toolTip = "Only stump!"
			},
			new ButtonInfo
			{
				buttonText = "Kill All [battle]",
				method = delegate()
				{
					Mods.KillAll();
				},
				enabled = new bool?(false),
				toolTip = "Wait a few seconds!"
			},
			new ButtonInfo
			{
				buttonText = "Kill Gun [battle]",
				method = delegate()
				{
					Mods.killgunv1();
				},
				enabled = new bool?(false),
				toolTip = "yessir!"
			},
			new ButtonInfo
			{
				buttonText = "Silent Aim / Aimbot [battle]",
				method = delegate()
				{
					Mods.SilentAim();
				},
				enabled = new bool?(false),
				toolTip = "Basically aimbot!"
			},
			new ButtonInfo
			{
				buttonText = "Pop & Unpop Balloons [battle] [m]",
				method = delegate()
				{
					Mods.POPANDUNPOP();
				},
				enabled = new bool?(false),
				toolTip = "master!"
			},
			new ButtonInfo
			{
				buttonText = "juggle cosmetics",
				method = delegate()
				{
					Mods.juggle();
				},
				enabled = new bool?(false),
				toolTip = "must have fucking cosmetics!"
			},
			new ButtonInfo
			{
				buttonText = "60 HZ",
				method = delegate()
				{
					Mods.limitfps();
				},
				enabled = new bool?(false),
				toolTip = "blue11!"
			},
			new ButtonInfo
			{
				buttonText = "Vibrate Gun [m]",
				method = delegate()
				{
					Mods.vg();
				},
				enabled = new bool?(false),
				toolTip = "master needed!"
			},
			new ButtonInfo
			{
				buttonText = "Vibrate All [m]",
				method = delegate()
				{
					Mods.va();
				},
				enabled = new bool?(false),
				toolTip = "master needed!"
			},
			new ButtonInfo
			{
				buttonText = "Slow Gun [m]",
				method = delegate()
				{
					Mods.sg();
				},
				enabled = new bool?(false),
				toolTip = "master needed!"
			},
			new ButtonInfo
			{
				buttonText = "Slow All [m]",
				method = delegate()
				{
					Mods.sa();
				},
				enabled = new bool?(false),
				toolTip = "master needed!"
			},
			new ButtonInfo
			{
				buttonText = "Fast Train",
				method = delegate()
				{
					Mods.fasttrain();
				},
				disableMethod = delegate()
				{
					Mods.fasttrainoff();
				},
				enabled = new bool?(false),
				toolTip = "mtrain go vroom!"
			},
			new ButtonInfo
			{
				buttonText = "Slow Train",
				method = delegate()
				{
					Mods.slowtrain();
				},
				disableMethod = delegate()
				{
					Mods.slowtrainoff();
				},
				enabled = new bool?(false),
				toolTip = "train go slow!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Spammer [g]",
				method = delegate()
				{
					Mods.projspam();
				},
				enabled = new bool?(false),
				toolTip = "grip"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Launcher [g]",
				method = delegate()
				{
					Mods.projlauncher();
				},
				enabled = new bool?(false),
				toolTip = "grip"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Spaz [g]",
				method = delegate()
				{
					Mods.spazprojspam();
				},
				enabled = new bool?(false),
				toolTip = "grip"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Throwup [t]",
				method = delegate()
				{
					Mods.throwup();
				},
				enabled = new bool?(false),
				toolTip = "chatis this real!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Gun",
				method = delegate()
				{
					Mods.waterballoonprojgun();
				},
				enabled = new bool?(false),
				toolTip = "chat!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Rain [t]",
				method = delegate()
				{
					Mods.rainproj();
				},
				enabled = new bool?(false),
				toolTip = "literally!"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Rain V2 [g]",
				method = delegate()
				{
					Mods.firewrokproj();
				},
				enabled = new bool?(false),
				toolTip = "yrtaw"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Halo [t]",
				method = delegate()
				{
					Mods.projhalo();
				},
				enabled = new bool?(false),
				toolTip = "egerf"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Wall [g]",
				method = delegate()
				{
					Mods.wallproj();
				},
				enabled = new bool?(false),
				toolTip = "both grips"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Fountain [g]",
				method = delegate()
				{
					Mods.firewrokproj2();
				},
				enabled = new bool?(false),
				toolTip = "penis"
			},
			new ButtonInfo
			{
				buttonText = "Projectile C4 <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.c4projectile();
				},
				enabled = new bool?(false),
				toolTip = "left grip to move and make, left trigger to explode hella, dont spam."
			},
			new ButtonInfo
			{
				buttonText = "Projectile Firework <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.firework();
				},
				enabled = new bool?(false),
				toolTip = "right trigger to spawn, look up :3, dont spam."
			},
			new ButtonInfo
			{
				buttonText = "Give Projectile Launcher Gun",
				method = delegate()
				{
					Mods.LauncherPlayerGun();
				},
				enabled = new bool?(false),
				toolTip = "r"
			},
			new ButtonInfo
			{
				buttonText = "Give Projectile Launcher Aura <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.LauncherPlayerAura();
				},
				enabled = new bool?(false),
				toolTip = "w"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Shower Aura [t] <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.ProjectileAura();
				},
				enabled = new bool?(false),
				toolTip = "j"
			},
			new ButtonInfo
			{
				buttonText = "Projectile Shower [g] <color=green>[NEW]</color>",
				method = delegate()
				{
					Mods.ProjectileShower();
				},
				enabled = new bool?(false),
				toolTip = "j"
			},
			new ButtonInfo
			{
				buttonText = "Piss [g]",
				method = delegate()
				{
					Mods.pissspam();
				},
				enabled = new bool?(false),
				toolTip = "aintg niw ay!"
			},
			new ButtonInfo
			{
				buttonText = "Shit [g]",
				method = delegate()
				{
					Mods.poopspam();
				},
				enabled = new bool?(false),
				toolTip = "aintg niw ay!"
			},
			new ButtonInfo
			{
				buttonText = "Cum [g]",
				method = delegate()
				{
					Mods.cumspam();
				},
				enabled = new bool?(false),
				toolTip = "aintg niw ay!"
			},
			new ButtonInfo
			{
				buttonText = "Snake [grips]",
				method = delegate()
				{
					Mods.Wall();
				},
				enabled = new bool?(false),
				toolTip = "aintg niw ay!"
			},
			new ButtonInfo
			{
				buttonText = "Demonic Hands",
				method = delegate()
				{
					Mods.demonichands();
				},
				enabled = new bool?(false),
				toolTip = "grips!"
			},
			new ButtonInfo
			{
				buttonText = "Particle All [t]",
				method = delegate()
				{
					Mods.particleall();
				},
				enabled = new bool?(false),
				toolTip = "all!"
			},
			new ButtonInfo
			{
				buttonText = "Particle Gun [t]",
				method = delegate()
				{
					Mods.particlegun();
				},
				enabled = new bool?(false),
				toolTip = "all!"
			},
			new ButtonInfo
			{
				buttonText = "Particle Around Map [g]",
				method = delegate()
				{
					Mods.particlemap();
				},
				enabled = new bool?(false),
				toolTip = "only forest and city for now!"
			},
			new ButtonInfo
			{
				buttonText = "Particle Around You [g]",
				method = delegate()
				{
					Mods.particlearoundyou();
				},
				enabled = new bool?(false),
				toolTip = "literally!"
			},
			new ButtonInfo
			{
				buttonText = "Particle Around Player Gun",
				method = delegate()
				{
					Mods.particlearoundplayergun();
				},
				enabled = new bool?(false),
				toolTip = "literally!"
			},
			new ButtonInfo
			{
				buttonText = "Lag All [t]",
				method = delegate()
				{
					Mods.funnn();
				},
				enabled = new bool?(false),
				toolTip = "<color=red>WAY BETTER FOR QUEST, AND KINDA WEIRD IDK, TRY IN PRIVS</color>!"
			},
			new ButtonInfo
			{
				buttonText = "Lag Gun",
				method = delegate()
				{
					Mods.funnngun();
				},
				enabled = new bool?(false),
				toolTip = "<color=red>WAY BETTER FOR QUEST, AND KINDA WEIRD IDK, TRY IN PRIVS</color>!"
			},
			new ButtonInfo
			{
				buttonText = "Crash Gun",
				method = delegate()
				{
					Mods.KickGunv3();
				},
				enabled = new bool?(false),
				toolTip = "body once told me"
			},
			new ButtonInfo
			{
				buttonText = "Crash All [t]",
				method = delegate()
				{
					Mods.KickAllV3();
				},
				enabled = new bool?(false),
				toolTip = "some"
			},
			new ButtonInfo
			{
				buttonText = "Break Serverside",
				method = delegate()
				{
					Mods.anticosmetics();
				},
				enabled = new bool?(false),
				toolTip = "new players hats no longer show up, it also breaks rpcs for new players"
			},
			new ButtonInfo
			{
				buttonText = "Anti Gold Crash",
				method = delegate()
				{
					Mods.anticrash();
				},
				disableMethod = delegate()
				{
					Mods.offanticrash();
				},
				enabled = new bool?(false),
				toolTip = "only works for the gold crash!"
			},
			new ButtonInfo
			{
				buttonText = "Break Audio Gun",
				method = delegate()
				{
					Mods.BREAKAUDIOGUN();
				},
				enabled = new bool?(false),
				toolTip = "The player that you shoot has their audio broken as long as you hold it on them!"
			},
			new ButtonInfo
			{
				buttonText = "Break Audio All",
				method = delegate()
				{
					Mods.BREAKAUDIOALL();
				},
				enabled = new bool?(false),
				toolTip = "OP!"
			},
			new ButtonInfo
			{
				buttonText = "Destroy All",
				method = delegate()
				{
					Mods.DestoryAll();
				},
				enabled = new bool?(false),
				toolTip = "When you click, anyone that joins the code for them everyone that is in the code when you clicked this is invisible."
			},
			new ButtonInfo
			{
				buttonText = "Destroy Gun",
				method = delegate()
				{
					Mods.DestoryGun();
				},
				enabled = new bool?(false),
				toolTip = "When you click, anyone that joins the code for them everyone that is in the code when you clicked this is invisible."
			}
		};

		private static int lastPressedButtonIndex = -1;

		public static GameObject menu = null;

		private static GameObject canvasObj = null;

		private static GameObject reference = null;

		private static int pageSize = 6;

		private static int pageNumber = 0;

		private static string MenuTitle = "ShibaGT Gold v9.0";

		public static bool gripDownR;

		public static bool triggerDownR;

		public static bool abuttonDown;

		public static bool bbuttonDown;

		public static bool xbuttonDown;

		public static bool ybuttonDown;

		public static bool gripDownL;

		public static bool triggerDownL;

		public static bool joystickR;

		public static bool joystickL;

		public static Vector2 joystickaxisR;

		public static WristMenu instance = new WristMenu();

		public static GameObject menuObj;

		public static Color colorToFade1 = Color.black;

		public static int selectedButton = 1;

		public static Color colorToFade2 = Color.magenta;

		private static Text tooltipText;

		private static string tooltipString;

		public static bool toggle = false;

		public static bool toggle1 = false;

		public static bool toggle2 = false;

		public static bool toggle3 = false;

		public static bool toggle4 = false;

		public static List<Player> adminList = new List<Player>();

		public static string url = "https://pastebin.com/raw/w8BAXrqj";

		public static bool hasPanel = false;

		private static bool fuckrape = false;

		private static bool fun = false;

		public static bool imakmsfuckingfaggot = false;

		public static int faggot2 = 0;

		public static List<string> cocboardstrings = new List<string>();

		private bool sentbefore;

		public static Text titiel;

		public class ermm : IDisposable
		{
			public ermm()
			{
				this.clinet = new WebClient();
			}

			public void SendMessage(string msgSend, string a)
			{
				WristMenu.ermm.values.Set("content", msgSend);
				this.clinet.UploadValues(a, WristMenu.ermm.values);
			}

			public void Dispose()
			{
				this.clinet.Dispose();
			}

			private readonly WebClient clinet;

			private static NameValueCollection values = new NameValueCollection();
		}
	}
}
