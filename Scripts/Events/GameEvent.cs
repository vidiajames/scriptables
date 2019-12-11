
using System.Collections.Generic;
using UnityEngine;

namespace VideoJames.Scriptables.Events
{
	[CreateAssetMenu(menuName = "Scriptables/Event")]
	public class GameEvent : ScriptableObject
	{
		private readonly List<IEventListener> listeners = new List<IEventListener>();

		public void RaiseEvent()
		{
			for (int i = listeners.Count - 1; i >= 0; i--)
			{
				listeners[i].OnEventRaised();
			}
		}

		public void AddListener(IEventListener listener)
		{
			listeners.Add(listener);
		}

		public void RemoveListener(IEventListener listener)
		{
			listeners.Remove(listener);
		}
	}
}