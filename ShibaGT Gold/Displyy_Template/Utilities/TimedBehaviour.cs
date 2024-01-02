using System;
using UnityEngine;

namespace Displyy_Template.Utilities
{
	public class TimedBehaviour : MonoBehaviour
	{
		public virtual void Start()
		{
			this.startTime = Time.time;
		}

		public virtual void Update()
		{
			if (!this.complete)
			{
				this.progress = Mathf.Clamp((Time.time - this.startTime) / this.duration, 0f, 1f);
				if (Time.time - this.startTime > this.duration)
				{
					if (this.loop)
					{
						this.OnLoop();
						return;
					}
					this.complete = true;
				}
			}
		}

		public virtual void OnLoop()
		{
			this.startTime = Time.time;
		}

		public bool complete;

		public bool loop = true;

		public float progress;

		protected bool paused;

		protected float startTime;

		protected float duration = 2f;
	}
}
