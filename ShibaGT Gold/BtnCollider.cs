using System;
using Displyy_Template.UI;
using UnityEngine;

internal class BtnCollider : MonoBehaviour
{
	private void OnTriggerEnter(Collider collider)
	{
		if (Time.frameCount >= BtnCollider.framePressCooldown + 20 && collider.name == "buttonPresser")
		{
			GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.1f);
			GorillaTagger.Instance.StartVibration(false, 0.01f, 0.001f);
			WristMenu.Toggle(this.relatedText);
			BtnCollider.framePressCooldown = Time.frameCount;
		}
	}

	public static int framePressCooldown;

	public string relatedText;
}
