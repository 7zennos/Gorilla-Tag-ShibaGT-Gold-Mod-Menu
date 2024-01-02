using System;
using Displyy_Template.UI;
using GorillaLocomotion.Gameplay;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace dark.efijiPOIWikjek
{
	internal class RigShit : MonoBehaviour
	{
		public static VRRig GetRigFromPlayer(Player p)
		{
			return GorillaGameManager.instance.FindPlayerVRRig(p);
		}

		public static PhotonView GetViewFromPlayer(Player p)
		{
			return WristMenu.rig2view(GorillaGameManager.instance.FindPlayerVRRig(p));
		}

		public static VRRig GetOwnVRRig()
		{
			return GorillaTagger.Instance.offlineVRRig;
		}

		public static PhotonView GetViewFromRig(VRRig rig)
		{
			return WristMenu.rig2view(rig);
		}

		public static Player GetPlayerFromRig(VRRig rig)
		{
			return WristMenu.rig2view(rig).Owner;
		}

		public static GorillaRopeSwing GetPlayersRope(VRRig rig)
		{
			return (GorillaRopeSwing)Traverse.Create(rig).Field("currentRopeSwing").GetValue();
		}

		private float Distance2D(Vector3 a, Vector3 b)
		{
			Vector2 vector = new Vector2(a.x, a.z);
			Vector2 vector2;
			vector2..ctor(b.x, b.z);
			return Vector2.Distance(vector, vector2);
		}

		private bool PlayerNear(VRRig rig, float dist, out float playerDist)
		{
			if (rig == null)
			{
				playerDist = float.PositiveInfinity;
				return false;
			}
			playerDist = this.Distance2D(rig.transform.position, base.transform.position);
			return playerDist < dist && Physics.RaycastNonAlloc(new Ray(base.transform.position, rig.transform.position - base.transform.position), this.rayResults, playerDist, this.layerMask) <= 0;
		}

		private bool ClosestPlayer(in Vector3 myPos, out VRRig outRig)
		{
			this.layerMask = (UnityLayerExtensions.ToLayerMask(0) | UnityLayerExtensions.ToLayerMask(9));
			float num = float.MaxValue;
			outRig = null;
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				float num2 = 0f;
				if (this.PlayerNear(vrrig, GorillaGameManager.instance.tagDistanceThreshold, out num2) && num2 < num)
				{
					num = num2;
					outRig = vrrig;
				}
			}
			return num != float.MaxValue;
		}

		public static bool battleIsOnCooldown(VRRig rig)
		{
			return rig.mainSkin.material.name.Contains("hit");
		}

		public static Player GetRandomPlayer(bool includeSelf)
		{
			if (includeSelf)
			{
				Player player = PhotonNetwork.PlayerList[Random.Range(0, 11)];
				if (player != null)
				{
					return player;
				}
				return RigShit.GetRandomPlayer(includeSelf);
			}
			else
			{
				Player player2 = PhotonNetwork.PlayerListOthers[Random.Range(0, 10)];
				if (player2 != null)
				{
					return player2;
				}
				return RigShit.GetRandomPlayer(includeSelf);
			}
		}

		private RaycastHit[] rayResults = new RaycastHit[1];

		private LayerMask layerMask;
	}
}
