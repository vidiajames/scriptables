
using UnityEngine;

namespace VideoJames.Scriptables.Persistance
{
    [CreateAssetMenu(menuName = "Managers/Player Prefs Persistance")]

    public class PlayerPrefsPersistanceManager : PersistanceManager
    {
        public override bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public override float GetFloat(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }
        public override void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        public override int GetInt(string key)
        {
            return PlayerPrefs.GetInt(key);
        }
        public override void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public override string GetString(string key)
        {
            return PlayerPrefs.GetString(key);
        }
        public override void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }
    }
}