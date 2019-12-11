using UnityEngine;

namespace VideoJames.Scriptables.Persistance
{
    [CreateAssetMenu(menuName = "Scriptables/Persistant Float Value")]
    public class PersistantScriptableValueFloat : ScriptableValueFloat
    {
        [SerializeField] protected PersistanceManager persistanceManager;
        [SerializeField] protected string key;

        protected override float GetValue()
        {            
            runtimeValue = persistanceManager ? GetPersistantValue() : runtimeValue;
            return base.GetValue();
        }
        protected override void SetValue(float value)
        {
            SetPersistantValue(value);
            base.SetValue(value);
        }
        private float GetPersistantValue()
        {
            if(!persistanceManager.HasKey(key))
            {
                Value = initialValue;
            }
            return persistanceManager.GetFloat(key);
        }

        private void SetPersistantValue(float value)
        {
            persistanceManager.SetFloat(key, value);
        }
    }
}