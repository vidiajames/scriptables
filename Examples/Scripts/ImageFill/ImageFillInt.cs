using UnityEngine;
using UnityEngine.UI;

namespace VideoJames.Scriptables.Examples
{
    [ExecuteInEditMode]
    public class ImageFillInt : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] private ReferenceInt value;
        [SerializeField] private ReferenceInt max;
        [SerializeField] private ReferenceInt min;

        [Header("Components")] 
        [SerializeField] private Image image;

        private void Update()
        {
            image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(min, max, value));
        }
    }
}