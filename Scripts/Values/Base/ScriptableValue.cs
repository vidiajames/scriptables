
using UnityEngine;

namespace VideoJames.Scriptables
{
    public class ScriptableValue<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        public delegate void ValueUpdated();
        public event ValueUpdated OnValueUpdated;

        [SerializeField] protected T initialValue;

        protected T runtimeValue;
        public T Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        protected virtual T GetValue()
        {
            return runtimeValue;
        }

        protected virtual void SetValue(T value)
        {
            runtimeValue = value;
            OnValueUpdated?.Invoke();
        }

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            AssignRuntimeValue();
        }

        protected virtual void AssignRuntimeValue()
        {
            runtimeValue = initialValue;
        }

        public static implicit operator T(ScriptableValue<T> scriptableValue)
        {
            return scriptableValue.Value;
        }
    }
}