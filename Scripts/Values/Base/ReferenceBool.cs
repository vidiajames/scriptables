using System;

namespace VideoJames.Scriptables
{
	[Serializable]
	public class ReferenceBool
	{
		public ScriptableValueBool ScriptableValue;
		public bool ConstantValue;
		public bool UseScriptableValue;

		private bool Value => UseScriptableValue ? ScriptableValue.Value : ConstantValue;
		
		public static implicit operator bool(ReferenceBool reference)
		{
			return reference.Value;
		}
	}
}