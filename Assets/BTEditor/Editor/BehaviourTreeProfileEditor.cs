using System;
using System.Linq;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime;
using UnityEditor;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor
{
    /// <summary>
    /// Custom inspector for BehaviourTreeProfile assets.
    /// Displays editable fields for all template variables, allowing users to assign values
    /// for a specific tree instance in the Unity editor.
    /// </summary>
    [CustomEditor(typeof(BehaviourTreeProfile))]
    public class BehaviourTreeProfileEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var profile = (BehaviourTreeProfile)target;
            if (profile._template == null)
            {
                EditorGUILayout.HelpBox("Assign a BehaviourTree template to view its variables.", MessageType.Info);
                return;
            }

            var vars = profile._template.Variables;
            if (vars == null || vars.Count == 0)
            {
                EditorGUILayout.LabelField("Template Variables", "None");
                return;
            }

            EditorGUILayout.LabelField("Template Variables", EditorStyles.boldLabel);

            foreach (var v in vars)
            {
                var name = v.Name;
                if(name.Equals("unitReference") || name.Equals("gridController"))
                {
                    continue;
                }
                var type = Type.GetType(v.TypeAssemblyQualifiedName);

                var vv = profile.variableValues.FirstOrDefault(x => x.VariableName == name);
                if (vv == null)
                {
                    vv = new ProfileVariableBinding { VariableName = name };
                    profile.variableValues.Add(vv);
                    EditorUtility.SetDirty(profile);
                }

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(name, GUILayout.MaxWidth(220));

                if (type == typeof(int))
                {
                    var newVal = EditorGUILayout.IntField(vv.IntValue);
                    if (newVal != vv.IntValue) { Undo.RecordObject(profile, "Edit Profile Int"); vv.IntValue = newVal; EditorUtility.SetDirty(profile); }
                }
                else if (type == typeof(float) || type == typeof(double))
                {
                    var newVal = EditorGUILayout.FloatField(vv.FloatValue);
                    if (Math.Abs(newVal - vv.FloatValue) > Mathf.Epsilon) { Undo.RecordObject(profile, "Edit Profile Float"); vv.FloatValue = newVal; EditorUtility.SetDirty(profile); }
                }
                else if (type == typeof(bool))
                {
                    var newVal = EditorGUILayout.Toggle(vv.BoolValue);
                    if (newVal != vv.BoolValue) { Undo.RecordObject(profile, "Edit Profile Bool"); vv.BoolValue = newVal; EditorUtility.SetDirty(profile); }
                }
                else if (type == typeof(string))
                {
                    var newVal = EditorGUILayout.TextField(vv.StringValue);
                    if (newVal != vv.StringValue) { Undo.RecordObject(profile, "Edit Profile String"); vv.StringValue = newVal; EditorUtility.SetDirty(profile); }
                }
                else if (type != null && typeof(UnityEngine.Object).IsAssignableFrom(type))
                {
                    var newObj = EditorGUILayout.ObjectField(vv.UnityObjectValue, type, true);
                    if (newObj != vv.UnityObjectValue) { Undo.RecordObject(profile, "Edit Profile Object"); vv.UnityObjectValue = newObj; EditorUtility.SetDirty(profile); }
                }
                else if (type != null && type.IsEnum)
                {
                    Enum current = (Enum)Enum.ToObject(type, vv.EnumIntValue);
                    Enum newEnum = EditorGUILayout.EnumPopup(current);
                    int newInt = Convert.ToInt32(newEnum);
                    if (newInt != vv.EnumIntValue) { Undo.RecordObject(profile, "Edit Profile Enum"); vv.EnumIntValue = newInt; EditorUtility.SetDirty(profile); }
                }
                else
                {
                    EditorGUILayout.LabelField($"Unsupported type: {v.TypeAssemblyQualifiedName}", GUILayout.MaxWidth(300));
                }

                EditorGUILayout.EndHorizontal();
            }
        }
    }
}
