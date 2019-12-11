
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VideoJames.Scriptables
{
	[Serializable]
	public class Reference{}

	[Serializable]
	public class Reference<T, G> : Reference where G : ScriptableValue<T>
	{
		public bool UseScriptableValue;
		public T ConstantValue;
		public G ScriptableValue;

		public T Value
		{
			get { return UseScriptableValue ? ScriptableValue : ConstantValue; }
			set
			{
				if (UseScriptableValue) ScriptableValue.Value = value;
				else ConstantValue = value;
			}
		}

		public static implicit operator T(Reference<T, G> reference)
		{
			return reference.Value;
		}
	}
}