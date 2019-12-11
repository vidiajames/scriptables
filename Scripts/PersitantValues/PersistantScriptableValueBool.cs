using UnityEngine;

namespace VideoJames.Scriptables.Persistance
{
    [CreateAssetMenu(menuName = "Scriptables/Persistant Bool Value")]
    public class PersistantScriptableValueBool : ScriptableValueBool
    {
        [SerializeField] protected PersistanceManager persistanceManager;
        [SerializeField] protected string key;

        protected override bool GetValue()
        {            
            if(persistanceManager != null)
            {
                if(!persistanceManager.HasKey(key))
                {
                    Value = initialValue;
                }
                else
                {
                    runtimeValue = GetPersistantValue();
                }
            }            
            return base.GetValue();
        }
        protected override void SetValue(bool value)
        {
            SetPersistantValue(value);
            base.SetValue(value);
        }

        private bool GetPersistantValue()
        {
            if (!persistanceManager.HasKey(key))
            {
                Value = initialValue;
            }
            return persistanceManager.GetInt(key) == 1;
        }

        private void SetPersistantValue(bool value)
        {
            persistanceManager.SetInt(key, value ? 1 : 0);
        }
    }
}