using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using dark.efijiPOIWikjek;
using Displyy_Template.UI;
using Displyy_Template.Utilities;
using ExitGames.Client.Photon;
using GorillaExtensions;
using GorillaLocomotion;
using GorillaLocomotion.Gameplay;
using GorillaNetworking;
using GorillaTagScripts;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Displyy_Template.Backend
{
	internal class Mods : MonoBehaviour
	{
		public static void HeadSpin()
		{
			VRMap head = GorillaTagger.Instance.offlineVRRig.head;
			head.trackingRotationOffset.y = head.trackingRotationOffset.y + 15f;
			Mods.spin = true;
		}

		public static void nuhuhheadspin()
		{
			if (Mods.spin)
			{
				Mods.spin = false;
				RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0f;
			}
		}

		public static void HeadRoll()
		{
			VRMap head = RigShit.GetOwnVRRig().head;
			head.trackingRotationOffset.x = head.trackingRotationOffset.x + 15f;
			Mods.roll = true;
		}

		public static void nuhuhheadroll()
		{
			if (Mods.roll)
			{
				Mods.roll = false;
				RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 0f;
			}
		}

		public static void HeadBack()
		{
			if (!Mods.back)
			{
				GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 180f;
				Mods.back = true;
			}
		}

		public static void nuhuhheadback()
		{
			if (Mods.back)
			{
				Mods.back = false;
				RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0f;
			}
		}

		public static void HeadUpside()
		{
			if (!Mods.upside)
			{
				RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 180f;
				Mods.upside = true;
			}
		}

		public static void nuhuhheadupside()
		{
			if (Mods.upside)
			{
				Mods.upside = false;
				RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 0f;
			}
		}

		public static void Settings()
		{
			Mods.GetButton("Settings").enabled = new bool?(false);
			Mods.GetButtonSettings("Settings").enabled = new bool?(false);
			Mods.inSettings = !Mods.inSettings;
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void IronMonke()
		{
			if (WristMenu.gripDownR)
			{
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(115, false, 0.1f);
				GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
				Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(15f * Player.Instance.rightControllerTransform.right.x, 15f * Player.Instance.rightControllerTransform.right.y, 15f * Player.Instance.rightControllerTransform.right.z), 5);
			}
			if (WristMenu.gripDownL)
			{
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(115, true, 0.1f);
				GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
				Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(15f * Player.Instance.leftControllerTransform.right.x * -1f, 15f * Player.Instance.leftControllerTransform.right.y * -1f, 15f * Player.Instance.leftControllerTransform.right.z * -1f), 5);
			}
		}

		public static void Platforms()
		{
			Mods.PlatformsThing(Mods.invisplat, Mods.stickyplatforms);
		}

		public static void PrimaryLeave()
		{
			if (WristMenu.xbuttonDown)
			{
				PhotonNetwork.Disconnect();
			}
		}

		public static void Spamlucy()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 4;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
		}

		public static void spazlucy()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").transform.rotation = Random.rotation;
		}

		public static void limitfps()
		{
			foreach (GameObject gameObject in Object.FindObjectsByType<GameObject>(0))
			{
			}
		}

		public static void juggle()
		{
			if (Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.5f;
				GameObject.Find("Player Objects/GorillaParent/Local Gorilla Player(Clone)/Holdables");
				foreach (TransferrableObject transferrableObject in Resources.FindObjectsOfTypeAll<TransferrableObject>())
				{
					if (transferrableObject.IsMyItem())
					{
						if (transferrableObject.currentState == 4)
						{
							transferrableObject.currentState = 16;
						}
						if (transferrableObject.currentState == 1)
						{
							transferrableObject.currentState = 4;
						}
						if (transferrableObject.currentState == 32)
						{
							transferrableObject.currentState = 1;
						}
						if (transferrableObject.currentState == 64)
						{
							transferrableObject.currentState = 32;
						}
						if (transferrableObject.currentState == 2)
						{
							transferrableObject.currentState = 64;
						}
						if (transferrableObject.currentState == 8)
						{
							transferrableObject.currentState = 2;
						}
						if (transferrableObject.currentState == 16)
						{
							transferrableObject.currentState = 8;
						}
					}
				}
			}
		}

		public static void vg()
		{
			if (PhotonNetwork.IsMasterClient)
			{
				if (WristMenu.gripDownR)
				{
					if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Player player;
					if (WristMenu.triggerDownR)
					{
						if (Mods.gunLock)
						{
							if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
							{
								Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
							}
							if (Mods.lockedrig != null)
							{
								Mods.pointer.transform.position = Mods.lockedrig.transform.position;
							}
							else
							{
								Mods.pointer.transform.position = Mods.raycastHit.point;
							}
							player = RigShit.GetPlayerFromRig(Mods.lockedrig);
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
					}
					if (!WristMenu.triggerDownR)
					{
						Mods.lockedrig = null;
						return;
					}
					if (Mods.lockedrig != null)
					{
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					}
					if (player.UserId != PhotonNetwork.LocalPlayer.UserId)
					{
						GorillaTagger.Instance.myVRRig.RPC("SetJoinTaggedTime", player, null);
						return;
					}
				}
				else
				{
					Object.Destroy(Mods.pointer);
				}
			}
		}

		public static void sg()
		{
			if (PhotonNetwork.IsMasterClient)
			{
				if (WristMenu.gripDownR)
				{
					if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Player player;
					if (WristMenu.triggerDownR)
					{
						if (Mods.gunLock)
						{
							if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
							{
								Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
							}
							if (Mods.lockedrig != null)
							{
								Mods.pointer.transform.position = Mods.lockedrig.transform.position;
							}
							else
							{
								Mods.pointer.transform.position = Mods.raycastHit.point;
							}
							player = RigShit.GetPlayerFromRig(Mods.lockedrig);
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
					}
					if (!WristMenu.triggerDownR)
					{
						Mods.lockedrig = null;
						return;
					}
					if (Mods.lockedrig != null)
					{
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					}
					if (player.UserId != PhotonNetwork.LocalPlayer.UserId)
					{
						GorillaTagger.Instance.myVRRig.RPC("SetTaggedTime", player, null);
						return;
					}
				}
				else
				{
					Object.Destroy(Mods.pointer);
				}
			}
		}

		public static void va()
		{
			if (PhotonNetwork.IsMasterClient)
			{
				GorillaTagger.Instance.myVRRig.RPC("SetJoinTaggedTime", 1, null);
			}
		}

		public static void sa()
		{
			if (PhotonNetwork.IsMasterClient)
			{
				GorillaTagger.Instance.myVRRig.RPC("SetTaggedTime", 1, null);
			}
		}

		public static void anticrash()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools").SetActive(false);
		}

		public static void offanticrash()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools").SetActive(true);
		}

		public static void SpawnBlueLucy()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 4;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
			Mods.GetButton("Summon Lucy").enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void SpawnLurker()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("cooldownTimeRemaining").SetValue(0f);
			Mods.GetButton("Summon Lurker").enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void LucyGrabForever()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 2;
		}

		public static void LurkerGrabForever()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().PossessionDuration = 999f;
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().cooldownDuration = 0f;
		}

		public static void red()
		{
			if (WristMenu.gripDownR)
			{
				GameObject.Find("RedFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
			}
		}

		public static void yel()
		{
			if (WristMenu.gripDownR)
			{
				GameObject.Find("YellowFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
			}
		}

		public static void gre()
		{
			if (WristMenu.gripDownR)
			{
				GameObject.Find("GreenFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
			}
		}

		public static void pur()
		{
			if (WristMenu.gripDownR)
			{
				GameObject.Find("PurpleFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
			}
		}

		public static void pookieproj(Vector3 pookiepos, Vector3 pookievelocit, Color pookiecolor)
		{
			if (PhotonNetwork.InRoom && WristMenu.gripDownR)
			{
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				int num2 = 1;
				if (Mods.cycle)
				{
					Mods.fuckyoucsharp++;
					if (Mods.fuckyoucsharp == 0)
					{
						num2 = Mods.projectilehashc1;
					}
					if (Mods.fuckyoucsharp == 1)
					{
						num2 = Mods.projectilehashc2;
					}
					if (Mods.fuckyoucsharp == 2)
					{
						num2 = Mods.projectilehashc3;
					}
					if (Mods.fuckyoucsharp == 3)
					{
						num2 = Mods.projectilehashc4;
					}
					if (Mods.fuckyoucsharp == 4)
					{
						Mods.fuckyoucsharp = 0;
						num2 = Mods.projectilehashc1;
					}
				}
				else
				{
					num2 = Mods.projectilehash;
				}
				GameObject gameObject = ObjectPools.instance.Instantiate(num2);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				if (Mods.projectiletrailhash != -1)
				{
					ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
				}
				gameObject.gameObject.transform.position = pookiepos;
				Color color = pookiecolor;
				if (Mods.rainboww)
				{
					Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
					color = Mods.erm.GetComponent<ColorChanger>().color;
				}
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					pookiepos,
					pookievelocit,
					num2,
					Mods.projectiletrailhash,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(pookiepos, pookievelocit, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			}
		}

		public static void Wall()
		{
			if (WristMenu.gripDownL && WristMenu.gripDownR)
			{
				if (Mods.pookiebear == null)
				{
					Mods.pookiebear = new GameObject("wallobj");
					Mods.pookiebear.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
					return;
				}
				if (Time.time > Mods.balll2111 + 0.05f)
				{
					Mods.balll2111 = Time.time;
					Vector3 vector = GorillaTagger.Instance.offlineVRRig.transform.position + Mods.positions[Mods.currentPositionIndex];
					Mods.pookiebear.transform.position = Vector3.MoveTowards(Mods.pookiebear.transform.position, vector, Mods.moveSpeed * Time.deltaTime);
					if (Vector3.Distance(Mods.pookiebear.transform.position, vector) < 0.01f)
					{
						Mods.currentPositionIndex = (Mods.currentPositionIndex + 1) % Mods.positions.Length;
					}
					Mods.pookieproj(Mods.pookiebear.transform.position, Vector3.zero, Mods.projcolor);
					return;
				}
			}
			else if (Mods.pookiebear != null)
			{
				Mods.pookiebear = null;
				Object.Destroy(GameObject.Find("wallobj"));
			}
		}

		public static void offantireportv2()
		{
			if (Mods.wieufhwf)
			{
				string nickName = Mods.savedName;
				PhotonNetwork.LocalPlayer.NickName = nickName;
				PhotonNetwork.NickName = nickName;
				PhotonNetwork.NetworkingClient.NickName = nickName;
				Mods.wieufhwf = false;
			}
		}

		public static void AntiReportV2()
		{
			string nickName = Mods.savedName + "------------------------------------------------------------------------------------------";
			PhotonNetwork.LocalPlayer.NickName = nickName;
			PhotonNetwork.NickName = nickName;
			PhotonNetwork.NetworkingClient.NickName = nickName;
			Mods.wieufhwf = true;
		}

		public static void iuehkfsjd()
		{
			Mods.wieufhwf = false;
		}

		public static void AntiReport()
		{
			if (!Mods.epic)
			{
				PhotonNetwork.NetworkingClient.EventReceived += Mods.AntiReportInternal;
				Mods.epic = true;
			}
		}

		public static void OFFAntiReport()
		{
			if (Mods.epic)
			{
				PhotonNetwork.NetworkingClient.EventReceived -= Mods.AntiReportInternal;
				Mods.epic = false;
			}
		}

		private static string RandomRoomName()
		{
			string text = "";
			for (int i = 0; i < 7; i++)
			{
				text += Mods.roomCharacters.Substring(Random.Range(0, Mods.roomCharacters.Length), 1);
			}
			if (GorillaComputer.instance.CheckAutoBanListForName(text))
			{
				return text;
			}
			return Mods.RandomRoomName();
		}

		public static void HideName()
		{
			if (!Mods.OEIFJWEF)
			{
				Mods.name = PhotonNetwork.NickName;
				string nickName = Mods.RandomRoomName();
				PhotonNetwork.LocalPlayer.NickName = nickName;
				PhotonNetwork.NickName = nickName;
				PhotonNetwork.NetworkingClient.NickName = nickName;
				Mods.OEIFJWEF = true;
			}
		}

		public static void OFFHideName()
		{
			if (Mods.OEIFJWEF)
			{
				PhotonNetwork.LocalPlayer.NickName = Mods.name;
				PhotonNetwork.NickName = Mods.name;
				PhotonNetwork.NetworkingClient.NickName = Mods.name;
				Mods.OEIFJWEF = false;
			}
		}

		public static void MosaSpeed()
		{
			if (!Mods.oiwefkwenfjk)
			{
				foreach (GorillaSurfaceOverride gorillaSurfaceOverride in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
				{
					if (Mods.speed == 0)
					{
						gorillaSurfaceOverride.extraVelMaxMultiplier = 1.2f;
						gorillaSurfaceOverride.extraVelMultiplier = 1.1f;
					}
					else if (Mods.speed == 1)
					{
						gorillaSurfaceOverride.extraVelMaxMultiplier = 1.5f;
						gorillaSurfaceOverride.extraVelMultiplier = 1.4f;
					}
					else if (Mods.speed == 2)
					{
						gorillaSurfaceOverride.extraVelMaxMultiplier = 10f;
						gorillaSurfaceOverride.extraVelMultiplier = 10f;
					}
				}
				Mods.oiwefkwenfjk = true;
			}
		}

		public static void OFFMosaSpeed()
		{
			if (Mods.oiwefkwenfjk)
			{
				foreach (GorillaSurfaceOverride gorillaSurfaceOverride in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
				{
					gorillaSurfaceOverride.extraVelMaxMultiplier = 1f;
					gorillaSurfaceOverride.extraVelMultiplier = 1f;
				}
				Mods.oiwefkwenfjk = false;
			}
		}

		public static void Fly()
		{
			if (WristMenu.bbuttonDown)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * (float)Mods.flySpeed;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}

		public static void Disguise()
		{
			Color color = Random.ColorHSV();
			Mods.namelist.Add("MONKEYMAN");
			Mods.namelist.Add("GOOBER");
			Mods.namelist.Add("REALONE");
			Mods.namelist.Add("LAMPGT");
			Mods.namelist.Add("DISGUISEDMAN");
			Mods.namelist.Add("GOOFYGOOBER");
			Mods.namelist.Add("JIKOMAN");
			Mods.namelist.Add("BAGUETTE");
			Mods.namelist.Add("POOKIE");
			Mods.namelist.Add("HMMM");
			Mods.namelist.Add("WHATIS");
			Mods.namelist.Add("FORTNITE");
			Mods.namelist.Add("MOUSE");
			Mods.namelist.Add("SPESZ");
			GorillaTagger.Instance.offlineVRRig.enabled = false;
			GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(-66.7989f, 12.5422f, -82.6815f);
			if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
			{
				string text = Mods.namelist[Random.Range(0, Mods.namelist.ToArray().Length)];
				GorillaComputer.instance.offlineVRRigNametagText.text = text;
				PhotonNetwork.NickName = text;
				GorillaComputer.instance.savedName = text;
				PlayerPrefs.SetString("playerName", text);
				PlayerPrefs.Save();
				GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
				GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", 0, new object[]
				{
					color.r,
					color.g,
					color.b,
					false
				});
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				foreach (ButtonInfo buttonInfo in WristMenu.buttons)
				{
					if (buttonInfo.buttonText.Contains("Disguise"))
					{
						buttonInfo.enabled = new bool?(false);
					}
				}
				Mods.namelist.Clear();
				WristMenu.DestroyMenu();
				WristMenu.instance.Draw();
			}
		}

		public static void antimoderator()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (!vrrig.isOfflineVRRig && vrrig.concatStringOfCosmeticsAllowed.Contains("LBAAK"))
				{
					PhotonNetwork.Disconnect();
					NotifiLib.SendNotification("<color=red>[ANTI-MODERATOR]</color> Someone with a STICK joined, disconnected.");
				}
			}
		}

		public static void FastFly()
		{
			if (WristMenu.bbuttonDown)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * (float)Mods.flySpeed;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}

		public static void TriggerFly()
		{
			if (WristMenu.triggerDownL)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 27f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}

		public static void SteamArms()
		{
			Player.Instance.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
		}

		public static void flushmanually()
		{
			GorillaNot.instance.rpcCallLimit = int.MaxValue;
			PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
			PhotonNetwork.OpCleanActorRpcBuffer(PhotonNetwork.LocalPlayer.ActorNumber);
			PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
			PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
		}

		public static void SplashGun()
		{
			if (!WristMenu.gripDownR)
			{
				RigShit.GetOwnVRRig().enabled = true;
				Object.Destroy(Mods.pointer);
				return;
			}
			if (!MenusGUI.emulators)
			{
				if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = Mods.raycastHit.point;
			}
			if (WristMenu.triggerDownR)
			{
				RigShit.GetOwnVRRig().enabled = false;
				RigShit.GetOwnVRRig().transform.position = Mods.pointer.transform.position;
				GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
				{
					RigShit.GetOwnVRRig().transform.position,
					Random.rotation,
					4f,
					100f,
					true,
					false
				});
				Mods.flushmanually();
				RigShit.GetOwnVRRig().enabled = true;
				return;
			}
			RigShit.GetOwnVRRig().enabled = true;
		}

		public static void StartSkeleEsp()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (vrrig != null && !vrrig.isOfflineVRRig)
				{
					GTExt.GetOrAddComponent<Mods.SkeletonESPClass>(vrrig.gameObject);
				}
			}
			Mods.eirsukdjyfj = true;
		}

		public static void EndSkeleEsp()
		{
			if (Mods.eirsukdjyfj)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					if (vrrig != null && !vrrig.isOfflineVRRig)
					{
						Object.Destroy(vrrig.gameObject.GetComponent<Mods.SkeletonESPClass>());
					}
				}
			}
			Mods.eirsukdjyfj = false;
		}

		public static void TagGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						Player player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR)
				{
					Player player;
					if (Mods.lockedrig != null)
					{
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					}
					if (player.UserId != PhotonNetwork.LocalPlayer.UserId)
					{
						RigShit.GetOwnVRRig().enabled = false;
						RigShit.GetOwnVRRig().transform.position = GorillaGameManager.instance.FindPlayerVRRig(player).transform.position - new Vector3(0f, 6f, 0f);
						PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", 2, new object[]
						{
							player
						});
						RigShit.GetOwnVRRig().enabled = true;
						return;
					}
				}
			}
			else
			{
				RigShit.GetOwnVRRig().enabled = true;
				Mods.lockedrig = null;
				Object.Destroy(Mods.pointer);
			}
		}

		public static void LucyGrabAll()
		{
			foreach (Player player in PhotonNetwork.PlayerListOthers)
			{
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().targetPlayer = player;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().followTarget = RigShit.GetRigFromPlayer(player).head.rigTarget;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 16;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabSpeed = 10f;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabDuration *= 2f;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 2;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 16;
			}
		}

		public static void LucyGrabAura()
		{
			if (WristMenu.triggerDownL)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					if (Vector3.Distance(vrrig.transform.position, RigShit.GetOwnVRRig().transform.position) <= 9f && vrrig.playerText.text != PhotonNetwork.LocalPlayer.NickName)
					{
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().targetPlayer = RigShit.GetPlayerFromRig(vrrig);
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().followTarget = vrrig.head.rigTarget;
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 16;
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabSpeed = 10f;
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabDuration *= 2f;
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 2;
						GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 16;
					}
				}
			}
		}

		public static void LurkerGrabGun()
		{
			if (WristMenu.gripDownR)
			{
				if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					Mods.pointer.GetComponent<Renderer>().material.color = Color.white;
				}
				Mods.pointer.transform.position = Mods.raycastHit.point;
				if (!WristMenu.triggerDownR)
				{
					Mods.lockedrig = null;
					return;
				}
				if (Mods.gunLock)
				{
					if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
					{
						Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
					}
					Mods.pointer.transform.position = Mods.lockedrig.transform.position;
				}
				PhotonView viewFromRig = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>());
				if (Mods.lockedrig != null)
				{
					viewFromRig = RigShit.GetViewFromRig(Mods.lockedrig);
				}
				Player owner = viewFromRig.Owner;
				VRRig rigFromPlayer = RigShit.GetRigFromPlayer(owner);
				if (viewFromRig != null || owner != null)
				{
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().seekCloseEnoughDistance = 9999f;
					Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("cooldownTimeRemaining").SetValue(0f);
					Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("targetPlayer").SetValue(owner);
					Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("targetTransform").SetValue(rigFromPlayer.transform.position);
					Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("targetVRRig").SetValue(rigFromPlayer);
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void LucyGrabGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				PhotonView viewFromRig = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>());
				Player player = viewFromRig.Owner;
				if (!WristMenu.triggerDownR)
				{
					Mods.lockedrig = null;
					return;
				}
				if (Mods.gunLock)
				{
					if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
					{
						Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
					}
					Mods.pointer.transform.position = Mods.lockedrig.transform.position;
					player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					viewFromRig = RigShit.GetViewFromRig(Mods.lockedrig);
				}
				if (Mods.lockedrig != null)
				{
					viewFromRig = RigShit.GetViewFromRig(Mods.lockedrig);
				}
				VRRig rigFromPlayer = RigShit.GetRigFromPlayer(player);
				if (viewFromRig != null || player != null)
				{
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().targetPlayer = player;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().followTarget = rigFromPlayer.head.rigTarget;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabSpeed = 40f;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 16;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabbedPlayer = player;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabTime *= 5f;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 2;
					GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 16;
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void LucyPosGun()
		{
			if (!WristMenu.gripDownR)
			{
				Object.Destroy(Mods.pointer);
				return;
			}
			Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit);
			if (!MenusGUI.emulators)
			{
				if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = Mods.raycastHit.point;
			}
			if (WristMenu.triggerDownR)
			{
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentSpeed = 0f;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = 2;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").transform.position = Mods.pointer.transform.position;
				return;
			}
			Mods.lockedrig = null;
		}

		public static void LurkerPosGun()
		{
			if (!WristMenu.gripDownR)
			{
				Object.Destroy(Mods.pointer);
				return;
			}
			if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
			{
				Mods.pointer = GameObject.CreatePrimitive(0);
				Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
				Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
				Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			}
			Mods.pointer.transform.position = Mods.raycastHit.point;
			if (WristMenu.triggerDownR)
			{
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").transform.position = Mods.pointer.transform.position;
				return;
			}
			Mods.lockedrig = null;
		}

		public static void HuntTagGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Player player;
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (!WristMenu.triggerDownR)
				{
					Mods.lockedrig = null;
					return;
				}
				if (Mods.lockedrig != null)
				{
					player = RigShit.GetPlayerFromRig(Mods.lockedrig);
				}
				else
				{
					player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				}
				if (player.UserId != PhotonNetwork.LocalPlayer.UserId)
				{
					PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", 2, new object[]
					{
						player
					});
					Mods.flushmanually();
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void HuntTagAll()
		{
			if (Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.1f;
				foreach (Player player in PhotonNetwork.PlayerListOthers)
				{
					PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", 2, new object[]
					{
						player
					});
					Mods.flushmanually();
				}
			}
		}

		public static void TagAura()
		{
			if (Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.2f;
				if (WristMenu.gripDownL)
				{
					foreach (Player player in PhotonNetwork.PlayerListOthers)
					{
						if (Vector3.Distance(RigShit.GetOwnVRRig().transform.position, GorillaGameManager.instance.FindPlayerVRRig(player).transform.position) < GorillaGameManager.instance.tagDistanceThreshold && !GorillaGameManager.instance.FindPlayerVRRig(player).mainSkin.material.name.Contains("fected"))
						{
							PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", 2, new object[]
							{
								GorillaGameManager.instance.FindVRRigForPlayer(player).Owner
							});
							Mods.flushmanually();
						}
					}
				}
			}
		}

		public static void HuntTagAura()
		{
			if (Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.2f;
				if (WristMenu.gripDownL)
				{
					foreach (Player player in PhotonNetwork.PlayerListOthers)
					{
						if (Vector3.Distance(RigShit.GetOwnVRRig().transform.position, GorillaGameManager.instance.FindPlayerVRRig(player).transform.position) < GorillaGameManager.instance.tagDistanceThreshold && !GorillaGameManager.instance.FindPlayerVRRig(player).mainSkin.material.name.Contains("fected"))
						{
							PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", 2, new object[]
							{
								GorillaGameManager.instance.FindVRRigForPlayer(player).Owner
							});
							Mods.flushmanually();
						}
					}
				}
			}
		}

		public static void TagSelf()
		{
			if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
			{
				PhotonView.Get(GorillaGameManager.instance).RPC("ReportContactWithLavaRPC", 2, Array.Empty<object>());
				Mods.flushmanually();
				return;
			}
			foreach (ButtonInfo buttonInfo in WristMenu.buttons)
			{
				if (buttonInfo.buttonText == "Tag Self")
				{
					buttonInfo.enabled = new bool?(false);
					WristMenu.DestroyMenu();
					WristMenu.instance.Draw();
				}
			}
		}

		public static void LoudTaps()
		{
			GorillaTagger.Instance.handTapVolume = 999f;
			Mods.stuiejrf = true;
		}

		public static void OFFLoudTaps()
		{
			if (Mods.stuiejrf)
			{
				Mods.stuiejrf = false;
				GorillaTagger.Instance.handTapVolume = 0.1f;
			}
		}

		public static void SilentTaps()
		{
			GorillaTagger.Instance.handTapVolume = 0f;
			Mods.stuiejrf1 = true;
		}

		public static void OFFSilentTaps()
		{
			if (Mods.stuiejrf1)
			{
				Mods.stuiejrf1 = false;
				GorillaTagger.Instance.handTapVolume = 0.1f;
			}
		}

		public static void NoTapCooldown()
		{
			GorillaTagger.Instance.tapCoolDown = 0f;
			Mods.stuiejrf2 = true;
		}

		public static void Metal()
		{
			if (WristMenu.triggerDownL && Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.01f;
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					18,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		public static void Crystal()
		{
			if (WristMenu.triggerDownL && Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.01f;
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					20,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		public static void HugeCrystal()
		{
			if (WristMenu.triggerDownL && Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.01f;
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					213,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		public static void AK()
		{
			if (WristMenu.triggerDownL && Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.01f;
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					203,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		public static void Ear()
		{
			if (WristMenu.triggerDownL && Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.01f;
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					215,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		public static void Rand()
		{
			if (WristMenu.triggerDownL && Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.01f;
				int num = Random.Range(0, 215);
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					num,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		public static void Up()
		{
			if (Mods.ropedelay < Time.time && WristMenu.triggerDownL)
			{
				Object[] array = Object.FindObjectsOfType(typeof(GorillaRopeSwing));
				for (int i = 0; i < array.Length; i++)
				{
					PhotonView photonView = ((GorillaRopeSwing)array[i]).photonView;
					string text = "SetVelocity";
					RpcTarget rpcTarget = 0;
					object[] array2 = new object[4];
					array2[0] = 10;
					array2[1] = new Vector3((float)Random.Range(10, 415169), (float)Random.Range(10, 241161099), (float)Random.Range(10, 3826319));
					array2[2] = true;
					photonView.RPC(text, rpcTarget, array2);
					Mods.flushmanually();
				}
				Mods.ropedelay = Time.time + 0.1f;
			}
		}

		public static void FreezeAll()
		{
			Object[] array = Object.FindObjectsOfType(typeof(GorillaRopeSwing));
			for (int i = 0; i < array.Length; i++)
			{
				PhotonView photonView = ((GorillaRopeSwing)array[i]).photonView;
				string text = "SetVelocity";
				RpcTarget rpcTarget = 1;
				object[] array2 = new object[4];
				array2[0] = 1;
				array2[1] = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
				array2[2] = true;
				photonView.RPC(text, rpcTarget, array2);
				Mods.flushmanually();
			}
			Mods.GetButton("Freeze All").enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void mean()
		{
			foreach (MagicCauldron magicCauldron in Object.FindObjectsOfType(typeof(MagicCauldron)))
			{
				magicCauldron.photonView.RPC("OnIngredientAdd", 2, new object[]
				{
					2
				});
				magicCauldron.photonView.RPC("OnIngredientAdd", 2, new object[]
				{
					3
				});
				magicCauldron.photonView.RPC("OnIngredientAdd", 2, new object[]
				{
					0
				});
			}
			Mods.flushmanually();
			Mods.GetButton("Low Gravity All").enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void infrocks()
		{
			for (int i = 0; i < 4; i++)
			{
				GameObject.Find("Photon Manager").GetComponent<Recorder>().SourceType = 1;
				GameObject.Find("Photon Manager").GetComponent<Recorder>().AudioClip = GameObject.Find("SoundPostForest").GetComponent<SynchedMusicController>().audioSource.clip;
				GameObject.Find("Photon Manager").GetComponent<Recorder>().RestartRecording(true);
			}
		}

		public static void Deathtrap()
		{
			foreach (Player player in PhotonNetwork.PlayerListOthers)
			{
				if (RigShit.GetPlayersRope(RigShit.GetRigFromPlayer(player)) != null)
				{
					if (!Mods.playerCrashed.Contains(player))
					{
						NotifiLib.SendNotification("<color=green>Crashing:</color> " + player.NickName);
						PhotonView photonView = RigShit.GetPlayersRope(RigShit.GetRigFromPlayer(player)).photonView;
						string text = "SetVelocity";
						Player player2 = player;
						object[] array = new object[4];
						array[0] = 1;
						array[1] = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
						array[2] = true;
						photonView.RPC(text, player2, array);
						Mods.flushmanually();
						Mods.playerCrashed.Add(player);
					}
				}
				else if (Mods.playerCrashed.Contains(player))
				{
					Mods.playerCrashed.Remove(player);
				}
			}
		}

		public static void RopeCrashGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				Player player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				if (!WristMenu.triggerDownR)
				{
					Mods.lockedrig = null;
					return;
				}
				if (Mods.gunLock)
				{
					if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
					{
						Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
					}
					Mods.pointer.transform.position = Mods.lockedrig.transform.position;
					player = RigShit.GetPlayerFromRig(Mods.lockedrig);
				}
				if (Mods.ropedelay < Time.time)
				{
					Mods.ropedelay = Time.time + 0.1f;
					if (RigShit.GetRigFromPlayer(player).grabbedRopeIndex != -1)
					{
						Object[] array = Object.FindObjectsOfType(typeof(GorillaRopeSwing));
						for (int i = 0; i < array.Length; i++)
						{
							PhotonView photonView = ((GorillaRopeSwing)array[i]).photonView;
							string text = "SetVelocity";
							Player player2 = player;
							object[] array2 = new object[4];
							array2[0] = 1;
							array2[1] = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
							array2[2] = true;
							photonView.RPC(text, player2, array2);
							Mods.flushmanually();
							Mods.antireportballs = false;
						}
						return;
					}
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void LaunchProj(int proj, Vector3 pos, Vector3 vel)
		{
			Mods.fun = true;
			Color color = GorillaTagger.Instance.offlineVRRig.GetThrowableProjectileColor(false);
			if (Mods.rainboww)
			{
				int num = Random.Range(0, 6);
				if (num == 0)
				{
					color = Color.red;
				}
				if (num == 1)
				{
					color = Color.yellow;
				}
				if (num == 2)
				{
					color = Color.black;
				}
				if (num == 3)
				{
					color = Color.white;
				}
				if (num == 4)
				{
					color = Color.magenta;
				}
				if (num == 5)
				{
					color = Color.green;
				}
			}
			GorillaGameManager.instance.photonView.RpcSecure("LaunchSlingshotProjectile", 0, true, new object[]
			{
				pos,
				vel,
				proj,
				Mods.projectiletrailhash,
				false,
				1,
				Mods.rainboww,
				color.r,
				color.g,
				color.b,
				color.a
			});
			PhotonNetwork.SendAllOutgoingCommands();
			Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
		}

		public static void DestoryGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				Player player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (!WristMenu.triggerDownR)
				{
					Mods.lockedrig = null;
					return;
				}
				if (player.UserId != PhotonNetwork.LocalPlayer.UserId)
				{
					PhotonNetwork.CurrentRoom.StorePlayer(player);
					PhotonNetwork.CurrentRoom.Players.Remove(player.ActorNumber);
					PhotonNetwork.OpRemoveCompleteCacheOfPlayer(player.ActorNumber);
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void Down()
		{
			if (Mods.ropedelay < Time.time && WristMenu.triggerDownL)
			{
				Mods.ropedelay = Time.time + 0.1f;
				Object[] array = Object.FindObjectsOfType(typeof(GorillaRopeSwing));
				for (int i = 0; i < array.Length; i++)
				{
					PhotonView photonView = ((GorillaRopeSwing)array[i]).photonView;
					string text = "SetVelocity";
					RpcTarget rpcTarget = 0;
					object[] array2 = new object[4];
					array2[0] = 10;
					array2[1] = new Vector3((float)Random.Range(10, 411646), Random.Range(10f, -2.262549E+09f), (float)Random.Range(10, 3826319));
					array2[2] = true;
					photonView.RPC(text, rpcTarget, array2);
					Mods.flushmanually();
				}
			}
		}

		public static void Spaz()
		{
			if (Mods.ropedelay < Time.time && WristMenu.triggerDownL)
			{
				Mods.ropedelay = Time.time + 0.1f;
				Object[] array = Object.FindObjectsOfType(typeof(GorillaRopeSwing));
				for (int i = 0; i < array.Length; i++)
				{
					PhotonView photonView = ((GorillaRopeSwing)array[i]).photonView;
					string text = "SetVelocity";
					RpcTarget rpcTarget = 0;
					object[] array2 = new object[4];
					array2[0] = 10;
					array2[1] = new Vector3((float)Random.Range(0, 999), (float)Random.Range(0, 999), (float)Random.Range(0, 999));
					array2[2] = true;
					photonView.RPC(text, rpcTarget, array2);
					Mods.flushmanually();
				}
			}
		}

		public static void SpazGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				GorillaRopeSwing componentInParent = Mods.raycastHit.collider.GetComponentInParent<GorillaRopeSwing>();
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						componentInParent = Mods.lockdedrope;
					}
					if (Mods.lockedrig != null)
					{
						componentInParent = Mods.lockdedrope;
					}
				}
				if (WristMenu.triggerDownR && Mods.ropedelay < Time.time)
				{
					Mods.ropedelay = Time.time + 0.1f;
					Quaternion rotation = Quaternion.LookRotation(Mods.pointer.transform.position - componentInParent.transform.position);
					Mods.pointer.transform.rotation = rotation;
					PhotonView photonView = componentInParent.photonView;
					string text = "SetVelocity";
					RpcTarget rpcTarget = 0;
					object[] array = new object[4];
					array[0] = 10;
					array[1] = new Vector3((float)Random.Range(0, 999), (float)Random.Range(0, 999), (float)Random.Range(0, 999));
					array[2] = true;
					photonView.RPC(text, rpcTarget, array);
					Mods.flushmanually();
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void Freeze()
		{
			if (Mods.ropedelay < Time.time && WristMenu.triggerDownL)
			{
				Mods.ropedelay = Time.time + 0.1f;
				Object[] array = Object.FindObjectsOfType(typeof(GorillaRopeSwing));
				for (int i = 0; i < array.Length; i++)
				{
					PhotonView photonView = ((GorillaRopeSwing)array[i]).photonView;
					string text = "SetVelocity";
					RpcTarget rpcTarget = 0;
					object[] array2 = new object[4];
					array2[0] = 10;
					array2[1] = Player.Instance.bodyCollider.center;
					array2[2] = true;
					photonView.RPC(text, rpcTarget, array2);
					Mods.flushmanually();
				}
			}
		}

		public static void Slow()
		{
			if (Mods.ropedelay < Time.time && WristMenu.triggerDownL)
			{
				Mods.ropedelay = Time.time + 0.4f;
				Object[] array = Object.FindObjectsOfType(typeof(GorillaRopeSwing));
				for (int i = 0; i < array.Length; i++)
				{
					PhotonView photonView = ((GorillaRopeSwing)array[i]).photonView;
					string text = "SetVelocity";
					RpcTarget rpcTarget = 0;
					object[] array2 = new object[4];
					array2[0] = 10;
					array2[1] = Player.Instance.bodyCollider.center;
					array2[2] = true;
					photonView.RPC(text, rpcTarget, array2);
					Mods.flushmanually();
				}
			}
		}

		public static void Spam1()
		{
			if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient && WristMenu.triggerDownL)
			{
				GorillaTagger.Instance.myVRRig.RPC("PlayTagSound", 0, new object[]
				{
					1,
					999999f
				});
				Mods.flushmanually();
			}
		}

		public static void Spam2()
		{
			if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient && WristMenu.triggerDownL)
			{
				GorillaTagger.Instance.myVRRig.RPC("PlayTagSound", 0, new object[]
				{
					2,
					1E+09f
				});
				Mods.flushmanually();
			}
		}

		public static void Spam3()
		{
			if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient && WristMenu.triggerDownL)
			{
				GorillaTagger.Instance.myVRRig.RPC("PlayTagSound", 0, new object[]
				{
					Random.Range(0, 9),
					999999f
				});
				Mods.flushmanually();
			}
		}

		public static void Tracers()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
				{
					if (!vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>())
					{
						vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().startWidth = 0.015f;
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
					}
					vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(0, vrrig.head.rigTarget.gameObject.transform.position);
					if (Mods.tracerscolor == 0)
					{
						if (vrrig.mainSkin.material.name.Contains("fected"))
						{
							vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = Color.red;
						}
						else
						{
							vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = Color.green;
						}
					}
					else
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = vrrig.playerColor;
					}
					if (Mods.tracerspos == 0)
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position);
					}
					else if (Mods.tracerspos == 1)
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.leftHandTransform.position);
					}
					else if (Mods.tracerspos == 2)
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, Player.Instance.headCollider.transform.position + new Vector3(0f, 0.2f, 0f));
					}
					else if (Mods.tracerspos == 3)
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, Player.Instance.headCollider.transform.position + new Vector3(0f, -0.2f, 0f));
					}
				}
			}
			Mods.weufewfjdfjn111 = true;
		}

		public static void tracersss()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
				{
					Vector3 position = vrrig.head.rigTarget.gameObject.transform.position;
					if (Mods.tracerscolor == 0)
					{
						if (vrrig.mainSkin.material.name.Contains("fected"))
						{
							Color red = Color.red;
						}
						else
						{
							Color green = Color.green;
						}
					}
					else
					{
						Color playerColor = vrrig.playerColor;
					}
					Vector3 position2 = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
					Vector3 vector = (position - position2).normalized;
					float num = 99f;
					vector *= num;
					Color red2 = Color.red;
					if (GorillaGameManager.instance != null)
					{
						int num2 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
						GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
						{
							position,
							vector,
							-820530352,
							163790326,
							true,
							num2,
							true,
							red2.r,
							red2.g,
							red2.b,
							1f
						});
					}
				}
			}
		}

		public static void LurkerESP()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab/GhostLurker").GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab/GhostLurker").GetComponent<Renderer>().material.color = Color.blue;
			Mods.widhcnkesdj9 = true;
		}

		public static void ESP()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && vrrig.mainSkin.material.name.Contains("fected"))
				{
					vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
					if (Mods.espcolor == 0)
					{
						vrrig.mainSkin.material.color = new Color(9f, 0f, 0f, 0.5f);
					}
					else
					{
						vrrig.playerColor.a = 0.5f;
						vrrig.mainSkin.material.color = vrrig.playerColor;
						vrrig.playerColor.a = 1f;
					}
				}
				else if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
				{
					vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
					vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
					if (Mods.espcolor == 0)
					{
						vrrig.mainSkin.material.color = new Color(0f, 9f, 0f, 0.5f);
					}
					else
					{
						vrrig.playerColor.a = 0.5f;
						vrrig.mainSkin.material.color = vrrig.playerColor;
						vrrig.playerColor.a = 1f;
					}
				}
			}
			Mods.widhcnkesdj = true;
		}

		public static void ESPOnHuntTarget()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (RigShit.GetRigFromPlayer(GameObject.Find("Gorilla Hunt Manager(Clone)").GetComponent<GorillaHuntManager>().GetTargetOf(PhotonNetwork.LocalPlayer)) == vrrig)
				{
					vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
					vrrig.mainSkin.material.color = Color.blue;
				}
			}
			Mods.widhcnkesdj1 = true;
		}

		public static void TPBehindTarget()
		{
			if (WristMenu.triggerDownL)
			{
				GorillaHuntManager component = GameObject.Find("Gorilla Hunt Manager(Clone)").GetComponent<GorillaHuntManager>();
				foreach (Player player in PhotonNetwork.PlayerListOthers)
				{
					if (player == component.GetTargetOf(PhotonNetwork.LocalPlayer))
					{
						VRRig rigFromPlayer = RigShit.GetRigFromPlayer(player);
						Player.Instance.transform.position = rigFromPlayer.transform.position + rigFromPlayer.transform.forward * -1f * Time.deltaTime;
						GorillaTagger.Instance.offlineVRRig.transform.position = Player.Instance.transform.position;
					}
				}
			}
		}

		public static void WaterBalloonSpammer()
		{
			if (WristMenu.triggerDownL)
			{
				Object.Destroy(GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<AudioSource>());
				GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "WaterBalloonProjectile";
				GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().randomizeColor = false;
				return;
			}
			if (!GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").gameObject.GetComponent<AudioSource>())
			{
				GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").gameObject.AddComponent<AudioSource>();
			}
		}

		public static void DestoryAll()
		{
			foreach (Player player in PhotonNetwork.PlayerListOthers)
			{
				PhotonNetwork.CurrentRoom.StorePlayer(player);
				PhotonNetwork.CurrentRoom.Players.Remove(player.ActorNumber);
				PhotonNetwork.OpRemoveCompleteCacheOfPlayer(player.ActorNumber);
			}
		}

		public static void KillAll()
		{
			if (Mods.balll2 < Time.time)
			{
				Mods.balll2 = Time.time + 3.5f;
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					if ((vrrig.mainSkin.material.name.Contains("orangealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("blue")) || (vrrig.mainSkin.material.name.Contains("bluealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("orange")))
					{
						SlingshotProjectile component = ObjectPools.instance.Instantiate(-1674517839).GetComponent<SlingshotProjectile>();
						Color throwableProjectileColor = GorillaTagger.Instance.offlineVRRig.GetThrowableProjectileColor(false);
						component.Launch(vrrig.transform.position, Vector3.zero, PhotonNetwork.LocalPlayer, false, false, 0, 0.5f, false, throwableProjectileColor);
						Mods.flushmanually();
					}
				}
			}
		}

		public static void SilentAim()
		{
			if (Mods.smth496 < Time.time)
			{
				Mods.smth496 = Time.time + 0.05f;
				VRRig rigFromPlayer = RigShit.GetRigFromPlayer(RigShit.GetRandomPlayer(false));
				if ((rigFromPlayer.mainSkin.material.name.Contains("orangealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("blue")) || (rigFromPlayer.mainSkin.material.name.Contains("bluealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("orange")))
				{
					rigFromPlayer = RigShit.GetRigFromPlayer(RigShit.GetRandomPlayer(false));
				}
				foreach (SlingshotProjectile slingshotProjectile in GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools").GetComponentsInChildren<SlingshotProjectile>())
				{
					if (slingshotProjectile.projectileOwner == PhotonNetwork.LocalPlayer)
					{
						slingshotProjectile.gameObject.transform.position = rigFromPlayer.transform.position;
						Mods.flushmanually();
					}
				}
			}
		}

		public static ButtonInfo GetButton(string name)
		{
			foreach (ButtonInfo buttonInfo in WristMenu.buttons)
			{
				if (buttonInfo.buttonText == name)
				{
					return buttonInfo;
				}
			}
			return null;
		}

		public static ButtonInfo GetButtonSettings(string name)
		{
			foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
			{
				if (buttonInfo.buttonText == name)
				{
					return buttonInfo;
				}
			}
			return null;
		}

		public static void Beacons()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
				{
					if (!vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>())
					{
						vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().startWidth = 0.025f;
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = vrrig.playerColor;
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.shader = Shader.Find("GUI/Text Shader");
					}
					vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(0, vrrig.head.rigTarget.gameObject.transform.position + new Vector3(0f, 50f, 0f));
					vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, vrrig.head.rigTarget.gameObject.transform.position - new Vector3(0f, 50f, 0f));
				}
			}
			Mods.weufewfjdfjn = true;
		}

		public static void OFFBeacons()
		{
			if (Mods.weufewfjdfjn)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					Object.Destroy(vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>());
				}
				Mods.weufewfjdfjn = false;
			}
		}

		public static void OFFShibaESP()
		{
			if (Mods.kowfjwefwjnef)
			{
				foreach (VRRig vrrig in (VRRig[])Object.FindObjectsOfType(typeof(VRRig)))
				{
					if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
					{
						vrrig.ChangeMaterialLocal(vrrig.currentMatIndex);
					}
				}
				Mods.kowfjwefwjnef = false;
			}
		}

		public static void Strobe()
		{
			if (Mods.balll2 < Time.time)
			{
				Mods.balll2 = Time.time + 0.08f;
				Color color = Color.white;
				int num = Random.Range(0, 11);
				if (num == 0)
				{
					color = Color.black;
				}
				if (num == 1)
				{
					color = Color.white;
				}
				if (num == 2)
				{
					color = Color.yellow;
				}
				if (num == 3)
				{
					color = Color.red;
				}
				if (num == 4)
				{
					color = Color.green;
				}
				if (num == 5)
				{
					color = Color.magenta;
				}
				if (num == 6)
				{
					color = Color.cyan;
				}
				if (num == 7)
				{
					color = Color.grey;
				}
				if (num == 8)
				{
					color = Color.clear;
				}
				if (num == 9)
				{
					color = Color.blue;
				}
				if (num == 10)
				{
					color = Color.black;
				}
				Mods.ChangeMonkColor(color);
				Mods.flushmanually();
			}
		}

		public static void ChangeMonkColor(Color color)
		{
			if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
			{
				GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", 0, new object[]
				{
					color.r,
					color.g,
					color.b,
					false
				});
			}
		}

		public static void ShibaUserESP()
		{
			if (PhotonNetwork.InRoom)
			{
				Mods.colorKeysPlatformMonke9[0].color = Color.black;
				Mods.colorKeysPlatformMonke9[0].time = 0f;
				Mods.colorKeysPlatformMonke9[1].color = Color.green;
				Mods.colorKeysPlatformMonke9[1].time = 0.5f;
				Mods.colorKeysPlatformMonke9[2].color = Color.black;
				Mods.colorKeysPlatformMonke9[2].time = 1f;
				Mods.colorKeysPlatformMonke2[0].color = Color.black;
				Mods.colorKeysPlatformMonke2[0].time = 0f;
				Mods.colorKeysPlatformMonke2[1].color = Color.red;
				Mods.colorKeysPlatformMonke2[1].time = 0.5f;
				Mods.colorKeysPlatformMonke2[2].color = Color.black;
				Mods.colorKeysPlatformMonke2[2].time = 1f;
				foreach (Player player in PhotonNetwork.PlayerListOthers)
				{
					object obj;
					if (player.CustomProperties.TryGetValue("Dark", out obj) && obj is string)
					{
						if ((string)obj == "true")
						{
							VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
							if (vrrig != null)
							{
								vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
								ColorChanger orAddComponent = GTExt.GetOrAddComponent<ColorChanger>(vrrig.mainSkin.gameObject);
								Gradient gradient = new Gradient();
								orAddComponent.colors = gradient;
								if (vrrig.mainSkin.material.name.Contains("fected") || vrrig.mainSkin.material.name.Contains("rock"))
								{
									gradient.colorKeys = Mods.colorKeysPlatformMonke2;
								}
								else if (!vrrig.mainSkin.material.name.Contains("fected"))
								{
									gradient.colorKeys = Mods.colorKeysPlatformMonke;
								}
							}
						}
					}
					else
					{
						Object.Destroy(GorillaGameManager.instance.FindPlayerVRRig(player).mainSkin.gameObject.GetComponent<ColorChanger>());
					}
				}
			}
			Mods.kowfjwefwjnef = true;
		}

		public static void ModderTracers()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (RigShit.GetPlayerFromRig(vrrig).CustomProperties.ContainsKey("mods") && !vrrig.isMyPlayer)
				{
					if (!vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>())
					{
						vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().startWidth = 0.015f;
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
					}
					if (Mods.tracerscolor == 0)
					{
						if (vrrig.mainSkin.material.name.Contains("fected"))
						{
							vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = Color.red;
						}
						else
						{
							vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = Color.green;
						}
					}
					else
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = vrrig.playerColor;
					}
					vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(0, vrrig.head.rigTarget.gameObject.transform.position);
					if (Mods.tracerspos == 0)
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position);
					}
					else if (Mods.tracerspos == 1)
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.leftHandTransform.position);
					}
					else if (Mods.tracerspos == 2)
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, Player.Instance.headCollider.transform.position + new Vector3(0f, 0.2f, 0f));
					}
					else if (Mods.tracerspos == 3)
					{
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, Player.Instance.headCollider.transform.position + new Vector3(0f, -0.2f, 0f));
					}
				}
			}
			Mods.weufewfjdfjn1111 = true;
		}

		public static void OFFTracers()
		{
			if (Mods.weufewfjdfjn111)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					Object.Destroy(vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>());
				}
				Mods.weufewfjdfjn111 = false;
			}
		}

		public static void OFFModTracers()
		{
			if (Mods.weufewfjdfjn1111)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					Object.Destroy(vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>());
				}
				Mods.weufewfjdfjn1111 = false;
			}
		}

		public static void espoff()
		{
			if (Mods.widhcnkesdj)
			{
				foreach (VRRig vrrig in (VRRig[])Object.FindObjectsOfType(typeof(VRRig)))
				{
					if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
					{
						vrrig.ChangeMaterialLocal(vrrig.currentMatIndex);
					}
				}
				Mods.widhcnkesdj = false;
			}
		}

		public static void OFFLurkerESP()
		{
			if (Mods.widhcnkesdj9)
			{
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab/GhostLurker").GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/URPScryable");
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab/GhostLurker").GetComponent<Renderer>().material.color = new Color(0.6886f, 0.434f, 0.787f, 0.349f);
				Mods.widhcnkesdj9 = false;
			}
		}

		public static void esphuntoff()
		{
			if (Mods.widhcnkesdj1)
			{
				foreach (VRRig vrrig in (VRRig[])Object.FindObjectsOfType(typeof(VRRig)))
				{
					if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
					{
						vrrig.ChangeMaterialLocal(vrrig.currentMatIndex);
					}
				}
				Mods.widhcnkesdj1 = false;
			}
		}

		public static void OFFNoTapCooldown()
		{
			if (Mods.stuiejrf2)
			{
				Mods.stuiejrf2 = false;
				GorillaTagger.Instance.tapCoolDown = 0.1f;
			}
		}

		public static void AntiReportInternal(EventData data)
		{
			if (data.Code == 50)
			{
				object[] array = (object[])data.CustomData;
				if ((string)array[0] == PhotonNetwork.LocalPlayer.UserId)
				{
					PhotonNetwork.Disconnect();
					NotifiLib.SendNotification("<color=red>[AntiReport] </color> Player " + (string)array[3] + " Reported you for " + ((GorillaPlayerLineButton.ButtonType)array[1]).ToString());
				}
			}
		}

		public static void NoTagOnroomJoinFalse()
		{
			if (!Mods.stuiejrf99)
			{
				Mods.stuiejrf99 = true;
				PlayerPrefs.SetString("tutorial", "true");
				Hashtable hashtable = new Hashtable();
				hashtable.Add("didTutorial", true);
				PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
				PlayerPrefs.Save();
			}
		}

		public static void NoTagJoin()
		{
			PlayerPrefs.SetString("tutorial", "false");
			Hashtable hashtable = new Hashtable();
			hashtable.Add("didTutorial", true);
			PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
			PlayerPrefs.Save();
			Mods.stuiejrf99 = false;
		}

		public static void AntiTag()
		{
			if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
			{
				return;
			}
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (vrrig.mainSkin.material.name.Contains("fected") && Vector3.Distance(vrrig.transform.position, GorillaTagger.Instance.offlineVRRig.transform.position) <= 7f)
				{
					GorillaTagger.Instance.offlineVRRig.enabled = false;
					GorillaTagger.Instance.offlineVRRig.transform.position = Player.Instance.transform.position - new Vector3(0f, 7f, 0f);
				}
			}
			GorillaTagger.Instance.offlineVRRig.enabled = true;
		}

		public static void TagAll()
		{
			if (Mods.smth46 < Time.time)
			{
				Mods.smth46 = Time.time + 0.01f;
				Mods.beesPlayer = RigShit.GetRandomPlayer(false);
				VRRig rigFromPlayer = RigShit.GetRigFromPlayer(Mods.beesPlayer);
				if (!rigFromPlayer.mainSkin.material.name.Contains("fected"))
				{
					GorillaTagger.Instance.offlineVRRig.enabled = false;
					GorillaTagger.Instance.offlineVRRig.transform.position = rigFromPlayer.transform.position - new Vector3(0f, 3f, 0f);
					GorillaGameManager.instance.photonView.RPC("ReportTagRPC", 2, new object[]
					{
						Mods.beesPlayer
					});
					GorillaGameManager.instance.photonView.RPC("ReportTagRPC", 2, new object[]
					{
						Mods.beesPlayer
					});
					GorillaGameManager.instance.photonView.RPC("ReportTagRPC", 2, new object[]
					{
						Mods.beesPlayer
					});
					GorillaGameManager.instance.photonView.RPC("ReportTagRPC", 2, new object[]
					{
						Mods.beesPlayer
					});
					GorillaGameManager.instance.photonView.RPC("ReportTagRPC", 2, new object[]
					{
						Mods.beesPlayer
					});
					GorillaGameManager.instance.photonView.RPC("ReportTagRPC", 2, new object[]
					{
						Mods.beesPlayer
					});
					GorillaGameManager.instance.photonView.RPC("ReportTagRPC", 2, new object[]
					{
						Mods.beesPlayer
					});
					GorillaGameManager.instance.photonView.RPC("ReportTagRPC", 2, new object[]
					{
						Mods.beesPlayer
					});
					Mods.flushmanually();
				}
				Mods.baweiofjwf = false;
			}
		}

		public static void NoClip()
		{
			if (WristMenu.triggerDownL && !Mods.a)
			{
				MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].enabled = false;
				}
				Mods.a = true;
			}
			if (!WristMenu.triggerDownL && Mods.a)
			{
				MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].enabled = true;
				}
				Mods.a = false;
			}
		}

		public static void OFFTagAll()
		{
			if (!Mods.baweiofjwf)
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.baweiofjwf = true;
			}
		}

		public static void RBend()
		{
			if (WristMenu.triggerDownR)
			{
				GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
				{
					RigShit.GetOwnVRRig().rightHandTransform.position,
					RigShit.GetOwnVRRig().rightHandTransform.rotation,
					10f,
					100f,
					true,
					true
				});
				Mods.flushmanually();
			}
		}

		public static void LBend()
		{
			if (Mods.smth46 < Time.time)
			{
				Mods.smth46 = Time.time + 0.05f;
				if (WristMenu.triggerDownL)
				{
					GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
					{
						RigShit.GetOwnVRRig().leftHandTransform.position,
						RigShit.GetOwnVRRig().leftHandTransform.rotation,
						10f,
						100f,
						true,
						true
					});
					Mods.flushmanually();
				}
			}
		}

		public static void sizesplash()
		{
			if (Mods.smth46 < Time.time)
			{
				Mods.smth46 = Time.time + 0.05f;
				if (WristMenu.gripDownL && WristMenu.gripDownR)
				{
					Vector3 vector = Vector3.Lerp(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.leftHandTransform.position, 0.5f);
					GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
					{
						vector,
						Quaternion.identity,
						Vector3.Distance(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.leftHandTransform.position),
						Vector3.Distance(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.leftHandTransform.position),
						false,
						true
					});
					Mods.flushmanually();
				}
			}
		}

		public static void SplashAura()
		{
			if (WristMenu.triggerDownL)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					if (Vector3.Distance(vrrig.transform.position, RigShit.GetOwnVRRig().transform.position) <= 9f && vrrig.playerText.text != PhotonNetwork.LocalPlayer.NickName)
					{
						GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
						{
							vrrig.transform.position,
							Random.rotation,
							4f,
							100f,
							true,
							false
						});
						Mods.flushmanually();
					}
				}
			}
		}

		public static void Splash()
		{
			if (WristMenu.triggerDownL && Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.2f;
				GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
				{
					RigShit.GetOwnVRRig().transform.position,
					Random.rotation,
					4f,
					100f,
					true,
					false
				});
				Mods.flushmanually();
			}
		}

		public static void POPANDUNPOP()
		{
			if (PhotonNetwork.IsMasterClient)
			{
				foreach (Player player in PhotonNetwork.PlayerListOthers)
				{
					GorillaBattleManager component = GameObject.Find("Player Objects/GorillaParent/Gorilla Battle Manager(Clone)").GetComponent<GorillaBattleManager>();
					int value = new Random().Next(0, 4);
					component.playerLives[player.ActorNumber] = value;
				}
			}
		}

		public static void LagGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				PhotonView viewFromRig = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>());
				Player player = viewFromRig.Owner;
				if (!WristMenu.triggerDownR)
				{
					Mods.pointer.GetComponent<Renderer>().material.color = Color.white;
					Mods.lockedrig = null;
					return;
				}
				if (Mods.gunLock)
				{
					if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
					{
						Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
					}
					Mods.pointer.transform.position = Mods.lockedrig.transform.position;
					player = RigShit.GetPlayerFromRig(Mods.lockedrig);
				}
				if (Mods.lockedrig != null)
				{
					viewFromRig = RigShit.GetViewFromRig(Mods.lockedrig);
				}
				if (Mods.lockedrig != null)
				{
					viewFromRig = RigShit.GetViewFromRig(Mods.lockedrig);
				}
				if (viewFromRig != null || player != null)
				{
					viewFromRig.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
					viewFromRig.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
					PhotonNetwork.Destroy(viewFromRig);
					PhotonNetwork.Destroy(viewFromRig.gameObject);
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void BREAKAUDIOALL()
		{
			if (Mods.balll2111 < Time.time)
			{
				Mods.balll2111 = Time.time + 0.01f;
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 1, new object[]
				{
					94,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		public static void BREAKAUDIOGUN()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Player player;
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (!WristMenu.triggerDownR)
				{
					Mods.lockedrig = null;
					Mods.pointer.GetComponent<Renderer>().material.color = Color.white;
					return;
				}
				if (Mods.lockedrig != null)
				{
					player = RigShit.GetPlayerFromRig(Mods.lockedrig);
				}
				else
				{
					player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				}
				if (player != null && Mods.balll2111 < Time.time)
				{
					Mods.balll2111 = Time.time + 0.01f;
					GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", player, new object[]
					{
						94,
						true,
						999f
					});
					Mods.flushmanually();
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void GunLock()
		{
			Mods.gunLock = true;
		}

		public static void ChangeLayout()
		{
			Mods.rattatuoie++;
			if (Mods.rattatuoie == 0)
			{
				WristMenu.settingsbuttons[4].buttonText = "Menu Layout: ShibaGT";
				File.WriteAllText("GoldPrefs\\goldlayout.txt", "shibagt");
			}
			if (Mods.rattatuoie == 1)
			{
				WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Side";
				File.WriteAllText("GoldPrefs\\goldlayout.txt", "side");
			}
			if (Mods.rattatuoie == 2)
			{
				WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Triggers";
				File.WriteAllText("GoldPrefs\\goldlayout.txt", "triggers");
			}
			if (Mods.rattatuoie == 3)
			{
				Mods.rattatuoie = 0;
				WristMenu.settingsbuttons[4].buttonText = "Menu Layout: ShibaGT";
				File.WriteAllText("GoldPrefs\\goldlayout.txt", "shibagt");
			}
			WristMenu.settingsbuttons[4].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void Change1Theme(bool loading)
		{
			if (!loading)
			{
				Mods.fucking1++;
			}
			if (Mods.fucking1 == 0)
			{
				WristMenu.settingsbuttons[6].buttonText = "Menu Theme First Color: Black";
				Mods.firstcolor = Color.black;
			}
			if (Mods.fucking1 == 1)
			{
				WristMenu.settingsbuttons[6].buttonText = "Menu Theme First Color: Blue";
				Mods.firstcolor = Color.blue;
			}
			if (Mods.fucking1 == 2)
			{
				WristMenu.settingsbuttons[6].buttonText = "Menu Theme First Color: Green";
				Mods.firstcolor = Color.green;
			}
			if (Mods.fucking1 == 3)
			{
				WristMenu.settingsbuttons[6].buttonText = "Menu Theme First Color: White";
				Mods.firstcolor = Color.white;
			}
			if (Mods.fucking1 == 4)
			{
				WristMenu.settingsbuttons[6].buttonText = "Menu Theme First Color: Magenta";
				Mods.firstcolor = Color.magenta;
			}
			if (Mods.fucking1 == 5)
			{
				WristMenu.settingsbuttons[6].buttonText = "Menu Theme First Color: Cyan";
				Mods.firstcolor = Color.cyan;
			}
			if (Mods.fucking1 == 6)
			{
				WristMenu.settingsbuttons[6].buttonText = "Menu Theme First Color: Gray";
				Mods.firstcolor = Color.gray;
			}
			if (Mods.fucking1 == 7)
			{
				WristMenu.settingsbuttons[6].buttonText = "Menu Theme First Color: Red";
				Mods.firstcolor = Color.red;
			}
			if (Mods.fucking1 == 8)
			{
				Mods.fucking1 = 0;
				WristMenu.settingsbuttons[6].buttonText = "Menu Theme First Color: Black";
				Mods.firstcolor = Color.black;
			}
			WristMenu.settingsbuttons[6].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void changeguntype(bool loading)
		{
			if (!loading)
			{
				Mods.guntype++;
			}
			if (Mods.guntype == 0)
			{
				WristMenu.settingsbuttons[27].buttonText = "Gun Type: Normal";
			}
			if (Mods.guntype == 1)
			{
				WristMenu.settingsbuttons[27].buttonText = "Gun Type: Line";
			}
			if (Mods.guntype == 2)
			{
				WristMenu.settingsbuttons[27].buttonText = "Gun Type: Normal";
				Mods.guntype = 0;
			}
			WristMenu.settingsbuttons[27].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void changeprojcolor(bool loading)
		{
			if (!loading)
			{
				Mods.colorproj++;
			}
			if (Mods.colorproj == 0)
			{
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Black";
				Mods.projcolor = Color.black;
			}
			if (Mods.colorproj == 1)
			{
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Blue";
				Mods.projcolor = Color.blue;
			}
			if (Mods.colorproj == 2)
			{
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Green";
				Mods.projcolor = Color.green;
			}
			if (Mods.colorproj == 3)
			{
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: White";
				Mods.projcolor = Color.white;
			}
			if (Mods.colorproj == 4)
			{
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Magenta";
				Mods.projcolor = Color.magenta;
			}
			if (Mods.colorproj == 5)
			{
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Cyan";
				Mods.projcolor = Color.cyan;
			}
			if (Mods.colorproj == 6)
			{
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Gray";
				Mods.projcolor = Color.gray;
			}
			if (Mods.colorproj == 7)
			{
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Red";
				Mods.projcolor = Color.red;
			}
			if (Mods.colorproj == 8)
			{
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Yellow";
				Mods.projcolor = Color.yellow;
			}
			if (Mods.colorproj == 9)
			{
				Mods.colorproj = 0;
				WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Black";
				Mods.projcolor = Color.black;
			}
			WristMenu.settingsbuttons[25].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void sticky()
		{
			Mods.stickyplatforms = true;
		}

		public static void offsticky()
		{
			Mods.stickyplatforms = false;
		}

		public static void makecycle()
		{
			Mods.cycle = true;
		}

		public static void disablecycle()
		{
			Mods.cycle = false;
		}

		public static void bothhanded()
		{
			Mods.bothhands = true;
		}

		public static void offbothhanded()
		{
			Mods.bothhands = false;
		}

		public static void fpc()
		{
			Mods.fpcc = true;
			if (GameObject.Find("Third Person Camera") != null)
			{
				Mods.funn = GameObject.Find("Third Person Camera");
				Mods.funn.SetActive(false);
			}
			if (GameObject.Find("CameraTablet(Clone)") != null)
			{
				Mods.funn = GameObject.Find("CameraTablet(Clone)");
				Mods.funn.SetActive(false);
			}
		}

		public static void fpcoff()
		{
			Mods.fpcc = false;
			if (Mods.funn != null)
			{
				Mods.funn.SetActive(true);
				Mods.funn = null;
			}
		}

		public static void notpcrash()
		{
			Mods.crashtp = false;
		}

		public static void notnotprcrahs()
		{
			Mods.crashtp = true;
		}

		public static void offleaves()
		{
			if (!Mods.erihu)
			{
				Mods.erihu = true;
				foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
				{
					if (gameObject.activeSelf && gameObject.name.Contains("smallleaves"))
					{
						gameObject.SetActive(false);
						Mods.leaves.Add(gameObject);
					}
				}
			}
		}

		public static void offoffleaves()
		{
			if (Mods.erihu)
			{
				Mods.erihu = false;
				foreach (GameObject gameObject in Mods.leaves)
				{
					gameObject.SetActive(true);
				}
				Mods.leaves.Clear();
			}
		}

		public static void ChangeTime(bool loading)
		{
			if (!loading)
			{
				Mods.fucking2++;
			}
			if (Mods.fucking2 == 0)
			{
				WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Untouched";
			}
			if (Mods.fucking2 == 1)
			{
				WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Day";
				BetterDayNightManager.instance.SetTimeOfDay(1);
			}
			if (Mods.fucking2 == 2)
			{
				WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Dawn";
				BetterDayNightManager.instance.SetTimeOfDay(6);
			}
			if (Mods.fucking2 == 3)
			{
				WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Night";
				BetterDayNightManager.instance.SetTimeOfDay(0);
			}
			if (Mods.fucking2 == 4)
			{
				Mods.fucking2 = 0;
				WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Untouched";
			}
			WristMenu.settingsbuttons[11].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void Change2Theme(bool loading)
		{
			if (!loading)
			{
				Mods.fucking++;
			}
			if (Mods.fucking == 0)
			{
				WristMenu.settingsbuttons[7].buttonText = "Menu Theme Second Color: Yellow";
				Mods.secondcolor = Color.yellow;
			}
			if (Mods.fucking == 1)
			{
				WristMenu.settingsbuttons[7].buttonText = "Menu Theme Second Color: Blue";
				Mods.secondcolor = Color.blue;
			}
			if (Mods.fucking == 2)
			{
				WristMenu.settingsbuttons[7].buttonText = "Menu Theme Second Color: Green";
				Mods.secondcolor = Color.green;
			}
			if (Mods.fucking == 3)
			{
				WristMenu.settingsbuttons[7].buttonText = "Menu Theme Second Color: White";
				Mods.secondcolor = Color.white;
			}
			if (Mods.fucking == 4)
			{
				WristMenu.settingsbuttons[7].buttonText = "Menu Theme Second Color: Magenta";
				Mods.secondcolor = Color.magenta;
			}
			if (Mods.fucking == 5)
			{
				WristMenu.settingsbuttons[7].buttonText = "Menu Theme Second Color: Cyan";
				Mods.secondcolor = Color.cyan;
			}
			if (Mods.fucking == 6)
			{
				WristMenu.settingsbuttons[7].buttonText = "Menu Theme Second Color: Gray";
				Mods.secondcolor = Color.gray;
			}
			if (Mods.fucking == 7)
			{
				WristMenu.settingsbuttons[7].buttonText = "Menu Theme Second Color: Red";
				Mods.secondcolor = Color.red;
			}
			if (Mods.fucking == 8)
			{
				Mods.fucking = 0;
				WristMenu.settingsbuttons[7].buttonText = "Menu Theme Second Color: Yellow";
				Mods.secondcolor = Color.yellow;
			}
			WristMenu.settingsbuttons[7].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void ChangeProj(bool loading)
		{
			if (!loading)
			{
				Mods.projectile++;
			}
			if (Mods.projectile == 0)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Slingshot";
				Mods.projectilehash = -820530352;
			}
			if (Mods.projectile == 1)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Deadshot";
				Mods.projectilehash = 693334698;
			}
			if (Mods.projectile == 2)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Cloud";
				Mods.projectilehash = 1511318966;
			}
			if (Mods.projectile == 3)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Snowball";
				Mods.projectilehash = -675036877;
			}
			if (Mods.projectile == 4)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Cupid";
				Mods.projectilehash = 825718363;
			}
			if (Mods.projectile == 5)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Ice";
				Mods.projectilehash = -1671677000;
			}
			if (Mods.projectile == 6)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Elf";
				Mods.projectilehash = 1705139863;
			}
			if (Mods.projectile == 7)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Water Balloon";
				Mods.projectilehash = -1674517839;
			}
			if (Mods.projectile == 8)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Rock";
				Mods.projectilehash = -622368518;
			}
			if (Mods.projectile == 9)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Pepper";
				Mods.projectilehash = -1280105888;
			}
			if (Mods.projectile == 10)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Spider";
				Mods.projectilehash = -790645151;
			}
			if (Mods.projectile == 11)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Candy Cane";
				Mods.projectilehash = 2061412059;
			}
			if (Mods.projectile == 12)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Coal";
				Mods.projectilehash = -1433634409;
			}
			if (Mods.projectile == 13)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Roll Gift";
				Mods.projectilehash = -1433633837;
			}
			if (Mods.projectile == 14)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Round Gift";
				Mods.projectilehash = -160604350;
			}
			if (Mods.projectile == 15)
			{
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Square Gift";
				Mods.projectilehash = -666337545;
			}
			if (Mods.projectile == 16)
			{
				Mods.projectile = 0;
				WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Slingshot";
				Mods.projectilehash = -820530352;
			}
			WristMenu.settingsbuttons[8].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void cycle1(bool loading)
		{
			if (!loading)
			{
				Mods.projectilecycle1++;
			}
			if (Mods.projectilecycle1 == 0)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Slingshot";
				Mods.projectilehashc1 = -820530352;
			}
			if (Mods.projectilecycle1 == 1)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Deadshot";
				Mods.projectilehashc1 = 693334698;
			}
			if (Mods.projectilecycle1 == 2)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Cloud";
				Mods.projectilehashc1 = 1511318966;
			}
			if (Mods.projectilecycle1 == 3)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Snowball";
				Mods.projectilehashc1 = -675036877;
			}
			if (Mods.projectilecycle1 == 4)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Cupid";
				Mods.projectilehashc1 = 825718363;
			}
			if (Mods.projectilecycle1 == 5)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Ice";
				Mods.projectilehashc1 = -1671677000;
			}
			if (Mods.projectilecycle1 == 6)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Elf";
				Mods.projectilehashc1 = 1705139863;
			}
			if (Mods.projectilecycle1 == 7)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Water Balloon";
				Mods.projectilehashc1 = -1674517839;
			}
			if (Mods.projectilecycle1 == 8)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Rock";
				Mods.projectilehashc1 = -622368518;
			}
			if (Mods.projectilecycle1 == 9)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Pepper";
				Mods.projectilehashc1 = -1280105888;
			}
			if (Mods.projectilecycle1 == 10)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Spider";
				Mods.projectilehashc1 = -790645151;
			}
			if (Mods.projectilecycle1 == 11)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Candy Cane";
				Mods.projectilehashc1 = 2061412059;
			}
			if (Mods.projectilecycle1 == 12)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Coal";
				Mods.projectilehashc1 = -1433634409;
			}
			if (Mods.projectilecycle1 == 13)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Roll Gift";
				Mods.projectilehashc1 = -1433633837;
			}
			if (Mods.projectilecycle1 == 14)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Round Gift";
				Mods.projectilehashc1 = -160604350;
			}
			if (Mods.projectilecycle1 == 15)
			{
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Square Gift";
				Mods.projectilehashc1 = -666337545;
			}
			if (Mods.projectilecycle1 == 16)
			{
				Mods.projectilecycle1 = 0;
				WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Slingshot";
				Mods.projectilehashc1 = -820530352;
			}
			WristMenu.settingsbuttons[21].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void cycle2(bool loading)
		{
			if (!loading)
			{
				Mods.projectilecycle2++;
			}
			if (Mods.projectilecycle2 == 0)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Slingshot";
				Mods.projectilehashc2 = -820530352;
			}
			if (Mods.projectilecycle2 == 1)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Deadshot";
				Mods.projectilehashc2 = 693334698;
			}
			if (Mods.projectilecycle2 == 2)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Cloud";
				Mods.projectilehashc2 = 1511318966;
			}
			if (Mods.projectilecycle2 == 3)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Snowball";
				Mods.projectilehashc2 = -675036877;
			}
			if (Mods.projectilecycle2 == 4)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Cupid";
				Mods.projectilehashc2 = 825718363;
			}
			if (Mods.projectilecycle2 == 5)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Ice";
				Mods.projectilehashc2 = -1671677000;
			}
			if (Mods.projectilecycle2 == 6)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Elf";
				Mods.projectilehashc2 = 1705139863;
			}
			if (Mods.projectilecycle2 == 7)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Water Balloon";
				Mods.projectilehashc2 = -1674517839;
			}
			if (Mods.projectilecycle2 == 8)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Rock";
				Mods.projectilehashc2 = -622368518;
			}
			if (Mods.projectilecycle2 == 9)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Pepper";
				Mods.projectilehashc2 = -1280105888;
			}
			if (Mods.projectilecycle2 == 10)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Spider";
				Mods.projectilehashc2 = -790645151;
			}
			if (Mods.projectilecycle2 == 11)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Candy Cane";
				Mods.projectilehashc2 = 2061412059;
			}
			if (Mods.projectilecycle2 == 12)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Coal";
				Mods.projectilehashc2 = -1433634409;
			}
			if (Mods.projectilecycle2 == 13)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Roll Gift";
				Mods.projectilehashc2 = -1433633837;
			}
			if (Mods.projectilecycle2 == 14)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Round Gift";
				Mods.projectilehashc2 = -160604350;
			}
			if (Mods.projectilecycle2 == 15)
			{
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Square Gift";
				Mods.projectilehashc2 = -666337545;
			}
			if (Mods.projectilecycle2 == 16)
			{
				Mods.projectilecycle2 = 0;
				WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Slingshot";
				Mods.projectilehashc2 = -820530352;
			}
			WristMenu.settingsbuttons[22].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void cycle3(bool loading)
		{
			if (!loading)
			{
				Mods.projectilecycle3++;
			}
			if (Mods.projectilecycle3 == 0)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Slingshot";
				Mods.projectilehashc3 = -820530352;
			}
			if (Mods.projectilecycle3 == 1)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Deadshot";
				Mods.projectilehashc3 = 693334698;
			}
			if (Mods.projectilecycle3 == 2)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Cloud";
				Mods.projectilehashc3 = 1511318966;
			}
			if (Mods.projectilecycle3 == 3)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Snowball";
				Mods.projectilehashc3 = -675036877;
			}
			if (Mods.projectilecycle3 == 4)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Cupid";
				Mods.projectilehashc3 = 825718363;
			}
			if (Mods.projectilecycle3 == 5)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Ice";
				Mods.projectilehashc3 = -1671677000;
			}
			if (Mods.projectilecycle3 == 6)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Elf";
				Mods.projectilehashc3 = 1705139863;
			}
			if (Mods.projectilecycle3 == 7)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Water Balloon";
				Mods.projectilehashc3 = -1674517839;
			}
			if (Mods.projectilecycle3 == 8)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Rock";
				Mods.projectilehashc3 = -623368518;
			}
			if (Mods.projectilecycle3 == 9)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Pepper";
				Mods.projectilehashc3 = -1280105888;
			}
			if (Mods.projectilecycle3 == 10)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Spider";
				Mods.projectilehashc3 = -790645151;
			}
			if (Mods.projectilecycle3 == 11)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Candy Cane";
				Mods.projectilehashc3 = 2061412059;
			}
			if (Mods.projectilecycle3 == 12)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Coal";
				Mods.projectilehashc3 = -1433634409;
			}
			if (Mods.projectilecycle3 == 13)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Roll Gift";
				Mods.projectilehashc3 = -1433633837;
			}
			if (Mods.projectilecycle3 == 14)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Round Gift";
				Mods.projectilehashc3 = -160604350;
			}
			if (Mods.projectilecycle3 == 15)
			{
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Square Gift";
				Mods.projectilehashc3 = -666337545;
			}
			if (Mods.projectilecycle3 == 16)
			{
				Mods.projectilecycle3 = 0;
				WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Slingshot";
				Mods.projectilehashc3 = -820530352;
			}
			WristMenu.settingsbuttons[23].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void setmaster()
		{
			PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
		}

		public static void fasttrain()
		{
			Mods.fasttrainbool = true;
			GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
			PhotonView component = gameObject.GetComponent<PhotonView>();
			TraverseSpline component2 = gameObject.GetComponent<TraverseSpline>();
			component.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			component.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			component2.duration = 4f;
		}

		public static void fasttrainoff()
		{
			if (Mods.fasttrainbool)
			{
				Mods.fasttrainbool = false;
				GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
				PhotonView component = gameObject.GetComponent<PhotonView>();
				TraverseSpline component2 = gameObject.GetComponent<TraverseSpline>();
				component.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				component.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				component2.duration = 30f;
			}
		}

		public static void slowtrain()
		{
			Mods.slowtrainbool = true;
			GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
			PhotonView component = gameObject.GetComponent<PhotonView>();
			TraverseSpline component2 = gameObject.GetComponent<TraverseSpline>();
			component.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			component.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			component2.duration = 120f;
		}

		public static void slowtrainoff()
		{
			if (Mods.slowtrainbool)
			{
				Mods.slowtrainbool = false;
				GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
				PhotonView component = gameObject.GetComponent<PhotonView>();
				TraverseSpline component2 = gameObject.GetComponent<TraverseSpline>();
				component.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				component.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				component2.duration = 30f;
			}
		}

		public static void freezetrain()
		{
			Mods.freezetrainbool = true;
			GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
			PhotonView component = gameObject.GetComponent<PhotonView>();
			TraverseSpline component2 = gameObject.GetComponent<TraverseSpline>();
			component.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			component.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			component2.duration = float.MaxValue;
		}

		public static void freezetrainoff()
		{
			if (Mods.freezetrainbool)
			{
				Mods.freezetrainbool = false;
				GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
				PhotonView component = gameObject.GetComponent<PhotonView>();
				TraverseSpline component2 = gameObject.GetComponent<TraverseSpline>();
				component.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				component.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				component2.duration = 30f;
			}
		}

		public static void kickstump()
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("gameMode", null);
			PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
		}

		public static void cycle4(bool loading)
		{
			if (!loading)
			{
				Mods.projectilecycle4++;
			}
			if (Mods.projectilecycle4 == 0)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Slingshot";
				Mods.projectilehashc4 = -820530352;
			}
			if (Mods.projectilecycle4 == 1)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Deadshot";
				Mods.projectilehashc4 = 693334698;
			}
			if (Mods.projectilecycle4 == 2)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Cloud";
				Mods.projectilehashc4 = 1511318966;
			}
			if (Mods.projectilecycle4 == 3)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Snowball";
				Mods.projectilehashc4 = -675036877;
			}
			if (Mods.projectilecycle4 == 4)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Cupid";
				Mods.projectilehashc4 = 825718363;
			}
			if (Mods.projectilecycle4 == 5)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Ice";
				Mods.projectilehashc4 = -1671677000;
			}
			if (Mods.projectilecycle4 == 6)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Elf";
				Mods.projectilehashc4 = 1705139863;
			}
			if (Mods.projectilecycle4 == 7)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Water Balloon";
				Mods.projectilehashc4 = -1674517839;
			}
			if (Mods.projectilecycle4 == 8)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Rock";
				Mods.projectilehashc4 = -624368518;
			}
			if (Mods.projectilecycle4 == 9)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Pepper";
				Mods.projectilehashc4 = -1280105888;
			}
			if (Mods.projectilecycle4 == 10)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Spider";
				Mods.projectilehashc4 = -790645151;
			}
			if (Mods.projectilecycle4 == 11)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Candy Cane";
				Mods.projectilehashc4 = 2061412059;
			}
			if (Mods.projectilecycle4 == 12)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Coal";
				Mods.projectilehashc4 = -1433634409;
			}
			if (Mods.projectilecycle4 == 13)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Roll Gift";
				Mods.projectilehashc4 = -1433633837;
			}
			if (Mods.projectilecycle4 == 14)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Round Gift";
				Mods.projectilehashc4 = -160604350;
			}
			if (Mods.projectilecycle4 == 15)
			{
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Square Gift";
				Mods.projectilehashc4 = -666337545;
			}
			if (Mods.projectilecycle4 == 16)
			{
				Mods.projectilecycle4 = 0;
				WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Slingshot";
				Mods.projectilehashc4 = -820530352;
			}
			WristMenu.settingsbuttons[24].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void offrainbow()
		{
			Mods.rainboww = false;
		}

		public static void rainbow()
		{
			if (!Mods.rainboww)
			{
				Debug.Log("making funny 1");
				if (Mods.erm == null)
				{
					Mods.erm = GameObject.CreatePrimitive(3);
				}
				ColorChanger colorChanger = Mods.erm.AddComponent<ColorChanger>();
				Mods.ihate[0].color = Color.yellow;
				Mods.ihate[0].time = 0f;
				Mods.ihate[1].color = Color.red;
				Mods.ihate[1].time = 0.2f;
				Mods.ihate[2].color = Color.magenta;
				Mods.ihate[2].time = 0.4f;
				Mods.ihate[3].color = Color.blue;
				Mods.ihate[3].time = 0.6f;
				Mods.ihate[4].color = Color.green;
				Mods.ihate[4].time = 0.8f;
				Mods.ihate[5].color = Color.yellow;
				Mods.ihate[5].time = 1f;
				colorChanger.colors = new Gradient
				{
					colorKeys = Mods.ihate
				};
				Debug.Log("making funny 2");
				colorChanger.Start();
				Debug.Log("making funny 3");
				Mods.rainboww = true;
			}
		}

		public static void ChangeTrail(bool loading)
		{
			if (!loading)
			{
				Mods.projectiletrail++;
			}
			if (Mods.projectiletrail == 0)
			{
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Slingshot";
				Mods.projectiletrailhash = 1432124712;
			}
			if (Mods.projectiletrail == 1)
			{
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Deadshot";
				Mods.projectiletrailhash = 163790326;
			}
			if (Mods.projectiletrail == 2)
			{
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Cloud";
				Mods.projectiletrailhash = 16948542;
			}
			if (Mods.projectiletrail == 3)
			{
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Cupid";
				Mods.projectiletrailhash = 1848916225;
			}
			if (Mods.projectiletrail == 4)
			{
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Ice";
				Mods.projectiletrailhash = -1277271056;
			}
			if (Mods.projectiletrail == 5)
			{
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Elf";
				Mods.projectiletrailhash = -67783235;
			}
			if (Mods.projectiletrail == 6)
			{
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Pepper";
				Mods.projectiletrailhash = -748577108;
			}
			if (Mods.projectiletrail == 7)
			{
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Spider";
				Mods.projectiletrailhash = -1232128945;
			}
			if (Mods.projectiletrail == 8)
			{
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Nothing";
				Mods.projectiletrailhash = -1;
			}
			if (Mods.projectiletrail == 9)
			{
				Mods.projectiletrail = 0;
				WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Slingshot";
				Mods.projectiletrailhash = 1432124712;
			}
			WristMenu.settingsbuttons[9].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void ChangePlatforms(bool loading)
		{
			if (!loading)
			{
				Mods.platformstype++;
			}
			if (Mods.platformstype == 0)
			{
				WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Normal";
				Mods.invisplat = false;
			}
			if (Mods.platformstype == 1)
			{
				WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Invis";
				Mods.invisplat = true;
			}
			if (Mods.platformstype == 2)
			{
				WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Trigger Normal";
				Mods.triggerplat = true;
				Mods.invisplat = false;
			}
			if (Mods.platformstype == 3)
			{
				WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Trigger Invis";
				Mods.triggerplat = true;
				Mods.invisplat = true;
			}
			if (Mods.platformstype == 4)
			{
				WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Normal Trigger Toggle";
				Mods.invisplat = false;
				Mods.triggerplat = false;
				Mods.toggleplat = true;
			}
			if (Mods.platformstype == 5)
			{
				WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Invis Trigger Toggle";
				Mods.invisplat = true;
				Mods.triggerplat = false;
				Mods.toggleplat = true;
			}
			if (Mods.platformstype == 6)
			{
				Mods.platformstype = 0;
				WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Normal";
				Mods.invisplat = false;
				Mods.triggerplat = false;
				Mods.toggleplat = false;
			}
			WristMenu.settingsbuttons[14].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void ChangeESP(bool loading)
		{
			if (!loading)
			{
				Mods.espcolor++;
			}
			if (Mods.espcolor == 0)
			{
				WristMenu.settingsbuttons[16].buttonText = "ESP Color: Tagged";
			}
			if (Mods.espcolor == 1)
			{
				WristMenu.settingsbuttons[16].buttonText = "ESP Color: Color Code";
			}
			if (Mods.espcolor == 2)
			{
				Mods.espcolor = 0;
				WristMenu.settingsbuttons[16].buttonText = "ESP Color: Tagged";
			}
			WristMenu.settingsbuttons[16].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void ChangeTracersColor(bool loading)
		{
			if (!loading)
			{
				Mods.tracerscolor++;
			}
			if (Mods.tracerscolor == 0)
			{
				WristMenu.settingsbuttons[17].buttonText = "Tracers Color: Tagged";
			}
			if (Mods.tracerscolor == 1)
			{
				WristMenu.settingsbuttons[17].buttonText = "Tracers Color: Color Code";
			}
			if (Mods.tracerscolor == 2)
			{
				Mods.tracerscolor = 0;
				WristMenu.settingsbuttons[17].buttonText = "Tracers Color: Tagged";
			}
			WristMenu.settingsbuttons[17].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void ChangeTracersPos(bool loading)
		{
			if (!loading)
			{
				Mods.tracerspos++;
			}
			if (Mods.tracerspos == 0)
			{
				WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Right Hand";
			}
			if (Mods.tracerspos == 1)
			{
				WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Left Hand";
			}
			if (Mods.tracerspos == 2)
			{
				WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Head";
			}
			if (Mods.tracerspos == 3)
			{
				WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Body";
			}
			if (Mods.tracerspos == 4)
			{
				Mods.tracerspos = 0;
				WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Right Hand";
			}
			WristMenu.settingsbuttons[18].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void ChangeSpeed(bool loading)
		{
			if (!loading)
			{
				Mods.speed++;
			}
			if (Mods.speed == 0)
			{
				WristMenu.settingsbuttons[19].buttonText = "Speed Boost: Mosa";
			}
			if (Mods.speed == 1)
			{
				WristMenu.settingsbuttons[19].buttonText = "Speed Boost: Super";
			}
			if (Mods.speed == 2)
			{
				WristMenu.settingsbuttons[19].buttonText = "Speed Boost: Fucking Insane";
			}
			if (Mods.speed == 3)
			{
				Mods.speed = 0;
				WristMenu.settingsbuttons[19].buttonText = "Speed Boost: Mosa";
			}
			WristMenu.settingsbuttons[19].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		public static void UNGodModLock()
		{
			Mods.gunLock = false;
		}

		public static void OnNotifs()
		{
			Mods.notifs = true;
		}

		public static void OffNotifs()
		{
			Mods.notifs = false;
		}

		public static void Save()
		{
			Mods.GetButtonSettings("Save Preferences").enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
			List<string> list = new List<string>();
			foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
			{
				bool? enabled = buttonInfo.enabled;
				bool flag = true;
				if (enabled.GetValueOrDefault() == flag & enabled != null)
				{
					list.Add(buttonInfo.buttonText);
				}
			}
			Directory.CreateDirectory("GoldPrefs");
			File.WriteAllText("GoldPrefs\\goldSavedProj.txt", Mods.projectile.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedTrail.txt", Mods.projectiletrail.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedFirstColor.txt", Mods.fucking1.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedSecondColor.txt", Mods.fucking.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedTime.txt", Mods.fucking2.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedPlatforms.txt", Mods.platformstype.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedEsp.txt", Mods.espcolor.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedTracersC.txt", Mods.tracerscolor.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedTracersP.txt", Mods.tracerspos.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedCycle1.txt", Mods.projectilecycle1.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedCycle2.txt", Mods.projectilecycle2.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedCycle3.txt", Mods.projectilecycle3.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedCycle4.txt", Mods.projectilecycle4.ToString());
			File.WriteAllText("GoldPrefs\\goldSavedProjColor.txt", Mods.colorproj.ToString());
			File.WriteAllLines("GoldPrefs\\goldSavedPrefs.txt", list);
		}

		public static void SaveOnButtons()
		{
			Mods.GetButton("Save Enabled Buttons").enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
			List<string> list = new List<string>();
			foreach (ButtonInfo buttonInfo in WristMenu.buttons)
			{
				bool? enabled = buttonInfo.enabled;
				bool flag = true;
				if (enabled.GetValueOrDefault() == flag & enabled != null)
				{
					list.Add(buttonInfo.buttonText);
				}
			}
			Directory.CreateDirectory("GoldPrefs");
			File.WriteAllLines("GoldPrefs\\goldSavedButtonsPref.txt", list);
		}

		public static void LoadOnButtons()
		{
			string[] array = File.ReadAllLines("GoldPrefs\\goldSavedButtonsPref.txt");
			for (int i = 0; i < array.Length; i++)
			{
				Mods.GetButton(array[i]).enabled = new bool?(true);
			}
		}

		public static void Load()
		{
			string[] array = File.ReadAllLines("GoldPrefs\\goldSavedPrefs.txt");
			for (int i = 0; i < array.Length; i++)
			{
				Mods.GetButtonSettings(array[i]).enabled = new bool?(true);
			}
			Debug.Log(PhotonNetwork.LocalPlayer.UserId);
			Mods.CheckSettings();
		}

		public static void CheckSettings()
		{
			if (File.Exists("GoldPrefs\\goldlayout.txt"))
			{
				if (File.ReadAllText("GoldPrefs\\goldlayout.txt") == "shibagt")
				{
					Mods.rattatuoie = 0;
					WristMenu.settingsbuttons[4].buttonText = "Menu Layout: ShibaGT";
				}
				else if (File.ReadAllText("GoldPrefs\\goldlayout.txt") == "side")
				{
					Mods.rattatuoie = 1;
					WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Side";
				}
				else if (File.ReadAllText("GoldPrefs\\goldlayout.txt") == "triggers")
				{
					Mods.rattatuoie = 2;
					WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Triggers";
				}
			}
			foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
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
			if (File.Exists("GoldPrefs\\goldSavedProj.txt"))
			{
				Mods.projectile = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedProj.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedTrail.txt"))
			{
				Mods.projectiletrail = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedTrail.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedFirstColor.txt"))
			{
				Mods.fucking1 = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedFirstColor.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedSecondColor.txt"))
			{
				Mods.fucking = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedSecondColor.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedTime.txt"))
			{
				Mods.fucking2 = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedTime.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedPlatforms.txt"))
			{
				Mods.platformstype = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedPlatforms.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedEsp.txt"))
			{
				Mods.espcolor = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedEsp.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedTracersC.txt"))
			{
				Mods.tracerscolor = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedTracersC.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedTracersP.txt"))
			{
				Mods.tracerspos = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedTracersP.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedCycle1.txt"))
			{
				Mods.projectilecycle1 = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedCycle1.txt"));
				Mods.projectilecycle2 = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedCycle2.txt"));
				Mods.projectilecycle3 = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedCycle3.txt"));
				Mods.projectilecycle4 = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedCycle4.txt"));
			}
			if (File.Exists("GoldPrefs\\goldSavedProjColor.txt"))
			{
				Mods.colorproj = (int)Convert.ToInt16(File.ReadAllText("GoldPrefs\\goldSavedProjColor.txt"));
			}
			Mods.ChangeProj(true);
			Mods.ChangeTrail(true);
			Mods.Change1Theme(true);
			Mods.Change2Theme(true);
			Mods.ChangeTime(true);
			Mods.ChangeESP(true);
			Mods.ChangeTracersColor(true);
			Mods.ChangeTracersPos(true);
			Mods.cycle1(true);
			Mods.cycle2(true);
			Mods.cycle3(true);
			Mods.cycle4(true);
			Mods.changeprojcolor(true);
		}

		public static void TAGSPAM()
		{
			if (Time.time > Mods.balll2111 + 0.08f)
			{
				Mods.balll2111 = Time.time;
				PhotonView.Get(GorillaGameManager.instance).RPC("ReportContactWithLavaRPC", 2, Array.Empty<object>());
			}
		}

		public static void KickDeps(Player p)
		{
			Vector3 vector = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, -3f, 0f);
			Vector3 vector2;
			vector2..ctor(0f, 0f, 0f);
			int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
			GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", p, new object[]
			{
				vector,
				vector2,
				-1674517839,
				163790326,
				false,
				num,
				false,
				0f,
				0f,
				0f,
				1f
			});
			PhotonNetwork.SendAllOutgoingCommands();
		}

		public static void RpcPatcher(VRRig rig)
		{
			Mods.CleanActorAndRPCBuffers(GorillaTagger.Instance.myVRRig);
		}

		public static void CleanActorAndRPCBuffers(PhotonView photonView)
		{
			PhotonNetwork.OpCleanActorRpcBuffer(photonView.Owner.ActorNumber);
			PhotonNetwork.OpCleanRpcBuffer(photonView);
		}

		public static void PunchMod()
		{
			int num = -1;
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (vrrig != GorillaTagger.Instance.offlineVRRig)
				{
					num++;
					Vector3 position = vrrig.rightHandTransform.position;
					Vector3 position2 = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
					if ((double)Vector3.Distance(position, position2) < 0.25)
					{
						Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.rightHandTransform.position - Mods.lastRight[num]) * 10f;
					}
					Mods.lastRight[num] = vrrig.rightHandTransform.position;
					if ((double)Vector3.Distance(vrrig.leftHandTransform.position, position2) < 0.25)
					{
						Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.rightHandTransform.position - Mods.lastLeft[num]) * 10f;
					}
					Mods.lastLeft[num] = vrrig.leftHandTransform.position;
				}
			}
		}

		public static void RaiseRpcEventse(Player p)
		{
			int actorNumber = p.ActorNumber;
			int[] targetActors = new int[]
			{
				p.ActorNumber
			};
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions
			{
				TargetActors = targetActors
			};
			PhotonNetwork.NetworkingClient.OpRaiseEvent(207, actorNumber, raiseEventOptions, SendOptions.SendReliable);
		}

		public static void banall()
		{
			if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId) && Time.time > Mods.balll2111 + 0.08f && PhotonNetwork.InRoom)
			{
				Mods.balll2111 = Time.time;
				Mods.updateTimer += Time.deltaTime;
				if (Mods.RandomColor)
				{
					if ((double)Time.time > (double)Mods.timer)
					{
						Mods.color = Random.ColorHSV(0f, 1f, Mods.GlowAmount, Mods.GlowAmount, Mods.GlowAmount, Mods.GlowAmount);
						Mods.timer = Time.time + Mods.CycleSpeed;
					}
				}
				else
				{
					if ((double)Mods.hue >= 1.0)
					{
						Mods.hue = 0f;
					}
					Mods.hue += Mods.CycleSpeed;
					Mods.color = Color.HSVToRGB(Mods.hue, 1f * Mods.GlowAmount, 1f * Mods.GlowAmount);
				}
				if ((double)Mods.updateTimer > (double)Mods.updateRate)
				{
					Mods.updateTimer = 999f;
					GorillaTagger.Instance.UpdateColor(Mods.color.r, Mods.color.g, Mods.color.b);
					GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", 1, new object[]
					{
						Mods.color.r,
						Mods.color.g,
						Mods.color.b,
						false
					});
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
					Mods.flushmanually();
				}
			}
		}

		public static void aaaaaA()
		{
			PhotonNetwork.CurrentRoom.IsOpen = true;
		}

		public static void aaaaaA2()
		{
			PhotonNetwork.CurrentRoom.IsOpen = false;
		}

		public static void anticosmetics()
		{
			ExecuteCloudScriptRequest executeCloudScriptRequest = new ExecuteCloudScriptRequest();
			executeCloudScriptRequest.FunctionName = "RoomClosed";
			executeCloudScriptRequest.FunctionParameter = new
			{
				GameId = PhotonNetwork.CurrentRoom.Name,
				Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper()
			};
			PlayFabClientAPI.ExecuteCloudScript(executeCloudScriptRequest, delegate(ExecuteCloudScriptResult result)
			{
			}, null, null, null);
		}

		public static void RaiseRpcEvents(Player p)
		{
			int actorNumber = p.ActorNumber;
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions
			{
				Receivers = 1
			};
			PhotonNetwork.NetworkingClient.OpRaiseEvent(207, actorNumber, raiseEventOptions, SendOptions.SendReliable);
		}

		public static void throwup()
		{
			if (WristMenu.triggerDownL && Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom)
			{
				Mods.balll2111 = Time.time;
				Vector3 vector = (Player.Instance.headCollider.transform.forward * 3f).normalized * 500f;
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				int num2 = 1;
				if (Mods.cycle)
				{
					Mods.fuckyoucsharp++;
					if (Mods.fuckyoucsharp == 0)
					{
						num2 = Mods.projectilehashc1;
					}
					if (Mods.fuckyoucsharp == 1)
					{
						num2 = Mods.projectilehashc2;
					}
					if (Mods.fuckyoucsharp == 2)
					{
						num2 = Mods.projectilehashc3;
					}
					if (Mods.fuckyoucsharp == 3)
					{
						num2 = Mods.projectilehashc4;
					}
					if (Mods.fuckyoucsharp == 4)
					{
						Mods.fuckyoucsharp = 0;
						num2 = Mods.projectilehashc1;
					}
				}
				else
				{
					num2 = Mods.projectilehash;
				}
				GameObject gameObject = ObjectPools.instance.Instantiate(num2);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				if (Mods.projectiletrailhash != -1)
				{
					ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
				}
				gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
				Color color = Mods.projcolor;
				if (Mods.rainboww)
				{
					Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
					color = Mods.erm.GetComponent<ColorChanger>().color;
				}
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					GorillaTagger.Instance.offlineVRRig.transform.position,
					vector,
					Mods.projectilehash,
					Mods.projectiletrailhash,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(GorillaTagger.Instance.offlineVRRig.transform.position, vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				Mods.flushmanually();
			}
		}

		public static void wallproj()
		{
			if (WristMenu.gripDownL && WristMenu.gripDownR && Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom)
			{
				Mods.balll2111 = Time.time;
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				int num2 = 1;
				if (Mods.cycle)
				{
					Mods.fuckyoucsharp++;
					if (Mods.fuckyoucsharp == 0)
					{
						num2 = Mods.projectilehashc1;
					}
					if (Mods.fuckyoucsharp == 1)
					{
						num2 = Mods.projectilehashc2;
					}
					if (Mods.fuckyoucsharp == 2)
					{
						num2 = Mods.projectilehashc3;
					}
					if (Mods.fuckyoucsharp == 3)
					{
						num2 = Mods.projectilehashc4;
					}
					if (Mods.fuckyoucsharp == 4)
					{
						Mods.fuckyoucsharp = 0;
						num2 = Mods.projectilehashc1;
					}
				}
				else
				{
					num2 = Mods.projectilehash;
				}
				GameObject gameObject = ObjectPools.instance.Instantiate(num2);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				if (Mods.projectiletrailhash != -1)
				{
					ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
				}
				gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
				Color color = Mods.projcolor;
				if (Mods.rainboww)
				{
					Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
					color = Mods.erm.GetComponent<ColorChanger>().color;
				}
				Vector3 vector = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1f;
				Quaternion rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
				Mods.funynwall = new GameObject();
				Mods.funynwall.transform.position = vector;
				Mods.funynwall.transform.rotation = rotation;
				Vector3 item = vector + rotation * new Vector3(-0.5f, 0.7f, 1f);
				Vector3 item2 = vector + rotation * new Vector3(0f, 0.7f, 1f);
				Vector3 item3 = vector + rotation * new Vector3(0.5f, 0.7f, 1f);
				Vector3 item4 = vector + rotation * new Vector3(-0.5f, 0.4f, 1f);
				Vector3 item5 = vector + rotation * new Vector3(0f, 0.4f, 1f);
				Vector3 item6 = vector + rotation * new Vector3(0.5f, 0.4f, 1f);
				Vector3 item7 = vector + rotation * new Vector3(-0.5f, 0.1f, 1f);
				Vector3 item8 = vector + rotation * new Vector3(0f, 0.1f, 1f);
				Vector3 item9 = vector + rotation * new Vector3(0.5f, 0.1f, 1f);
				List<Vector3> list = new List<Vector3>
				{
					item,
					item2,
					item3,
					item4,
					item5,
					item6,
					item7,
					item8,
					item9
				};
				Vector3 vector2 = Vector3.zero;
				if (Mods.wallposint >= 1 && Mods.wallposint <= 9)
				{
					vector2 = list[Mods.wallposint - 1];
				}
				else if (Mods.wallposint == 10)
				{
					vector2 = list[0];
					Mods.wallposint = 1;
				}
				Mods.wallposint++;
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					vector2,
					Vector3.zero,
					Mods.projectilehash,
					Mods.projectiletrailhash,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(vector2, Vector3.zero, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				Mods.flushmanually();
				list.Clear();
			}
		}

		public static void projspam()
		{
			if (Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom)
			{
				if (WristMenu.gripDownR)
				{
					int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					int num2 = 1;
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							num2 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							num2 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							num2 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							num2 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							num2 = Mods.projectilehashc1;
						}
					}
					else
					{
						num2 = Mods.projectilehash;
					}
					GameObject gameObject = ObjectPools.instance.Instantiate(num2);
					SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
					if (Mods.projectiletrailhash != -1)
					{
						ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
					}
					gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
					Color color = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color = Mods.erm.GetComponent<ColorChanger>().color;
					}
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						GorillaTagger.Instance.offlineVRRig.rightHandTransform.position,
						Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false),
						num2,
						Mods.projectiletrailhash,
						false,
						num,
						true,
						color.r,
						color.g,
						color.b,
						color.a
					});
					component.Launch(GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false), PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				}
				if (WristMenu.gripDownL && Mods.bothhands)
				{
					int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					int num4 = 1;
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							num4 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							num4 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							num4 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							num4 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							num4 = Mods.projectilehashc1;
						}
					}
					else
					{
						num4 = Mods.projectilehash;
					}
					GameObject gameObject2 = ObjectPools.instance.Instantiate(num4);
					SlingshotProjectile component2 = gameObject2.GetComponent<SlingshotProjectile>();
					if (Mods.projectiletrailhash != -1)
					{
						ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject2.gameObject, false, false);
					}
					gameObject2.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
					Color color2 = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color2 = Mods.erm.GetComponent<ColorChanger>().color;
					}
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						GorillaTagger.Instance.offlineVRRig.leftHandTransform.position,
						Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false),
						num4,
						Mods.projectiletrailhash,
						false,
						num3,
						true,
						color2.r,
						color2.g,
						color2.b,
						color2.a
					});
					component2.Launch(GorillaTagger.Instance.offlineVRRig.leftHandTransform.position, Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false), PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color2);
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				}
			}
			Mods.balll2111 = Time.time;
		}

		public static void leafspm()
		{
			if (Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom)
			{
				if (WristMenu.gripDownR)
				{
					int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							int num2 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							int num3 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							int num4 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							int num5 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							int num6 = Mods.projectilehashc1;
						}
					}
					else
					{
						int num7 = Mods.projectilehash;
					}
					Color color = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color = Mods.erm.GetComponent<ColorChanger>().color;
					}
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						GorillaTagger.Instance.offlineVRRig.rightHandTransform.position,
						Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false),
						1096146323,
						Mods.projectiletrailhash,
						false,
						num,
						true,
						color.r,
						color.g,
						color.b,
						color.a
					});
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				}
				if (WristMenu.gripDownL && Mods.bothhands)
				{
					int num8 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							int num9 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							int num10 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							int num11 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							int num12 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							int num13 = Mods.projectilehashc1;
						}
					}
					else
					{
						int num14 = Mods.projectilehash;
					}
					Color color2 = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color2 = Mods.erm.GetComponent<ColorChanger>().color;
					}
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						GorillaTagger.Instance.offlineVRRig.leftHandTransform.position,
						Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false),
						1096146323,
						Mods.projectiletrailhash,
						false,
						num8,
						true,
						color2.r,
						color2.g,
						color2.b,
						color2.a
					});
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				}
			}
			Mods.balll2111 = Time.time;
		}

		public static void spazprojspam()
		{
			if (Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom)
			{
				if (WristMenu.gripDownR)
				{
					int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					int num2 = 1;
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							num2 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							num2 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							num2 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							num2 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							num2 = Mods.projectilehashc1;
						}
					}
					else
					{
						num2 = Mods.projectilehash;
					}
					GameObject gameObject = ObjectPools.instance.Instantiate(num2);
					SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
					if (Mods.projectiletrailhash != -1)
					{
						ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
					}
					gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
					Color color = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color = Mods.erm.GetComponent<ColorChanger>().color;
					}
					Vector3 vector;
					vector..ctor((float)Random.Range(-33, 33), (float)Random.Range(-33, 33), (float)Random.Range(-33, 33));
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						GorillaTagger.Instance.offlineVRRig.rightHandTransform.position,
						vector,
						num2,
						Mods.projectiletrailhash,
						false,
						num,
						true,
						color.r,
						color.g,
						color.b,
						color.a
					});
					component.Launch(GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				}
				if (WristMenu.gripDownL && Mods.bothhands)
				{
					int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					int num4 = 1;
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							num4 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							num4 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							num4 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							num4 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							num4 = Mods.projectilehashc1;
						}
					}
					else
					{
						num4 = Mods.projectilehash;
					}
					GameObject gameObject2 = ObjectPools.instance.Instantiate(num4);
					SlingshotProjectile component2 = gameObject2.GetComponent<SlingshotProjectile>();
					if (Mods.projectiletrailhash != -1)
					{
						ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject2.gameObject, false, false);
					}
					gameObject2.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
					Color color2 = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color2 = Mods.erm.GetComponent<ColorChanger>().color;
					}
					Vector3 vector2;
					vector2..ctor((float)Random.Range(-33, 33), (float)Random.Range(-33, 33), (float)Random.Range(-33, 33));
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						GorillaTagger.Instance.offlineVRRig.leftHandTransform.position,
						vector2,
						num4,
						Mods.projectiletrailhash,
						false,
						num3,
						true,
						color2.r,
						color2.g,
						color2.b,
						color2.a
					});
					component2.Launch(GorillaTagger.Instance.offlineVRRig.leftHandTransform.position, vector2, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color2);
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				}
			}
			Mods.balll2111 = Time.time;
		}

		public static void firework()
		{
			if (Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom && WristMenu.gripDownR)
			{
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				int num2 = 1;
				if (Mods.cycle)
				{
					Mods.fuckyoucsharp++;
					if (Mods.fuckyoucsharp == 0)
					{
						num2 = Mods.projectilehashc1;
					}
					if (Mods.fuckyoucsharp == 1)
					{
						num2 = Mods.projectilehashc2;
					}
					if (Mods.fuckyoucsharp == 2)
					{
						num2 = Mods.projectilehashc3;
					}
					if (Mods.fuckyoucsharp == 3)
					{
						num2 = Mods.projectilehashc4;
					}
					if (Mods.fuckyoucsharp == 4)
					{
						Mods.fuckyoucsharp = 0;
						num2 = Mods.projectilehashc1;
					}
				}
				else
				{
					num2 = Mods.projectilehash;
				}
				GameObject gameObject = ObjectPools.instance.Instantiate(num2);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				if (Mods.projectiletrailhash != -1)
				{
					ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
				}
				gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
				Color color = Mods.projcolor;
				if (Mods.rainboww)
				{
					Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
					color = Mods.erm.GetComponent<ColorChanger>().color;
				}
				Vector3 vector;
				vector..ctor((float)Random.Range(-77, 77), (float)Random.Range(-77, 77), (float)Random.Range(-77, 77));
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 5f, 0f),
					vector,
					num2,
					Mods.projectiletrailhash,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 5f, 0f), vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			}
			Mods.balll2111 = Time.time;
		}

		public static List<VRRig> GetValidChoosableRigs()
		{
			Mods.validRigs.Clear();
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				if (!vrrig.isOfflineVRRig && (PhotonNetwork.InRoom || vrrig.isOfflineVRRig) && !(vrrig == null))
				{
					Mods.validRigs.Add(vrrig);
				}
			}
			return Mods.validRigs;
		}

		public static float Distance2D(Vector3 a, Vector3 b)
		{
			Vector2 vector = new Vector2(a.x, a.z);
			Vector2 vector2;
			vector2..ctor(b.x, b.z);
			return Vector2.Distance(vector, vector2);
		}

		public static bool PlayerNear(VRRig rig, float dist, out float playerDist, Vector3 rigpos)
		{
			Mods.layerMask = (UnityLayerExtensions.ToLayerMask(0) | UnityLayerExtensions.ToLayerMask(9));
			if (rig == null)
			{
				playerDist = float.PositiveInfinity;
				return false;
			}
			playerDist = Mods.Distance2D(rig.transform.position, rigpos);
			return playerDist < dist && Physics.RaycastNonAlloc(new Ray(rigpos, rig.transform.position - rigpos), Mods.rayResults, playerDist, Mods.layerMask) <= 0;
		}

		public static bool ClosestPlayer(in Vector3 myPos, out VRRig outRig)
		{
			float num = float.MaxValue;
			outRig = null;
			foreach (VRRig vrrig in Mods.GetValidChoosableRigs())
			{
				float num2 = 0f;
				if (Mods.PlayerNear(vrrig, 15f, out num2, myPos) && num2 < num)
				{
					num = num2;
					outRig = vrrig;
				}
			}
			return num != float.MaxValue;
		}

		public static void lookatclosestpookiebear()
		{
			VRRig offlineVRRig = GorillaTagger.Instance.offlineVRRig;
			Vector3 position = GorillaTagger.Instance.offlineVRRig.transform.position;
			Mods.ClosestPlayer(position, out offlineVRRig);
			Mods.weuhfewh = true;
			GorillaTagger.Instance.offlineVRRig.headConstraint.LookAt(offlineVRRig.transform.position + new Vector3(0f, 0.4f, 0f));
		}

		public static void offlook()
		{
			if (Mods.weuhfewh)
			{
				Mods.weuhfewh = false;
				GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = Player.Instance.headCollider.transform.rotation;
			}
		}

		public static void projlauncher()
		{
			if (Time.time > Mods.balll2111 + 0f && PhotonNetwork.InRoom)
			{
				if (WristMenu.gripDownR)
				{
					int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					int num2 = 1;
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							num2 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							num2 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							num2 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							num2 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							num2 = Mods.projectilehashc1;
						}
					}
					else
					{
						num2 = Mods.projectilehash;
					}
					GameObject gameObject = ObjectPools.instance.Instantiate(num2);
					SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
					if (Mods.projectiletrailhash != -1)
					{
						ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
					}
					gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
					Color color = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color = Mods.erm.GetComponent<ColorChanger>().color;
					}
					Vector3 vector = Vector3.zero;
					Vector3 vector2 = Vector3.zero;
					vector2 = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
					vector = GorillaTagger.Instance.offlineVRRig.rightHandTransform.up.normalized * 7f;
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						vector2,
						vector,
						num2,
						Mods.projectiletrailhash,
						false,
						num,
						true,
						color.r,
						color.g,
						color.b,
						color.a
					});
					component.Launch(vector2, vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				}
				if (WristMenu.gripDownL && Mods.bothhands)
				{
					int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					int num4 = 1;
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							num4 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							num4 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							num4 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							num4 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							num4 = Mods.projectilehashc1;
						}
					}
					else
					{
						num4 = Mods.projectilehash;
					}
					GameObject gameObject2 = ObjectPools.instance.Instantiate(num4);
					SlingshotProjectile component2 = gameObject2.GetComponent<SlingshotProjectile>();
					if (Mods.projectiletrailhash != -1)
					{
						ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject2.gameObject, false, false);
					}
					gameObject2.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
					Color color2 = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color2 = Mods.erm.GetComponent<ColorChanger>().color;
					}
					Vector3 vector3 = Vector3.zero;
					Vector3 vector4 = Vector3.zero;
					vector4 = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
					vector3 = GorillaTagger.Instance.offlineVRRig.leftHandTransform.up.normalized * 7f;
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						vector4,
						vector3,
						num4,
						Mods.projectiletrailhash,
						false,
						num3,
						true,
						color2.r,
						color2.g,
						color2.b,
						color2.a
					});
					component2.Launch(vector4, vector3, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color2);
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				}
				Mods.balll2111 = Time.time;
			}
		}

		public static void projhalo()
		{
			if (Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom && WristMenu.triggerDownL)
			{
				Mods.balll2111 = Time.time;
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				int num2 = 1;
				if (Mods.cycle)
				{
					Mods.fuckyoucsharp++;
					if (Mods.fuckyoucsharp == 0)
					{
						num2 = Mods.projectilehashc1;
					}
					if (Mods.fuckyoucsharp == 1)
					{
						num2 = Mods.projectilehashc2;
					}
					if (Mods.fuckyoucsharp == 2)
					{
						num2 = Mods.projectilehashc3;
					}
					if (Mods.fuckyoucsharp == 3)
					{
						num2 = Mods.projectilehashc4;
					}
					if (Mods.fuckyoucsharp == 4)
					{
						Mods.fuckyoucsharp = 0;
						num2 = Mods.projectilehashc1;
					}
				}
				else
				{
					num2 = Mods.projectilehash;
				}
				GameObject gameObject = ObjectPools.instance.Instantiate(num2);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				if (Mods.projectiletrailhash != -1)
				{
					ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
				}
				gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
				Color color = Mods.projcolor;
				if (Mods.rainboww)
				{
					Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
					color = Mods.erm.GetComponent<ColorChanger>().color;
				}
				Mods.angle += Mods.orbitSpeed * Time.deltaTime;
				float num3 = GorillaTagger.Instance.offlineVRRig.transform.position.x + 0.7f * Mathf.Cos(Mods.angle);
				float num4 = GorillaTagger.Instance.offlineVRRig.transform.position.y + 1.5f;
				float num5 = GorillaTagger.Instance.offlineVRRig.transform.position.z + 0.7f * Mathf.Sin(Mods.angle);
				Vector3 vector;
				vector..ctor(num3, num4, num5);
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					vector,
					Vector3.zero,
					num2,
					Mods.projectiletrailhash,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(vector, Vector3.zero, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			}
		}

		public static void firewrokproj()
		{
			if (Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom && WristMenu.gripDownL)
			{
				Mods.balll2111 = Time.time;
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				int num2 = 1;
				if (Mods.cycle)
				{
					Mods.fuckyoucsharp++;
					if (Mods.fuckyoucsharp == 0)
					{
						num2 = Mods.projectilehashc1;
					}
					if (Mods.fuckyoucsharp == 1)
					{
						num2 = Mods.projectilehashc2;
					}
					if (Mods.fuckyoucsharp == 2)
					{
						num2 = Mods.projectilehashc3;
					}
					if (Mods.fuckyoucsharp == 3)
					{
						num2 = Mods.projectilehashc4;
					}
					if (Mods.fuckyoucsharp == 4)
					{
						Mods.fuckyoucsharp = 0;
						num2 = Mods.projectilehashc1;
					}
				}
				else
				{
					num2 = Mods.projectilehash;
				}
				GameObject gameObject = ObjectPools.instance.Instantiate(num2);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				if (Mods.projectiletrailhash != -1)
				{
					ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
				}
				gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 6f, 0f);
				Color color = Mods.projcolor;
				if (Mods.rainboww)
				{
					Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
					color = Mods.erm.GetComponent<ColorChanger>().color;
				}
				float num3 = 10f;
				float num4 = 18f;
				float num5 = 2f;
				Vector3 onUnitSphere = Random.onUnitSphere;
				float num6 = Random.Range(num3, num4);
				onUnitSphere.y += num5;
				onUnitSphere.Normalize();
				Vector3 vector = onUnitSphere * num6;
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 4f, 0f),
					vector,
					num2,
					Mods.projectiletrailhash,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 4f, 0f), vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			}
		}

		public static void firewrokproj2()
		{
			if (Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom && WristMenu.gripDownL)
			{
				Mods.balll2111 = Time.time;
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				int num2 = 1;
				if (Mods.cycle)
				{
					Mods.fuckyoucsharp++;
					if (Mods.fuckyoucsharp == 0)
					{
						num2 = Mods.projectilehashc1;
					}
					if (Mods.fuckyoucsharp == 1)
					{
						num2 = Mods.projectilehashc2;
					}
					if (Mods.fuckyoucsharp == 2)
					{
						num2 = Mods.projectilehashc3;
					}
					if (Mods.fuckyoucsharp == 3)
					{
						num2 = Mods.projectilehashc4;
					}
					if (Mods.fuckyoucsharp == 4)
					{
						Mods.fuckyoucsharp = 0;
						num2 = Mods.projectilehashc1;
					}
				}
				else
				{
					num2 = Mods.projectilehash;
				}
				GameObject gameObject = ObjectPools.instance.Instantiate(num2);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				if (Mods.projectiletrailhash != -1)
				{
					ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
				}
				gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 6f, 0f);
				Color color = Mods.projcolor;
				if (Mods.rainboww)
				{
					Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
					color = Mods.erm.GetComponent<ColorChanger>().color;
				}
				float num3 = 2f;
				float num4 = 10f;
				float num5 = 4f;
				Vector3 onUnitSphere = Random.onUnitSphere;
				float num6 = Random.Range(num3, num4);
				onUnitSphere.y += num5;
				onUnitSphere.Normalize();
				Vector3 vector = onUnitSphere * num6;
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 3f, 0f),
					vector,
					num2,
					Mods.projectiletrailhash,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 3f, 0f), vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			}
		}

		public static void pissspam()
		{
			if (Time.time > Mods.balll2111 + 0.03f && PhotonNetwork.InRoom && WristMenu.gripDownR)
			{
				Mods.balll2111 = Time.time;
				Vector3 vector = GorillaTagger.Instance.offlineVRRig.transform.forward.normalized * 10f;
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				GameObject gameObject = ObjectPools.instance.Instantiate(-820530352);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position - new Vector3(0f, 0.3f, 0f);
				Color color = Mods.pissColor;
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					GorillaTagger.Instance.offlineVRRig.transform.position - new Vector3(0f, 0.3f, 0f),
					vector,
					-820530352,
					-1,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(GorillaTagger.Instance.offlineVRRig.transform.position - new Vector3(0f, 0.3f, 0f), vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			}
		}

		public static void cumspam()
		{
			if (Time.time > Mods.balll2111 + 0.03f && PhotonNetwork.InRoom && WristMenu.gripDownR)
			{
				Mods.balll2111 = Time.time;
				Vector3 vector = GorillaTagger.Instance.offlineVRRig.transform.forward.normalized * 10f;
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				GameObject gameObject = ObjectPools.instance.Instantiate(-820530352);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position - new Vector3(0f, 0.3f, 0f);
				Color color = Mods.cumColor;
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					GorillaTagger.Instance.offlineVRRig.transform.position - new Vector3(0f, 0.3f, 0f),
					vector,
					-820530352,
					-1,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(GorillaTagger.Instance.offlineVRRig.transform.position - new Vector3(0f, 0.3f, 0f), vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			}
		}

		public static void poopspam()
		{
			if (Time.time > Mods.balll2111 + 0.1f && PhotonNetwork.InRoom && WristMenu.gripDownR)
			{
				Mods.balll2111 = Time.time;
				Vector3 zero = Vector3.zero;
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				GameObject gameObject = ObjectPools.instance.Instantiate(-675036877);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
				Color color = new Color32(73, 44, 0, 1);
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					GorillaTagger.Instance.offlineVRRig.transform.position,
					zero,
					-675036877,
					-1,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(GorillaTagger.Instance.offlineVRRig.transform.position, zero, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			}
		}

		public static void particlearoundyou()
		{
			Vector3 vector = Random.insideUnitSphere.normalized * (float)Random.Range(0, 6);
			if (WristMenu.gripDownR)
			{
				Mods.SpawnImpact(GorillaTagger.Instance.offlineVRRig.transform.position + vector, Mods.projcolor);
			}
		}

		public static void particlemap()
		{
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").activeSelf)
			{
				zero..ctor(-81.1999f, 2.5157f, -86.2651f);
				zero2..ctor(-38.9959f, 31.9568f, -33.5882f);
			}
			if (GameObject.Find("Environment Objects/LocalObjects_Prefab/City").activeSelf)
			{
				zero..ctor(-27.3422f, 15.1089f, -108.7779f);
				zero2..ctor(-60.8962f, 30.1384f, -106.5273f);
			}
			Vector3 pos;
			pos..ctor(Random.Range(zero.x, zero2.x), Random.Range(zero.y, zero2.y), Random.Range(zero.z, zero2.z));
			if (WristMenu.gripDownR)
			{
				Mods.SpawnImpact(pos, Mods.cumColor);
			}
		}

		public static void particleall()
		{
			if (Time.time > Mods.balll2111 + 0.2f && PhotonNetwork.InRoom)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					if (!vrrig.isOfflineVRRig && WristMenu.triggerDownL)
					{
						Mods.SpawnImpactnOdELAY(vrrig.transform.position, vrrig.playerColor);
					}
				}
				Mods.balll2111 = Time.time;
			}
		}

		public static void yaptap()
		{
		}

		public static void demonichands()
		{
			if (WristMenu.gripDownL)
			{
				Mods.SpawnImpact(GorillaTagger.Instance.offlineVRRig.leftHandTransform.position, Color.red);
			}
			if (WristMenu.gripDownR)
			{
				Mods.SpawnImpact2(GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, Color.red);
			}
		}

		public static Vector3 pookiebeargen()
		{
			float num = (float)Random.Range(-8, 8);
			float num2 = (float)Random.Range(-8, 8);
			Vector3 vector = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(num, 7f, num2);
			vector.y = Mathf.Min(vector.y, GorillaTagger.Instance.offlineVRRig.transform.position.y + 7f);
			if ((GorillaTagger.Instance.offlineVRRig.transform.position - vector).magnitude < GorillaGameManager.instance.tagDistanceThreshold)
			{
				return vector;
			}
			return Mods.pookiebeargen();
		}

		public static Vector3 rahhgen()
		{
			float num = (float)Random.Range(-3, 3);
			float num2 = (float)Random.Range(-3, 3);
			Vector3 vector = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(num, 3f, num2);
			vector.y = Mathf.Min(vector.y, GorillaTagger.Instance.offlineVRRig.transform.position.y + 4f);
			if ((GorillaTagger.Instance.offlineVRRig.transform.position - vector).magnitude < GorillaGameManager.instance.tagDistanceThreshold)
			{
				return vector;
			}
			return Mods.pookiebeargen();
		}

		public static void crashtest()
		{
			foreach (CosmeticsController cosmeticsController in Resources.FindObjectsOfTypeAll<CosmeticsController>())
			{
				cosmeticsController.currentTime = new DateTime(99999999L);
				cosmeticsController.Awake();
			}
		}

		public static void rainproj()
		{
			if (WristMenu.triggerDownL && Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom)
			{
				Mods.balll2111 = Time.time;
				Vector3 vector = Mods.pookiebeargen();
				int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				int num2 = 1;
				if (Mods.cycle)
				{
					Mods.fuckyoucsharp++;
					if (Mods.fuckyoucsharp == 0)
					{
						num2 = Mods.projectilehashc1;
					}
					if (Mods.fuckyoucsharp == 1)
					{
						num2 = Mods.projectilehashc2;
					}
					if (Mods.fuckyoucsharp == 2)
					{
						num2 = Mods.projectilehashc3;
					}
					if (Mods.fuckyoucsharp == 3)
					{
						num2 = Mods.projectilehashc4;
					}
					if (Mods.fuckyoucsharp == 4)
					{
						Mods.fuckyoucsharp = 0;
						num2 = Mods.projectilehashc1;
					}
				}
				else
				{
					num2 = Mods.projectilehash;
				}
				GameObject gameObject = ObjectPools.instance.Instantiate(num2);
				SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
				if (Mods.projectiletrailhash != -1)
				{
					ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
				}
				Color color = Mods.projcolor;
				if (Mods.rainboww)
				{
					Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
					color = Mods.erm.GetComponent<ColorChanger>().color;
				}
				GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
				{
					vector,
					Vector3.zero,
					num2,
					Mods.projectiletrailhash,
					false,
					num,
					true,
					color.r,
					color.g,
					color.b,
					color.a
				});
				component.Launch(vector, Vector3.zero, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
				PhotonNetwork.SendAllOutgoingCommands();
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				Mods.flushmanually();
			}
		}

		public static void rainprojmap()
		{
			if (WristMenu.triggerDownL)
			{
				if (Time.time > Mods.balll2111 + 0.1f && PhotonNetwork.InRoom)
				{
					Mods.balll2111 = Time.time;
					Vector3 vector;
					vector..ctor(-78.1698f, 45.5251f, -83.1939f);
					Vector3 vector2;
					vector2..ctor(-40.7027f, 42.2017f, -32.7972f);
					Vector3 position;
					position..ctor(Random.Range(vector.x, vector2.x), Random.Range(vector.y, vector2.y), Random.Range(vector.z, vector2.z));
					GorillaTagger.Instance.offlineVRRig.enabled = false;
					GorillaTagger.Instance.offlineVRRig.transform.position = position;
				}
				if (Time.time > Mods.balll12111 + 0f && PhotonNetwork.InRoom)
				{
					Mods.balll12111 = Time.time;
					Vector3 vector3 = Mods.pookiebeargen();
					int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					GameObject gameObject = ObjectPools.instance.Instantiate(Mods.projectilehash);
					SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
					SlingshotProjectileTrail component2 = ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>();
					gameObject.GetComponent<SlingshotProjectile>();
					component2.AttachTrail(gameObject.gameObject, false, false);
					Color color = Color.white;
					if (Mods.rainboww)
					{
						int num2 = Random.Range(0, 6);
						if (num2 == 0)
						{
							color = Color.red;
						}
						if (num2 == 1)
						{
							color = Color.yellow;
						}
						if (num2 == 2)
						{
							color = Color.black;
						}
						if (num2 == 3)
						{
							color = Color.white;
						}
						if (num2 == 4)
						{
							color = Color.magenta;
						}
						if (num2 == 5)
						{
							color = Color.green;
						}
					}
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						vector3,
						Vector3.zero,
						Mods.projectilehash,
						Mods.projectiletrailhash,
						false,
						num,
						true,
						color.r,
						color.g,
						color.b,
						color.a
					});
					Debug.Log("called rpc");
					component.Launch(vector3, Vector3.zero, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
					Mods.flushmanually();
				}
			}
		}

		public static void SpawnImpact(Vector3 pos, Color color)
		{
			if (Time.time > Mods.balll2111 + 0.02f && PhotonNetwork.InRoom)
			{
				Mods.balll2111 = Time.time;
				GorillaGameManager.instance.photonView.RPC("SpawnSlingshotPlayerImpactEffect", 0, new object[]
				{
					pos,
					color.r,
					color.g,
					color.b,
					color.a,
					1
				});
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				Mods.flushmanually();
			}
		}

		public static void SpawnImpactnOdELAY(Vector3 pos, Color color)
		{
			if (PhotonNetwork.InRoom)
			{
				GorillaGameManager.instance.photonView.RPC("SpawnSlingshotPlayerImpactEffect", 0, new object[]
				{
					pos,
					color.r,
					color.g,
					color.b,
					color.a,
					1
				});
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
				Mods.flushmanually();
			}
		}

		public static void SpawnImpact2(Vector3 pos, Color color)
		{
			if (Time.time > Mods.balll21111 + 0.02f && PhotonNetwork.InRoom)
			{
				Mods.balll21111 = Time.time;
				GorillaGameManager.instance.photonView.RPC("SpawnSlingshotPlayerImpactEffect", 0, new object[]
				{
					pos,
					color.r,
					color.g,
					color.b,
					color.a,
					1
				});
				Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
			}
		}

		public static void particlegun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR && Time.time > Mods.balll2111 + 0.05f && PhotonNetwork.InRoom)
				{
					Mods.balll2111 = Time.time;
					Mods.SpawnImpactnOdELAY(Mods.pointer.transform.position, Color.red);
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void waterballoonprojgun()
		{
			if (Mods.bothhands)
			{
				Mods.waterballoonprojgun2();
			}
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (!WristMenu.triggerDownR)
				{
					Mods.fun = false;
					return;
				}
				if (Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom)
				{
					Mods.balll2111 = Time.time;
					int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					int num2 = 1;
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							num2 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							num2 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							num2 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							num2 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							num2 = Mods.projectilehashc1;
						}
					}
					else
					{
						num2 = Mods.projectilehash;
					}
					GameObject gameObject = ObjectPools.instance.Instantiate(num2);
					SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
					if (Mods.projectiletrailhash != -1)
					{
						ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
					}
					gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
					Color white = Color.white;
					Vector3 vector = (Mods.raycastHit.point - GorillaTagger.Instance.offlineVRRig.rightHandTransform.position).normalized;
					float num3 = 55f;
					vector *= num3;
					Color color = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color = Mods.erm.GetComponent<ColorChanger>().color;
					}
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						GorillaTagger.Instance.offlineVRRig.rightHandTransform.position,
						vector,
						num2,
						Mods.projectiletrailhash,
						false,
						num,
						true,
						color.r,
						color.g,
						color.b,
						color.a
					});
					component.Launch(GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
					PhotonNetwork.SendAllOutgoingCommands();
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void testfungun()
		{
			if (!Mods.testgunvar)
			{
				Mods.testgunvar = true;
				foreach (WorldShareableItem worldShareableItem in Object.FindObjectsOfType<WorldShareableItem>())
				{
					if (worldShareableItem.gameObject.GetComponent<DecorativeItemReliableState>())
					{
						Mods.testgunvarList.Add(worldShareableItem.gameObject);
					}
				}
			}
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR)
				{
					if (Time.time <= Mods.balll2111 + 0.01f || !PhotonNetwork.InRoom)
					{
						return;
					}
					Mods.balll2111 = Time.time;
					Vector3 normalized = (Mods.raycastHit.point - GorillaTagger.Instance.offlineVRRig.rightHandTransform.position).normalized;
					float num = 55f;
					normalized * num;
					using (List<GameObject>.Enumerator enumerator = Mods.testgunvarList.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							GameObject gameObject = enumerator.Current;
							PhotonView component = gameObject.GetComponent<PhotonView>();
							component.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
							component.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
							gameObject.transform.position = Mods.pointer.transform.position;
						}
						return;
					}
				}
				Mods.fun = false;
				return;
			}
			Object.Destroy(Mods.pointer);
		}

		public static void waterballoonprojgun2()
		{
			if (WristMenu.gripDownL)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.leftControllerTransform.position - Player.Instance.leftControllerTransform.up, -Player.Instance.leftControllerTransform.up, ref Mods.raycastHit) && Mods.pointer2 == null)
					{
						Mods.pointer2 = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer2.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer2.GetComponent<SphereCollider>());
						Mods.pointer2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer2.transform.position = Mods.raycastHit.point;
				}
				if (!WristMenu.triggerDownL)
				{
					Mods.fun = false;
					return;
				}
				if (Time.time > Mods.balll2111 + 0.01f && PhotonNetwork.InRoom)
				{
					Mods.balll2111 = Time.time;
					int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					int num2 = 1;
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							num2 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							num2 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							num2 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							num2 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							num2 = Mods.projectilehashc1;
						}
					}
					else
					{
						num2 = Mods.projectilehash;
					}
					GameObject gameObject = ObjectPools.instance.Instantiate(num2);
					SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
					if (Mods.projectiletrailhash != -1)
					{
						ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
					}
					gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
					Color white = Color.white;
					Vector3 vector = (Mods.raycastHit.point - GorillaTagger.Instance.offlineVRRig.leftHandTransform.position).normalized;
					float num3 = 55f;
					vector *= num3;
					Color color = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color = Mods.erm.GetComponent<ColorChanger>().color;
					}
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						GorillaTagger.Instance.offlineVRRig.leftHandTransform.position,
						vector,
						num2,
						Mods.projectiletrailhash,
						false,
						num,
						true,
						color.r,
						color.g,
						color.b,
						color.a
					});
					component.Launch(GorillaTagger.Instance.offlineVRRig.leftHandTransform.position, vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
					return;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer2);
			}
		}

		public static void KickDeps(RpcTarget p)
		{
			Vector3 vector = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, -5f, 0f);
			Vector3 vector2;
			vector2..ctor(0f, 0f, 0f);
			int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
			GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", p, new object[]
			{
				vector,
				vector2,
				-1674517839,
				163790326,
				false,
				num,
				false,
				0f,
				0f,
				0f,
				1f
			});
			PhotonNetwork.SendAllOutgoingCommands();
		}

		public static void matSpamAll()
		{
			foreach (Player player in PhotonNetwork.PlayerList)
			{
				GorillaTagManager component = GameObject.Find("Player Objects/GorillaParent/Gorilla Tag Manager(Clone)").GetComponent<GorillaTagManager>();
				if (!component.photonView.IsMine)
				{
					component.photonView.RequestOwnership();
				}
				if (component.photonView.IsMine)
				{
					if (new Random().Next(0, 2) == 1 && (double)Time.time > (double)Mods.ieuzrjhm + 0.025)
					{
						component.currentInfected.Add(player);
						component.currentInfected.Add(player);
						CollectionExtensions.AddItem<int>(component.currentInfectedArray, player.ActorNumber);
						CollectionExtensions.AddItem<int>(component.currentInfectedArray, player.ActorNumber);
						CollectionExtensions.AddItem<int>(component.currentInfectedArray, player.ActorNumber);
						component.currentInfected.Add(player);
						component.currentInfected.Add(player);
					}
					else if (component.currentInfected.Contains(player))
					{
						component.currentInfected.Clear();
					}
					component.ChangeCurrentIt(player, true);
					component.SetisCurrentlyTag(true);
					component.isCurrentlyTag = true;
					component.currentIt = player;
					CollectionExtensions.AddItem<int>(component.currentInfectedArray, player.ActorNumber);
				}
				Mods.ieuzrjhm = Time.time;
			}
		}

		public static void KickGunv3()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						Player p = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR)
				{
					Player p;
					if (Mods.lockedrig != null)
					{
						p = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						p = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					}
					if (Time.time > Mods.balll2 + 0.01f)
					{
						Mods.balll2 = Time.time;
						if (Mods.crashtp)
						{
							GorillaTagger.Instance.offlineVRRig.enabled = false;
							GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(-92.2935f, 45.3772f, -20.7123f);
						}
						Mods.KickDeps(p);
						Mods.KickDeps(p);
						PhotonNetwork.SendAllOutgoingCommands();
						return;
					}
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.lockedrig = null;
			}
		}

		public static void killgunv1()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						Player player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR)
				{
					Player player;
					if (Mods.lockedrig != null)
					{
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					}
					if (Time.time > Mods.balll2 + 0.5f)
					{
						Mods.balll2 = Time.time;
						if (!PhotonNetwork.IsMasterClient)
						{
							if (player != null)
							{
								GameObject.Find("Player Objects/GorillaParent/Gorilla Battle Manager(Clone)").GetComponent<GorillaBattleManager>().photonView.RPC("ReportSlingshotHit", 2, new object[]
								{
									player,
									Mods.raycastHit.collider.GetComponentInParent<VRRig>().transform.position,
									1
								});
								Mods.flushmanually();
								PhotonNetwork.SendAllOutgoingCommands();
								return;
							}
						}
						else
						{
							GorillaBattleManager component = GameObject.Find("Player Objects/GorillaParent/Gorilla Battle Manager(Clone)").GetComponent<GorillaBattleManager>();
							if (component.playerLives[player.ActorNumber] > 0)
							{
								component.playerLives[player.ActorNumber] = component.playerLives[player.ActorNumber] - 1;
								return;
							}
						}
					}
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.lockedrig = null;
			}
		}

		public static void objectsgun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						Player player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR)
				{
					Player player;
					if (Mods.lockedrig != null)
					{
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					}
					PhotonNetwork.DestroyPlayerObjects(player);
					PhotonNetwork.SendAllOutgoingCommands();
					return;
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.lockedrig = null;
			}
		}

		public static void objectall()
		{
			Player[] playerListOthers = PhotonNetwork.PlayerListOthers;
			for (int i = 0; i < playerListOthers.Length; i++)
			{
				PhotonNetwork.DestroyPlayerObjects(playerListOthers[i]);
				PhotonNetwork.SendAllOutgoingCommands();
			}
		}

		public static void particlearoundplayergun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						Player p = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (WristMenu.triggerDownR)
				{
					Player p;
					if (Mods.lockedrig != null)
					{
						p = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						p = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					}
					Vector3 vector = Random.insideUnitSphere.normalized * (float)Random.Range(0, 6);
					if (WristMenu.gripDownR)
					{
						Mods.SpawnImpact(RigShit.GetRigFromPlayer(p).transform.position + vector, Mods.cumColor);
						return;
					}
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.lockedrig = null;
			}
		}

		public static void funnngun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						Player p = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR)
				{
					Player p;
					if (Mods.lockedrig != null)
					{
						p = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						p = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					}
					if (WristMenu.triggerDownL && PhotonNetwork.InRoom)
					{
						Mods.balll2111 = Time.time;
						Mods.RaiseRpcEventse(p);
						return;
					}
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.lockedrig = null;
			}
		}

		public static void InstantCrashPCVR()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				Player p = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				if (WristMenu.triggerDownR && Mods.gunLock)
				{
					if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
					{
						Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
					}
					Mods.pointer.transform.position = Mods.lockedrig.transform.position;
					p = RigShit.GetPlayerFromRig(Mods.lockedrig);
				}
				Mods.pointer.transform.position = Mods.raycastHit.point;
				if (WristMenu.triggerDownR && Time.time > Mods.balll2 + 0.02f)
				{
					Mods.balll2 = Time.time;
					string nickName = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + Mods.savedName;
					PhotonNetwork.LocalPlayer.NickName = nickName;
					PhotonNetwork.NickName = nickName;
					PhotonNetwork.NetworkingClient.NickName = nickName;
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					Mods.KickDeps(p);
					PhotonNetwork.SendAllOutgoingCommands();
					string nickName2 = Mods.savedName;
					PhotonNetwork.LocalPlayer.NickName = nickName2;
					PhotonNetwork.NickName = nickName2;
					PhotonNetwork.NetworkingClient.NickName = nickName2;
				}
			}
		}

		public static void KickOnLucyTouch()
		{
			if (GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState == 16)
			{
				Player targetPlayer = GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().targetPlayer;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = targetPlayer.ActorNumber;
				GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = targetPlayer.ActorNumber;
				string nickName = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + Mods.savedName;
				PhotonNetwork.LocalPlayer.NickName = nickName;
				PhotonNetwork.NickName = nickName;
				PhotonNetwork.NetworkingClient.NickName = nickName;
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				Mods.KickDeps(targetPlayer);
				PhotonNetwork.SendAllOutgoingCommands();
				string nickName2 = Mods.savedName;
				PhotonNetwork.LocalPlayer.NickName = nickName2;
				PhotonNetwork.NickName = nickName2;
				PhotonNetwork.NetworkingClient.NickName = nickName2;
			}
		}

		public static void testcrash()
		{
			if (Time.time > Mods.balll2 + 0.7f)
			{
				Mods.balll2 = Time.time;
				GorillaTagger.Instance.myVRRig.RPC("RequestCosmetics", 0, null);
			}
		}

		public static void c4projectile()
		{
			if (WristMenu.gripDownL)
			{
				if (Mods.c4 == null)
				{
					Mods.c4 = GameObject.CreatePrimitive(3);
					Mods.c4.transform.localScale = new Vector3(0.2f, 0.1f, 0.2f);
					Object.Destroy(Mods.c4.GetComponent<BoxCollider>());
				}
				Mods.c4.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
				Mods.c4.transform.rotation = GorillaTagger.Instance.offlineVRRig.leftHandTransform.rotation;
				Mods.shibaisblack = false;
			}
			if (WristMenu.triggerDownL)
			{
				Vector3 vel;
				vel..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel2;
				vel2..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel3;
				vel3..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 5));
				Vector3 vel4;
				vel4..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel5;
				vel5..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel6;
				vel6..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel7;
				vel7..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel8;
				vel8..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel9;
				vel9..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 5));
				Vector3 vel10;
				vel10..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel11;
				vel11..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel12;
				vel12..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel13;
				vel13..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel14;
				vel14..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel15;
				vel15..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Vector3 vel16;
				vel16..ctor((float)Random.Range(-55, 55), (float)Random.Range(-55, 55), (float)Random.Range(-55, 55));
				Color color;
				color..ctor(100f, 64.7f, 0f);
				if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, Mods.c4.transform.position) <= GorillaGameManager.instance.tagDistanceThreshold)
				{
					if (!Mods.shibaisblack)
					{
						Mods.ropedelay1 = Time.time + 0.08f;
						Mods.shibaisblack = true;
					}
					Debug.Log("if distane");
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel, Color.red, 693334698, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel2, Color.red, 693334698, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel3, Color.red, 693334698, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel4, color, 693334698, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel5, color, -675036877, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel6, color, -675036877, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel7, color, -1674517839, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel7, Color.red, -1674517839, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel7, Color.red, -1674517839, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel8, Color.red, 693334698, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel9, Color.red, 693334698, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel10, Color.red, 693334698, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel11, color, 693334698, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel12, color, -675036877, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel13, color, -675036877, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel14, color, -1674517839, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel15, Color.red, -1674517839, 163790326);
					Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Mods.c4.transform.position, vel16, Color.red, -1674517839, 163790326);
					if (Mods.ropedelay1 < Time.time)
					{
						Object.Destroy(Mods.c4);
						Mods.c4 = null;
						return;
					}
				}
				else
				{
					NotifiLib.SendNotification("<color=blue>[C4]</color> Get closer to the c4 to explode it.");
				}
			}
		}

		public static void ProjectileAura()
		{
			if (WristMenu.triggerDownL)
			{
				if (Time.time <= Mods.balll21111 + 0.2f || !PhotonNetwork.InRoom)
				{
					return;
				}
				Mods.balll21111 = Time.time;
				using (List<VRRig>.Enumerator enumerator = GorillaParent.instance.vrrigs.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						VRRig vrrig = enumerator.Current;
						if (!vrrig.isOfflineVRRig && Vector3.Distance(RigShit.GetOwnVRRig().transform.position, vrrig.transform.position) < GorillaGameManager.instance.tagDistanceThreshold)
						{
							Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(vrrig.transform.position + new Vector3(0f, 5f, 0f), Vector3.zero);
						}
					}
					return;
				}
			}
			GorillaTagger.Instance.offlineVRRig.enabled = true;
		}

		public static void ProjectileShower()
		{
			if (WristMenu.gripDownL && Time.time > Mods.balll2111 + 0.05f && PhotonNetwork.InRoom)
			{
				Mods.balll2111 = Time.time;
				Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 5f, 0f), Vector3.zero);
			}
		}

		public static void nukeself()
		{
			if (WristMenu.triggerDownR)
			{
				new Color(100f, 64.7f, 0f);
				Vector3 vel;
				vel..ctor(0f, 15.5f, 0f);
				Vector3 pos = Mods.rahhgen();
				int hash = 1;
				if (Mods.cycle)
				{
					Mods.fuckyoucsharp++;
					if (Mods.fuckyoucsharp == 0)
					{
						hash = Mods.projectilehashc1;
					}
					if (Mods.fuckyoucsharp == 1)
					{
						hash = Mods.projectilehashc2;
					}
					if (Mods.fuckyoucsharp == 2)
					{
						hash = Mods.projectilehashc3;
					}
					if (Mods.fuckyoucsharp == 3)
					{
						hash = Mods.projectilehashc4;
					}
					if (Mods.fuckyoucsharp == 4)
					{
						Mods.fuckyoucsharp = 0;
						hash = Mods.projectilehashc1;
					}
				}
				else
				{
					hash = Mods.projectilehash;
				}
				Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(pos, vel, Color.red, hash, 163790326);
			}
		}

		public static void ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Vector3 pos, Vector3 vel, Color color, int hash, int projectiletrailhash)
		{
			int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
			GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
			{
				pos,
				vel,
				hash,
				projectiletrailhash,
				false,
				num,
				true,
				color.r,
				color.g,
				color.b,
				color.a
			});
			GameObject gameObject = ObjectPools.instance.Instantiate(hash);
			SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
			if (projectiletrailhash != -1)
			{
				ObjectPools.instance.Instantiate(projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
			}
			component.Launch(pos, vel, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
			PhotonNetwork.SendAllOutgoingCommands();
			Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
		}

		public static void ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Vector3 pos, Vector3 vel)
		{
			int num = 1;
			Color color = Mods.projcolor;
			if (Mods.rainboww)
			{
				Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
				color = Mods.erm.GetComponent<ColorChanger>().color;
			}
			if (Mods.cycle)
			{
				Mods.fuckyoucsharp++;
				if (Mods.fuckyoucsharp == 0)
				{
					num = Mods.projectilehashc1;
				}
				if (Mods.fuckyoucsharp == 1)
				{
					num = Mods.projectilehashc2;
				}
				if (Mods.fuckyoucsharp == 2)
				{
					num = Mods.projectilehashc3;
				}
				if (Mods.fuckyoucsharp == 3)
				{
					num = Mods.projectilehashc4;
				}
				if (Mods.fuckyoucsharp == 4)
				{
					Mods.fuckyoucsharp = 0;
					num = Mods.projectilehashc1;
				}
			}
			else
			{
				num = Mods.projectilehash;
			}
			int num2 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
			GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
			{
				pos,
				vel,
				num,
				Mods.projectiletrailhash,
				false,
				num2,
				true,
				color.r,
				color.g,
				color.b,
				color.a
			});
			GameObject gameObject = ObjectPools.instance.Instantiate(num);
			SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
			if (Mods.projectiletrailhash != -1)
			{
				ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
			}
			component.Launch(pos, vel, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
			PhotonNetwork.SendAllOutgoingCommands();
			Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
		}

		public static void LauncherPlayerAura()
		{
			if (Mods.balll < Time.time)
			{
				Mods.balll = Time.time + 0.05f;
				foreach (Player player in PhotonNetwork.PlayerListOthers)
				{
					if (Vector3.Distance(RigShit.GetOwnVRRig().transform.position, GorillaGameManager.instance.FindPlayerVRRig(player).transform.position) < GorillaGameManager.instance.tagDistanceThreshold)
					{
						VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
						Vector3 vel = Vector3.zero;
						vel = vrrig.rightHandTransform.up.normalized * 7f;
						Mods.ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(vrrig.rightHandTransform.position, vel);
					}
				}
			}
		}

		public static void LauncherPlayerGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (Mods.gunLock)
				{
					if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, Mods.lockedrig.transform.position) > GorillaGameManager.instance.tagDistanceThreshold)
					{
						Vector3 position = Mods.lockedrig.transform.position - new Vector3(0f, 6f, 0f);
						GorillaTagger.Instance.offlineVRRig.transform.position = position;
						GorillaTagger.Instance.offlineVRRig.enabled = false;
					}
				}
				else if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, Mods.raycastHit.collider.GetComponentInParent<VRRig>().transform.position) > GorillaGameManager.instance.tagDistanceThreshold)
				{
					Vector3 position = Mods.raycastHit.collider.GetComponentInParent<VRRig>().transform.position - new Vector3(0f, 6f, 0f);
					GorillaTagger.Instance.offlineVRRig.transform.position = position;
					GorillaTagger.Instance.offlineVRRig.enabled = false;
				}
				if (WristMenu.triggerDownR && Time.time > Mods.balll2 + 0.05f)
				{
					int num = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
					int num2 = 1;
					if (Mods.cycle)
					{
						Mods.fuckyoucsharp++;
						if (Mods.fuckyoucsharp == 0)
						{
							num2 = Mods.projectilehashc1;
						}
						if (Mods.fuckyoucsharp == 1)
						{
							num2 = Mods.projectilehashc2;
						}
						if (Mods.fuckyoucsharp == 2)
						{
							num2 = Mods.projectilehashc3;
						}
						if (Mods.fuckyoucsharp == 3)
						{
							num2 = Mods.projectilehashc4;
						}
						if (Mods.fuckyoucsharp == 4)
						{
							Mods.fuckyoucsharp = 0;
							num2 = Mods.projectilehashc1;
						}
					}
					else
					{
						num2 = Mods.projectilehash;
					}
					Color color = Mods.projcolor;
					if (Mods.rainboww)
					{
						Mods.erm.transform.position = new Vector3(9999f, 9999f, 9999f);
						color = Mods.erm.GetComponent<ColorChanger>().color;
					}
					Vector3 vector = Vector3.zero;
					Vector3 up;
					if (!Mods.gunLock)
					{
						up = Mods.raycastHit.collider.GetComponentInParent<VRRig>().rightHandTransform.up;
					}
					else
					{
						up = Mods.lockedrig.rightHandTransform.up;
					}
					vector = up.normalized * 7f;
					Vector3 position2;
					if (Mods.gunLock)
					{
						position2 = Mods.lockedrig.rightHandTransform.position;
					}
					else
					{
						position2 = Mods.raycastHit.collider.GetComponentInParent<VRRig>().rightHandTransform.position;
					}
					GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 1, new object[]
					{
						position2,
						vector,
						num2,
						Mods.projectiletrailhash,
						false,
						num,
						true,
						color.r,
						color.g,
						color.b,
						color.a
					});
					GameObject gameObject = ObjectPools.instance.Instantiate(num2);
					SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
					if (Mods.projectiletrailhash != -1)
					{
						ObjectPools.instance.Instantiate(Mods.projectiletrailhash).GetComponent<SlingshotProjectileTrail>().AttachTrail(gameObject.gameObject, false, false);
					}
					component.Launch(position2, vector, PhotonNetwork.LocalPlayer, false, false, 0, 1f, true, color);
					PhotonNetwork.SendAllOutgoingCommands();
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
					return;
				}
			}
			else
			{
				Mods.lockedrig = null;
				GorillaTagger.Instance.offlineVRRig.enabled = true;
			}
		}

		public static void skiddedurdnabitch(Vector3 pos, Vector3 vel)
		{
		}

		public static void KickAllV3()
		{
			if (WristMenu.triggerDownL)
			{
				if (Mods.crashtp)
				{
					GorillaTagger.Instance.offlineVRRig.enabled = false;
					GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(-92.2935f, 45.3772f, -20.7123f);
				}
				Mods.KickDeps(1);
				Mods.KickDeps(1);
				PhotonNetwork.SendAllOutgoingCommands();
				return;
			}
			GorillaTagger.Instance.offlineVRRig.enabled = true;
		}

		public static void lefthand()
		{
			Mods.lefthandd = true;
		}

		public static void offlefthand()
		{
			Mods.lefthandd = false;
		}

		public static void KickGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				Player player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				if (!WristMenu.triggerDownR)
				{
					Mods.lockedrig = null;
					return;
				}
				if (Mods.gunLock)
				{
					if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
					{
						Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
					}
					Mods.pointer.transform.position = Mods.lockedrig.transform.position;
					player = RigShit.GetPlayerFromRig(Mods.lockedrig);
				}
				if (player != null && Time.time > Mods.balll2 + 0.95f)
				{
					Mods.balll2 = Time.time;
					PhotonNetworkController.Instance.shuffler = Random.Range(0, 99999999).ToString().PadLeft(8, '0');
					PhotonNetworkController.Instance.keyStr = Random.Range(0, 99999999).ToString().PadLeft(8, '0');
					if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(player.UserId) && GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
					{
						GorillaGameManager.instance.photonView.RPC("JoinPubWithFriends", player, new object[]
						{
							PhotonNetworkController.Instance.shuffler,
							PhotonNetworkController.Instance.keyStr
						});
						return;
					}
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		public static void KickAll()
		{
			if ((double)Time.time > (double)Mods.balll2 + 0.1)
			{
				Mods.balll2 = Time.time;
				if (PhotonNetwork.InRoom && !PhotonNetwork.CurrentRoom.IsVisible)
				{
					PhotonNetworkController.Instance.friendIDList = new List<string>(GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching);
					PhotonNetworkController.Instance.shuffler = Random.Range(0, 99999999).ToString().PadLeft(8, '0');
					PhotonNetworkController.Instance.keyStr = Random.Range(0, 99999999).ToString().PadLeft(8, '0');
					foreach (Player player in PhotonNetwork.PlayerList)
					{
						if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(player.UserId) && player != PhotonNetwork.LocalPlayer)
						{
							GorillaGameManager.instance.photonView.RPC("JoinPubWithFriends", player, new object[]
							{
								PhotonNetworkController.Instance.shuffler,
								PhotonNetworkController.Instance.keyStr
							});
						}
					}
					PhotonNetwork.SendAllOutgoingCommands();
					GorillaNetworkJoinTrigger forestMapTrigger = GorillaComputer.instance.forestMapTrigger;
				}
			}
		}

		public static void LagAll()
		{
			if (WristMenu.triggerDownL)
			{
				foreach (Player player in PhotonNetwork.PlayerList)
				{
					if (player.UserId != PhotonNetwork.LocalPlayer.UserId)
					{
						PhotonView viewFromPlayer = RigShit.GetViewFromPlayer(player);
						viewFromPlayer.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
						viewFromPlayer.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
						PhotonNetwork.Destroy(viewFromPlayer);
						PhotonNetwork.Destroy(viewFromPlayer.gameObject);
					}
				}
			}
		}

		public static void refection()
		{
			foreach (Player player in PhotonNetwork.PlayerListOthers)
			{
				MethodInfo method = typeof(PhotonNetwork).GetMethod("OpRemoveFromServerInstantiationsOfPlayer", BindingFlags.Instance | BindingFlags.NonPublic);
				if (method != null)
				{
					object[] parameters = new object[]
					{
						player.ActorNumber
					};
					method.Invoke(null, parameters);
				}
			}
		}

		public static void OFFSteamArms()
		{
			Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
		}

		public static void ReallyArms()
		{
			Player.Instance.transform.localScale = new Vector3(2f, 2f, 2f);
		}

		public static void MatSpamGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						Player player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR)
				{
					Player player;
					if (Mods.lockedrig != null)
					{
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					}
					foreach (Player player2 in PhotonNetwork.PlayerList)
					{
						if ((double)Time.time > (double)Mods.balll3 + 0.05)
						{
							Mods.balll3 = Time.time;
							foreach (GorillaTagManager gorillaTagManager in Object.FindObjectsOfType<GorillaTagManager>())
							{
								if (gorillaTagManager.photonView.IsMine)
								{
									if (new Random().Next(0, 2) == 1)
									{
										gorillaTagManager.AddInfectedPlayer(player);
										gorillaTagManager.AddInfectedPlayer(player);
										gorillaTagManager.AddInfectedPlayer(player);
										gorillaTagManager.AddInfectedPlayer(player);
										gorillaTagManager.AddInfectedPlayer(player);
										gorillaTagManager.AddInfectedPlayer(player);
										gorillaTagManager.AddInfectedPlayer(player);
										gorillaTagManager.AddInfectedPlayer(player);
									}
									else if (gorillaTagManager.currentInfected.Contains(player))
									{
										gorillaTagManager.currentInfected.Clear();
									}
									gorillaTagManager.ChangeCurrentIt(player, true);
									gorillaTagManager.SetisCurrentlyTag(true);
									gorillaTagManager.NewVRRig(player, player.ActorNumber, true);
									gorillaTagManager.isCurrentlyTag = true;
									gorillaTagManager.currentIt = player;
									gorillaTagManager.AddInfectedPlayer(player);
								}
							}
						}
					}
					return;
				}
				Mods.lockedrig = null;
			}
		}

		public static void POPFx()
		{
			if (Mods.aaa < Time.time)
			{
				Mods.aaa = Time.time + 0.2f;
				int num = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BalloonPopFX(Clone)"));
				GorillaNot.instance.logErrorMax = 999999;
				GorillaNot.instance.rpcErrorMax = 999999;
				GorillaNot.instance.rpcCallLimit = 999999;
				GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
				GorillaGameManager.instance.photonView.RpcSecure("LaunchSlingshotProjectile", 0, true, new object[]
				{
					Player.Instance.leftControllerTransform.transform.position,
					Player.Instance.currentVelocity,
					num,
					1848916225,
					false,
					1,
					false,
					0f,
					0f,
					0f,
					0f
				});
			}
			Mods.flushmanually();
		}

		public static void OFFReallyArms()
		{
			bool? enabled = WristMenu.buttons[24].enabled;
			bool flag = false;
			if (enabled.GetValueOrDefault() == flag & enabled != null)
			{
				Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}

		public static void InvisMonke()
		{
			if (!WristMenu.triggerDownL)
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				return;
			}
			GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(200f, 200f, 200f);
			GorillaTagger.Instance.offlineVRRig.enabled = false;
		}

		public static void copyclose()
		{
			Vector3 position = Player.Instance.transform.position;
			Mods.ClosestPlayer(position, out Mods.chosenplayer);
			if (Mods.chosenplayer != null)
			{
				if (!Mods.chosenplayer.isOfflineVRRig)
				{
					VRRig vrrig = Mods.chosenplayer;
					RigShit.GetOwnVRRig().enabled = false;
					RigShit.GetOwnVRRig().transform.position = vrrig.transform.position;
					RigShit.GetOwnVRRig().transform.rotation = vrrig.transform.rotation;
					RigShit.GetOwnVRRig().rightHandPlayer.transform.position = vrrig.rightHandPlayer.transform.position;
					RigShit.GetOwnVRRig().rightHandPlayer.transform.rotation = vrrig.rightHandPlayer.transform.rotation;
					RigShit.GetOwnVRRig().leftHandPlayer.transform.position = vrrig.leftHandPlayer.transform.position;
					RigShit.GetOwnVRRig().leftHandPlayer.transform.rotation = vrrig.leftHandPlayer.transform.rotation;
					RigShit.GetOwnVRRig().head.headTransform.transform.rotation = vrrig.head.headTransform.transform.rotation;
					RigShit.GetOwnVRRig().head.headTransform.transform.position = vrrig.head.headTransform.transform.position;
					GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = vrrig.headConstraint.rotation;
					return;
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = Player.Instance.headCollider.transform.rotation;
			}
		}

		public static void SexClosest()
		{
			Vector3 position = Player.Instance.transform.position;
			Mods.ClosestPlayer(position, out Mods.chosenplayer);
			if (Mods.chosenplayer != null)
			{
				if (!Mods.chosenplayer.isOfflineVRRig)
				{
					RigShit.GetOwnVRRig().enabled = false;
					if (Mods.sexint == 0)
					{
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 1f;
					}
					if (Mods.sexint == 1)
					{
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 1f;
					}
					if (Mods.sexint == 2)
					{
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 1f;
					}
					if (Mods.sexint == 3)
					{
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 0.5f;
					}
					if (Mods.sexint == 4)
					{
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 0.5f;
					}
					if (Mods.sexint == 5)
					{
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 0.5f;
					}
					if (Mods.sexint == 6)
					{
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 0.35f;
					}
					if (Mods.sexint == 7)
					{
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 0.35f;
					}
					Mods.sexint++;
					if (Mods.sexint >= 8)
					{
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 0.35f;
						Mods.sexint = 0;
					}
					GorillaTagger.Instance.offlineVRRig.transform.rotation = Mods.chosenplayer.transform.rotation;
					return;
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
			}
		}

		public static void copygun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.lockedrig != GorillaTagger.Instance.offlineVRRig || Mods.lockedrig == null)
					{
						if (Mods.lockedrig != null)
						{
							Mods.chosenplayer = Mods.lockedrig;
						}
						else
						{
							Mods.chosenplayer = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
					}
					if (!(Mods.chosenplayer != null))
					{
						GorillaTagger.Instance.offlineVRRig.enabled = true;
						GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = Player.Instance.headCollider.transform.rotation;
						return;
					}
					if (!Mods.chosenplayer.isOfflineVRRig)
					{
						VRRig vrrig = Mods.chosenplayer;
						RigShit.GetOwnVRRig().enabled = false;
						RigShit.GetOwnVRRig().transform.position = vrrig.transform.position;
						RigShit.GetOwnVRRig().transform.rotation = vrrig.transform.rotation;
						RigShit.GetOwnVRRig().rightHandPlayer.transform.position = vrrig.rightHandPlayer.transform.position;
						RigShit.GetOwnVRRig().rightHandPlayer.transform.rotation = vrrig.rightHandPlayer.transform.rotation;
						RigShit.GetOwnVRRig().leftHandPlayer.transform.position = vrrig.leftHandPlayer.transform.position;
						RigShit.GetOwnVRRig().leftHandPlayer.transform.rotation = vrrig.leftHandPlayer.transform.rotation;
						RigShit.GetOwnVRRig().head.headTransform.transform.rotation = vrrig.head.headTransform.transform.rotation;
						RigShit.GetOwnVRRig().head.headTransform.transform.position = vrrig.head.headTransform.transform.position;
						GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = vrrig.headConstraint.rotation;
						return;
					}
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.lockedrig = null;
			}
		}

		public static void SexGun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						if (Mods.lockedrig != null)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				if (Mods.lockedrig == null)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				if (WristMenu.triggerDownR)
				{
					if (Mods.lockedrig != GorillaTagger.Instance.offlineVRRig || Mods.lockedrig == null)
					{
						if (Mods.lockedrig != null)
						{
							Mods.chosenplayer = Mods.lockedrig;
						}
						else
						{
							Mods.chosenplayer = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
					}
					if (!(Mods.chosenplayer != null))
					{
						GorillaTagger.Instance.offlineVRRig.enabled = true;
						return;
					}
					if (!Mods.chosenplayer.isOfflineVRRig)
					{
						RigShit.GetOwnVRRig().enabled = false;
						if (Mods.sexint == 0)
						{
							GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 1f;
						}
						if (Mods.sexint == 1)
						{
							GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 0.5f;
						}
						if (Mods.sexint == 2)
						{
							GorillaTagger.Instance.offlineVRRig.transform.position = Mods.chosenplayer.transform.position - Mods.chosenplayer.transform.forward * 0.35f;
							Mods.sexint = 0;
						}
						GorillaTagger.Instance.offlineVRRig.transform.rotation = Mods.chosenplayer.transform.rotation;
						Mods.sexint++;
						return;
					}
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.lockedrig = null;
			}
		}

		public static void freezerig()
		{
			if (!WristMenu.triggerDownL)
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				return;
			}
			GorillaTagger.Instance.offlineVRRig.transform.position = Player.Instance.bodyCollider.transform.position;
			GorillaTagger.Instance.offlineVRRig.enabled = false;
		}

		public static void SpazMonk()
		{
			Random random = new Random();
			if (PhotonNetwork.InRoom)
			{
				RigShit.GetOwnVRRig().head.rigTarget.eulerAngles = new Vector3((float)random.Next(0, 360), (float)random.Next(0, 360), (float)random.Next(0, 360));
				RigShit.GetOwnVRRig().leftHand.rigTarget.eulerAngles = new Vector3((float)random.Next(0, 360), (float)random.Next(0, 360), (float)random.Next(0, 360));
				RigShit.GetOwnVRRig().rightHand.rigTarget.eulerAngles = new Vector3((float)random.Next(0, 360), (float)random.Next(0, 360), (float)random.Next(0, 360));
			}
		}

		public static void GhostMonke()
		{
			if (WristMenu.bbuttonDown)
			{
				if (!Mods.ghostToggled && GorillaTagger.Instance.offlineVRRig.enabled)
				{
					GorillaTagger.Instance.offlineVRRig.enabled = false;
					Mods.ghostToggled = true;
					return;
				}
				if (!Mods.ghostToggled && !GorillaTagger.Instance.offlineVRRig.enabled)
				{
					GorillaTagger.Instance.offlineVRRig.enabled = true;
					Mods.ghostToggled = true;
					return;
				}
			}
			else
			{
				Mods.ghostToggled = false;
			}
		}

		public static void lagadmingun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				Player player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					if (Mods.lockedrig == null)
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
					if (player.UserId != PhotonNetwork.LocalPlayer.UserId)
					{
						object[] array = new object[]
						{
							"Lag",
							PhotonNetwork.LocalPlayer,
							player
						};
						RaiseEventOptions raiseEventOptions = new RaiseEventOptions
						{
							Receivers = 0
						};
						PhotonNetwork.RaiseEvent(70, array, raiseEventOptions, SendOptions.SendReliable);
						return;
					}
				}
			}
			else
			{
				Mods.lockedrig = null;
				Object.Destroy(Mods.pointer);
			}
		}

		public static void kickadmingun()
		{
			if (WristMenu.gripDownR)
			{
				if (!MenusGUI.emulators)
				{
					if (Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null)
					{
						Mods.pointer = GameObject.CreatePrimitive(0);
						Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
						Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
						Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				Player player = RigShit.GetViewFromRig(Mods.raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				if (WristMenu.triggerDownR)
				{
					if (Mods.gunLock)
					{
						if (Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						player = RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					if (Mods.lockedrig == null)
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
					if (player.UserId != PhotonNetwork.LocalPlayer.UserId)
					{
						object[] array = new object[]
						{
							"kick",
							PhotonNetwork.LocalPlayer,
							player
						};
						RaiseEventOptions raiseEventOptions = new RaiseEventOptions
						{
							Receivers = 0
						};
						PhotonNetwork.RaiseEvent(70, array, raiseEventOptions, SendOptions.SendReliable);
						return;
					}
				}
			}
			else
			{
				Mods.lockedrig = null;
				Object.Destroy(Mods.pointer);
			}
		}

		public static void funnn()
		{
			if (Time.time > Mods.balll2111 + 0.01f && WristMenu.triggerDownL && PhotonNetwork.InRoom)
			{
				Mods.balll2111 = Time.time;
				Player[] playerListOthers = PhotonNetwork.PlayerListOthers;
				for (int i = 0; i < playerListOthers.Length; i++)
				{
					Mods.RaiseRpcEvents(playerListOthers[i]);
				}
			}
		}

		public static void DetectAdminsPanelFeatures(EventData eventData)
		{
			if (eventData.Code == 70)
			{
				object[] array = (object[])eventData.CustomData;
				if ((string)array[0] == "kick" && (Player)array[2] == PhotonNetwork.LocalPlayer && WristMenu.adminList.Contains(array[1]))
				{
					PhotonNetwork.Disconnect();
				}
				if ((string)array[0] == "Lag" && (Player)array[2] == PhotonNetwork.LocalPlayer && WristMenu.adminList.Contains(array[1]))
				{
					Thread.Sleep(500);
				}
			}
		}

		private static void PlatformsThing(bool invis, bool sticky)
		{
			Mods.colorKeysPlatformMonke[0].color = Color.red;
			Mods.colorKeysPlatformMonke[0].time = 0f;
			Mods.colorKeysPlatformMonke[1].color = Color.green;
			Mods.colorKeysPlatformMonke[1].time = 0.3f;
			Mods.colorKeysPlatformMonke[2].color = Color.blue;
			Mods.colorKeysPlatformMonke[2].time = 0.6f;
			Mods.colorKeysPlatformMonke[3].color = Color.red;
			Mods.colorKeysPlatformMonke[3].time = 1f;
			bool flag;
			bool flag2;
			if (!Mods.triggerplat)
			{
				flag = WristMenu.gripDownR;
				flag2 = WristMenu.gripDownL;
			}
			else
			{
				flag = WristMenu.triggerDownR;
				flag2 = WristMenu.triggerDownL;
			}
			if (Mods.toggleplat)
			{
				if (WristMenu.triggerDownL && !Mods.toggletoggletoggle)
				{
					Mods.toggleon = !Mods.toggleon;
					Mods.toggletoggletoggle = true;
					if (Mods.notifs && Mods.toggleon)
					{
						NotifiLib.SendNotification("Platforms Toggled On");
					}
					if (Mods.notifs && !Mods.toggleon)
					{
						NotifiLib.SendNotification("Platforms Toggled Off");
					}
				}
				else if (!WristMenu.triggerDownL)
				{
					Mods.toggletoggletoggle = false;
				}
			}
			else
			{
				Mods.toggleon = true;
			}
			if (flag && Mods.toggleon)
			{
				if (!Mods.once_right && Mods.jump_right_local == null)
				{
					if (sticky)
					{
						Mods.jump_right_local = GameObject.CreatePrimitive(0);
					}
					else
					{
						Mods.jump_right_local = GameObject.CreatePrimitive(3);
					}
					Mods.jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
					if (invis)
					{
						Object.Destroy(Mods.jump_right_local.GetComponent<Renderer>());
					}
					Mods.jump_right_local.transform.localScale = Mods.scale;
					Mods.jump_right_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position;
					Mods.jump_right_local.transform.rotation = Player.Instance.rightControllerTransform.rotation;
					object[] array = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position,
						Player.Instance.rightControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(70, array, raiseEventOptions, SendOptions.SendReliable);
					Mods.once_right = true;
					Mods.once_right_false = false;
					ColorChanger colorChanger = Mods.jump_right_local.AddComponent<ColorChanger>();
					colorChanger.colors = new Gradient
					{
						colorKeys = Mods.colorKeysPlatformMonke
					};
					colorChanger.Start();
				}
			}
			else if (!Mods.once_right_false && Mods.jump_right_local != null)
			{
				Object.Destroy(Mods.jump_right_local);
				Mods.jump_right_local = null;
				Mods.once_right = false;
				Mods.once_right_false = true;
				RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
				{
					Receivers = 0
				};
				PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
			}
			if (flag2 && Mods.toggleon)
			{
				if (!Mods.once_left && Mods.jump_left_local == null)
				{
					if (sticky)
					{
						Mods.jump_left_local = GameObject.CreatePrimitive(0);
					}
					else
					{
						Mods.jump_left_local = GameObject.CreatePrimitive(3);
					}
					Mods.jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
					if (invis)
					{
						Object.Destroy(Mods.jump_left_local.GetComponent<Renderer>());
					}
					Mods.jump_left_local.transform.localScale = Mods.scale;
					Mods.jump_left_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position;
					Mods.jump_left_local.transform.rotation = Player.Instance.leftControllerTransform.rotation;
					object[] array2 = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position,
						Player.Instance.leftControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(69, array2, raiseEventOptions3, SendOptions.SendReliable);
					Mods.once_left = true;
					Mods.once_left_false = false;
					ColorChanger colorChanger2 = Mods.jump_left_local.AddComponent<ColorChanger>();
					colorChanger2.colors = new Gradient
					{
						colorKeys = Mods.colorKeysPlatformMonke
					};
					colorChanger2.Start();
				}
			}
			else if (!Mods.once_left_false && Mods.jump_left_local != null)
			{
				Object.Destroy(Mods.jump_left_local);
				Mods.jump_left_local = null;
				Mods.once_left = false;
				Mods.once_left_false = true;
				RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
				{
					Receivers = 0
				};
				PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
			}
			if (!PhotonNetwork.InRoom)
			{
				for (int i = 0; i < Mods.jump_right_network.Length; i++)
				{
					Object.Destroy(Mods.jump_right_network[i]);
				}
				for (int j = 0; j < Mods.jump_left_network.Length; j++)
				{
					Object.Destroy(Mods.jump_left_network[j]);
				}
			}
		}

		public static bool oiwefkwenfjk;

		public static bool weuhfewh;

		public static bool spin;

		public static bool roll;

		public static bool back;

		public static bool upside;

		public static bool inSettings = false;

		public static bool invisplat = false;

		private static float delyatimer;

		private static bool epic;

		private static bool wieufhwf;

		private static GameObject rightHand;

		private static GameObject leftHand;

		private static GorillaPlayerScoreboardLine playersLine;

		public static GameObject pookiebear;

		public static float distance = 2f;

		public static float moveSpeed = 5f;

		public static Vector3[] positions = new Vector3[]
		{
			new Vector3(Mods.distance, 0f, Mods.distance),
			new Vector3(0f, 0f, Mods.distance),
			new Vector3(-Mods.distance, 0f, Mods.distance),
			new Vector3(Mods.distance, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(-Mods.distance, 0f, 0f),
			new Vector3(Mods.distance, 0f, -Mods.distance),
			new Vector3(0f, 0f, -Mods.distance),
			new Vector3(-Mods.distance, 0f, -Mods.distance)
		};

		public static int currentPositionIndex = 0;

		private static bool weijkfssweoifjeofjf1;

		private static bool weijkfssweoifjeofjf;

		public static string roomCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

		private static string name;

		private static bool OEIFJWEF;

		public static GameObject hand1;

		public static GameObject hand2;

		public static bool ghostToggled;

		public static List<string> namelist = new List<string>();

		private static bool eirsukdjyfj = false;

		public static RaycastHit raycastHit;

		private static bool baweiofjwf = true;

		private static Player beesPlayer;

		private static float smth46;

		private static bool stuiejrf1 = false;

		public static List<Player> playerCrashed = new List<Player>();

		private static bool antireportballs = false;

		private static float smth496;

		public static GradientColorKey[] colorKeysPlatformMonke9 = new GradientColorKey[3];

		public static GradientColorKey[] colorKeysPlatformMonke2 = new GradientColorKey[3];

		private static bool kowfjwefwjnef = false;

		public static float balll2111;

		public static float balll435342111;

		public static float balll21191;

		private static float balll21111;

		private static float balll2;

		private static float balll3;

		private static bool weufewfjdfjn111 = true;

		private static bool weufewfjdfjn1111 = true;

		private static bool weufewfjdfjn = true;

		private static bool widhcnkesdj = false;

		private static bool widhcnkesdj9 = false;

		private static bool widhcnkesdj1 = false;

		private static float ropedelay;

		private static float ropedelay1;

		private static bool stuiejrf2 = false;

		private static bool stuiejrf = true;

		private static bool stuiejrf99 = true;

		private static bool a = false;

		public static GameObject pointer;

		private static bool gunLock;

		private static int flySpeed = 17;

		public static int rattatuoie = 0;

		public static int fucking = 0;

		public static int fucking1 = 0;

		public static Color firstcolor = Color.black;

		private static int fucking2;

		private static Color projcolor = Color.black;

		private static bool erihu = false;

		private static int colorproj;

		private static int guntype;

		private static List<GameObject> leaves = new List<GameObject>();

		public static bool stickyplatforms = false;

		public static bool crashtp = true;

		public static bool cycle = false;

		public static bool fpcc = false;

		private static bool bothhands = false;

		private static GameObject funn;

		public static BetterDayNightManager.WeatherType ww;

		public static Color secondcolor = Color.yellow;

		public static int projectile = 0;

		public static int projectilehash = -820530352;

		public static int projectiletrail = 0;

		public static int projectiletrailhash = 1432124712;

		public static int projectilecycle1 = 0;

		public static int projectilehashc1 = -820530352;

		public static int projectilecycle2 = 0;

		public static int projectilehashc2 = -820530352;

		public static int projectilecycle3 = 0;

		public static int projectilehashc3 = -820530352;

		public static int projectilecycle4 = 0;

		public static int projectilehashc4 = -820530352;

		private static bool fasttrainbool;

		private static bool slowtrainbool;

		private static bool freezetrainbool;

		private static GradientColorKey[] ihate = new GradientColorKey[6];

		public static GameObject erm = null;

		public static bool rainboww = false;

		public static bool triggerplat = false;

		public static bool toggleplat = false;

		public static int platformstype = 0;

		private static int espcolor;

		private static int tracerscolor;

		private static int tracerspos;

		private static int speed;

		private static string flybutton = "rsec";

		public static bool notifs = true;

		private static float fillAmount;

		public static VRRig lockedrig;

		private static GorillaRopeSwing lockdedrope;

		public static Vector3[] lastLeft = new Vector3[]
		{
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero
		};

		public static Vector3[] lastRight = new Vector3[]
		{
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero
		};

		public static Color color;

		public static float hue = 0f;

		public static float timer = 0f;

		public static float updateRate = 0f;

		public static float updateTimer = 0f;

		public static bool RandomColor = false;

		public static float CycleSpeed = 0.07f;

		public static float GlowAmount = 1f;

		public static float monkeys;

		private static readonly RaiseEventOptions ServerCleanOptions = new RaiseEventOptions
		{
			CachingOption = 6
		};

		private static readonly Hashtable removeFilter = new Hashtable();

		private static readonly Hashtable ServerCleanDestroyEvent = new Hashtable();

		public static float gridSize = 2f;

		public static int gridCount = 3;

		private static GameObject funynwall;

		public static List<Vector3> wallpositions = new List<Vector3>();

		public static int wallposint = 1;

		private static Vector3 targetPosition;

		private static int currentGrid = 0;

		public static int fuckyoucsharp = 0;

		private static List<VRRig> validRigs = new List<VRRig>();

		private static RaycastHit[] rayResults = new RaycastHit[1];

		private static LayerMask layerMask;

		public static Quaternion t;

		public static GameObject rainbowcube;

		public static float orbitSpeed = 8f;

		private static float angle;

		private static Color pissColor = new Color(255f, 255f, 0f);

		private static Color cumColor = new Color(255f, 255f, 255f);

		public static GameObject obritthing;

		public float maxHorizontalDistance = 7f;

		public static float balll12111;

		public static bool fun = false;

		private static bool testgunvar;

		private static List<GameObject> testgunvarList;

		public static GameObject pointer2;

		private static float ieuzrjhm;

		private static bool shibaisblack;

		private static GameObject c4;

		public static string savedName = PhotonNetwork.NickName;

		public static bool lefthandd;

		private static float aaa;

		private static bool teleportGunAntiRepeat;

		private static bool iuwhewejn = false;

		public static float balll = 0f;

		private static VRRig chosenplayer = GorillaTagger.Instance.offlineVRRig;

		private static int sexint;

		private static bool gripDown_left;

		private static bool gripDown_right;

		public static bool toggleon = false;

		private static bool toggletoggletoggle;

		private static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);

		private static bool once_left;

		private static bool once_right;

		private static bool once_left_false;

		private static bool once_right_false;

		private static bool once_networking;

		private static GameObject[] jump_left_network = new GameObject[9999];

		private static GameObject[] jump_right_network = new GameObject[9999];

		private static GameObject jump_left_local = null;

		private static GameObject jump_right_local = null;

		private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];

		private static Vector3? checkpointPos;

		public class SkeletonESPClass : MonoBehaviour
		{
			private void Start()
			{
				this.lineRenderer = base.gameObject.AddComponent<LineRenderer>();
				this.lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				this.lineRenderer.startWidth = this.lineWidth;
				this.lineRenderer.endWidth = this.lineWidth;
			}

			private void Update()
			{
				this.DrawSkeleton();
			}

			private void OnDestroy()
			{
				this.ClearLineObjects();
			}

			public void DrawSkeleton()
			{
				this.ClearLineObjects();
				VRRig component = base.GetComponent<VRRig>();
				if (component == null)
				{
					Debug.LogWarning("niga");
					return;
				}
				Color color = component.mainSkin.material.color;
				if (Mods.SkeletonESPClass.RGBSkeletonESP)
				{
					color = this.GetAnimatedColor();
				}
				this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.35f, 0f), component.headMesh.transform.position, color);
				this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.headMesh.transform.up * 0.2f, color);
				this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * -0.15f, color);
				this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * 0.15f, color);
				this.DrawLine(component.headMesh.transform.position + component.transform.right * -0.15f, component.myBodyDockPositions.leftArmTransform.position, color);
				this.DrawLine(component.headMesh.transform.position + component.transform.right * 0.15f, component.myBodyDockPositions.rightArmTransform.position, color);
				this.DrawLine(component.myBodyDockPositions.leftArmTransform.position, component.leftHandTransform.position, color);
				this.DrawLine(component.myBodyDockPositions.rightArmTransform.position, component.rightHandTransform.position, color);
				this.DrawLine(component.rightHandTransform.position, component.rightThumb.fingerBone1.position, color);
				this.DrawLine(component.rightThumb.fingerBone1.position, component.rightThumb.fingerBone2.position, color);
				this.DrawLine(component.rightHandTransform.position, component.rightIndex.fingerBone1.position, color);
				this.DrawLine(component.rightIndex.fingerBone1.position, component.rightIndex.fingerBone2.position, color);
				this.DrawLine(component.rightIndex.fingerBone2.position, component.rightIndex.fingerBone3.position, color);
				this.DrawLine(component.rightHandTransform.position, component.rightMiddle.fingerBone1.position, color);
				this.DrawLine(component.rightMiddle.fingerBone1.position, component.rightMiddle.fingerBone2.position, color);
				this.DrawLine(component.rightMiddle.fingerBone2.position, component.rightMiddle.fingerBone3.position, color);
				this.DrawLine(component.leftHandTransform.position, component.leftThumb.fingerBone1.position, color);
				this.DrawLine(component.leftThumb.fingerBone1.position, component.leftThumb.fingerBone2.position, color);
				this.DrawLine(component.leftHandTransform.position, component.leftIndex.fingerBone1.position, color);
				this.DrawLine(component.leftIndex.fingerBone1.position, component.leftIndex.fingerBone2.position, color);
				this.DrawLine(component.leftIndex.fingerBone2.position, component.leftIndex.fingerBone3.position, color);
				this.DrawLine(component.leftHandTransform.position, component.leftMiddle.fingerBone1.position, color);
				this.DrawLine(component.leftMiddle.fingerBone1.position, component.leftMiddle.fingerBone2.position, color);
				this.DrawLine(component.leftMiddle.fingerBone2.position, component.leftMiddle.fingerBone3.position, color);
			}

			private Color GetAnimatedColor()
			{
				float time = Time.time;
				float num = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
				float num2 = Mathf.Sin(time * 1.5f) * 0.5f + 0.5f;
				float num3 = Mathf.Sin(time * 2.5f) * 0.5f + 0.5f;
				return new Color(num, num2, num3);
			}

			private void ClearLineObjects()
			{
				foreach (GameObject gameObject in this.lineObjects)
				{
					Object.Destroy(gameObject);
				}
				this.lineObjects.Clear();
			}

			private GameObject CreateLineObject()
			{
				GameObject gameObject = new GameObject("LineObject");
				gameObject.transform.SetParent(base.transform);
				this.lineObjects.Add(gameObject);
				return gameObject;
			}

			private void DrawLine(Vector3 startPos, Vector3 endPos, Color color)
			{
				LineRenderer lineRenderer = this.CreateLineObject().AddComponent<LineRenderer>();
				lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				lineRenderer.startColor = color;
				lineRenderer.endColor = color;
				lineRenderer.startWidth = this.lineWidth;
				lineRenderer.endWidth = this.lineWidth;
				lineRenderer.positionCount = 2;
				lineRenderer.SetPositions(new Vector3[]
				{
					startPos,
					endPos
				});
			}

			public Color lineColor = Color.white;

			public float lineWidth = 0.02f;

			private LineRenderer lineRenderer;

			private List<GameObject> lineObjects = new List<GameObject>();

			public static bool RGBSkeletonESP;
		}

		public class RGBSkeletonESPClass : MonoBehaviour
		{
			private void Start()
			{
				this.lineRenderer = base.gameObject.AddComponent<LineRenderer>();
				this.lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				this.lineRenderer.startWidth = this.lineWidth;
				this.lineRenderer.endWidth = this.lineWidth;
			}

			private void Update()
			{
				this.DrawSkeleton();
			}

			private void OnDestroy()
			{
				this.ClearLineObjects();
			}

			public void DrawSkeleton()
			{
				this.ClearLineObjects();
				VRRig component = base.GetComponent<VRRig>();
				if (component == null)
				{
					Debug.LogWarning("niga2");
					return;
				}
				Color animatedColor = this.GetAnimatedColor();
				this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.35f, 0f), component.headMesh.transform.position, animatedColor);
				this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.headMesh.transform.up * 0.2f, animatedColor);
				this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * -0.15f, animatedColor);
				this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * 0.15f, animatedColor);
				this.DrawLine(component.headMesh.transform.position + component.transform.right * -0.15f, component.myBodyDockPositions.leftArmTransform.position, animatedColor);
				this.DrawLine(component.headMesh.transform.position + component.transform.right * 0.15f, component.myBodyDockPositions.rightArmTransform.position, animatedColor);
				this.DrawLine(component.myBodyDockPositions.leftArmTransform.position, component.leftHandTransform.position, animatedColor);
				this.DrawLine(component.myBodyDockPositions.rightArmTransform.position, component.rightHandTransform.position, animatedColor);
				this.DrawLine(component.rightHandTransform.position, component.rightThumb.fingerBone1.position, animatedColor);
				this.DrawLine(component.rightThumb.fingerBone1.position, component.rightThumb.fingerBone2.position, animatedColor);
				this.DrawLine(component.rightHandTransform.position, component.rightIndex.fingerBone1.position, animatedColor);
				this.DrawLine(component.rightIndex.fingerBone1.position, component.rightIndex.fingerBone2.position, animatedColor);
				this.DrawLine(component.rightIndex.fingerBone2.position, component.rightIndex.fingerBone3.position, animatedColor);
				this.DrawLine(component.rightHandTransform.position, component.rightMiddle.fingerBone1.position, animatedColor);
				this.DrawLine(component.rightMiddle.fingerBone1.position, component.rightMiddle.fingerBone2.position, animatedColor);
				this.DrawLine(component.rightMiddle.fingerBone2.position, component.rightMiddle.fingerBone3.position, animatedColor);
				this.DrawLine(component.leftHandTransform.position, component.leftThumb.fingerBone1.position, animatedColor);
				this.DrawLine(component.leftThumb.fingerBone1.position, component.leftThumb.fingerBone2.position, animatedColor);
				this.DrawLine(component.leftHandTransform.position, component.leftIndex.fingerBone1.position, animatedColor);
				this.DrawLine(component.leftIndex.fingerBone1.position, component.leftIndex.fingerBone2.position, animatedColor);
				this.DrawLine(component.leftIndex.fingerBone2.position, component.leftIndex.fingerBone3.position, animatedColor);
				this.DrawLine(component.leftHandTransform.position, component.leftMiddle.fingerBone1.position, animatedColor);
				this.DrawLine(component.leftMiddle.fingerBone1.position, component.leftMiddle.fingerBone2.position, animatedColor);
				this.DrawLine(component.leftMiddle.fingerBone2.position, component.leftMiddle.fingerBone3.position, animatedColor);
			}

			private Color GetAnimatedColor()
			{
				float time = Time.time;
				float num = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
				float num2 = Mathf.Sin(time * 1.5f) * 0.5f + 0.5f;
				float num3 = Mathf.Sin(time * 2.5f) * 0.5f + 0.5f;
				return new Color(num, num2, num3);
			}

			private void ClearLineObjects()
			{
				foreach (GameObject gameObject in this.lineObjects)
				{
					Object.Destroy(gameObject);
				}
				this.lineObjects.Clear();
			}

			private GameObject CreateLineObject()
			{
				GameObject gameObject = new GameObject("LineObject");
				gameObject.transform.SetParent(base.transform);
				this.lineObjects.Add(gameObject);
				return gameObject;
			}

			private void DrawLine(Vector3 startPos, Vector3 endPos, Color color)
			{
				LineRenderer lineRenderer = this.CreateLineObject().AddComponent<LineRenderer>();
				lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				lineRenderer.startColor = color;
				lineRenderer.endColor = color;
				lineRenderer.startWidth = this.lineWidth;
				lineRenderer.endWidth = this.lineWidth;
				lineRenderer.positionCount = 2;
				lineRenderer.SetPositions(new Vector3[]
				{
					startPos,
					endPos
				});
			}

			public Color lineColor = Color.white;

			public float lineWidth = 0.02f;

			private LineRenderer lineRenderer;

			private List<GameObject> lineObjects = new List<GameObject>();

			public static bool RGBSkeletonESP;
		}
	}
}
