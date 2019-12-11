using UnityEngine;
using UnityEngine.UI;

namespace VideoJames.Scriptables.Examples
{
	[ExecuteInEditMode]
	public class ImageFillFloat : MonoBehaviour
	{
		[Header("Variables")]
		[SerializeField] private ScriptableValueFloat value;
		[SerializeField] private ScriptableValueFloat max;
		[SerializeField] private ReferenceFloat min;

		[Header("Components")] 
		[SerializeField] private Image image;

        private void OnEnable()
        {
            UpdateFill();
            value.OnValueUpdated += UpdateFill;
            max.OnValueUpdated += UpdateFill;
        }

        private void OnDisable()
        {
            value.OnValueUpdated -= UpdateFill;
            max.OnValueUpdated -= UpdateFill;
        }

        private void UpdateFill()
		{
			image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(min, max, value));
		}
	}
}