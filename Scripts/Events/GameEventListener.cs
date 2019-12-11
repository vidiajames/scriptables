
using UnityEngine;
using UnityEngine.Events;

namespace VideoJames.Scriptables.Events
{
	public class GameEventListener : MonoBehaviour, IEventListener
	{
		[SerializeField] private GameEvent gameEvent;
		[SerializeField] private UnityEvent response;

		protected virtual void OnEnable()
		{
			gameEvent.AddListener(this);
		}

		protected virtual void OnDisable()
		{
			gameEvent.RemoveListener(this);
		}

		public virtual void OnEventRaised()
		{
			response.Invoke();
		}
	}
}