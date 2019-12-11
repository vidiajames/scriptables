using UnityEngine;

namespace VideoJames.Scriptables.Persistance
{    public abstract class PersistanceManager : ScriptableObject
    {
        public abstract bool HasKey(string key);

        public abstract void SetString(string key, string value);
        public abstract string GetString(string key);

        public abstract void SetInt(string key, int value);
        public abstract int GetInt(string key);

        public abstract void SetFloat(string key, float value);
        public abstract float GetFloat(string key);
    }
}
