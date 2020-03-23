
using UnityEditor;
using UnityEngine;

namespace VideoJames.Scriptables.Editor
{
	[CustomPropertyDrawer(typeof(ReferenceInt))]
	public class ReferencePropertyDrawerInt : ReferencePropertyDrawer { }
	
	[CustomPropertyDrawer(typeof(ReferenceFloat))]
	public class ReferencePropertyDrawerFloat : ReferencePropertyDrawer { }
	
	[CustomPropertyDrawer(typeof(ReferenceString))]
	public class ReferencePropertyDrawerString : ReferencePropertyDrawer { }
	
	[CustomPropertyDrawer(typeof(ReferenceBool))]
	public class ReferencePropertyDrawerBool : ReferencePropertyDrawer { }
	
	[CustomPropertyDrawer(typeof(ReferenceVector2))]
	public class ReferencePropertyDrawerVector2 : ReferencePropertyDrawer { }

	[CustomPropertyDrawer(typeof(ReferenceVector3))]
	public class ReferencePropertyDrawerVector3 : ReferencePropertyDrawer { }

	[CustomPropertyDrawer(typeof(Reference), true)]
	public class ReferencePropertyDrawer : PropertyDrawer
	{
		private readonly string[] popupOptions = { "Use Scriptable Value", "Use Constant Value" };

		private GUIStyle popupStyle;
		private bool IsPopupStyleAssigned => popupStyle != null;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if(!IsPopupStyleAssigned)
			{
				AssignPopupStyle();
			}

			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, label);

			EditorGUI.BeginChangeCheck();

			SerializedProperty useScriptableValue = property.FindPropertyRelative("UseScriptableValue");
			SerializedProperty constantValue = property.FindPropertyRelative("ConstantValue");
			SerializedProperty scriptableValue = property.FindPropertyRelative("ScriptableValue");

			Rect buttonRect = new Rect(position);
			buttonRect.yMin += popupStyle.margin.top;
			buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
			buttonRect.xMin = buttonRect.xMin - popupStyle.fixedWidth;

			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			int result = EditorGUI.Popup(buttonRect, useScriptableValue.boolValue ? 0 : 1, popupOptions, popupStyle);

			useScriptableValue.boolValue = result == 0;

			EditorGUI.PropertyField(
				position,
				useScriptableValue.boolValue ? scriptableValue : constantValue,
				GUIContent.none);

			if(EditorGUI.EndChangeCheck())
			{
				property.serializedObject.ApplyModifiedProperties();
			}

			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();
		}

		void AssignPopupStyle()
		{
			popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
			popupStyle.imagePosition = ImagePosition.ImageOnly;
		}
	}
}
