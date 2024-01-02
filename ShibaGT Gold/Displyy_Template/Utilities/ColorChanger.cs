using System;
using UnityEngine;

namespace Displyy_Template.Utilities
{
	public class ColorChanger : TimedBehaviour
	{
		public override void Start()
		{
			base.Start();
			if (base.GetComponent<Renderer>() != null)
			{
				this.gameObjectRenderer = base.GetComponent<Renderer>();
			}
		}

		public override void Update()
		{
			base.Update();
			if (this.colors != null)
			{
				if (this.timeBased)
				{
					this.color = this.colors.Evaluate(this.progress);
				}
				this.gameObjectRenderer.material.color = this.color;
				this.gameObjectRenderer.material.SetColor("_EmissionColor", this.color);
			}
		}

		public Renderer gameObjectRenderer;

		public Gradient colors;

		public Color color;

		public bool timeBased = true;
	}
}
