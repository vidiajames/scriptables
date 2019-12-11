using UnityEngine;

namespace VideoJames.Scriptables.Persistance
{
    [CreateAssetMenu(menuName = "Scriptables/Persistant Int Value")]
    public class PersistantScriptableValueInt : ScriptableValueInt
    {
        [SerializeField] protected PersistanceManager persistanceManager;
        [SerializeField] protected string key;

        protected override int GetValue()
        {
            runtimeValue = persistanceManager ? GetPersistanctValue() : runtimeValue;
            return base.GetValue();
        }
        protected override void SetValue(int value)
        {
            SetPersistantValue(value);
            base.SetValue(value);
        }
        private int GetPersistanctValue()
        {
            if (!persistanceManager.HasKey(key))
            {
                Value = initialValue;
            }
            return persistanceManager.GetInt(key);
        }

        private void SetPersistantValue(int value)
        {
            persistanceManager.SetInt(key, value);
        }
    }
}