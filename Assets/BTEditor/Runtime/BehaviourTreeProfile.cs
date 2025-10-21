using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using TurnBasedStrategyFramework.Common.Controllers;
using TurnBasedStrategyFramework.Common.Units;
using TurnBasedStrategyFramework.Unity.Units;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime
{
    /// <summary>
    /// Represents a concrete behaviour tree instance configured with specific parameter values.
    /// Wraps a BehaviourTreeRuntimeGraph template and injects variables and context to produce an executable tree.
    /// </summary>
    [CreateAssetMenu(fileName = "NewBehaviourTreeProfile", menuName = "TBS Framework/Behaviour Tree Profile")]
    public class BehaviourTreeProfile : ScriptableObject
    {
        public BehaviourTreeRuntimeGraph _template;
        [HideInInspector] public List<ProfileVariableBinding> variableValues = new List<ProfileVariableBinding>();

        public ITreeNode GetRuntimeTree(IUnit unitReference, IGridController gridController)
        {
            Dictionary<string, ProfileVariableBinding> parameters = new Dictionary<string, ProfileVariableBinding>();
            foreach(var variable in variableValues)
            {
                parameters[variable.VariableName] = variable;
            }
            parameters["unitReference"] = new ProfileVariableBinding() { VariableName = "unitReference", UnityObjectValue = unitReference as Unit };
            parameters["gridController"] = new ProfileVariableBinding() { VariableName = "gridController", ObjectValue = gridController };

            var runtimeTree = _template.GetRuntimeTree(parameters);
            return runtimeTree;
        }
    }

    /// <summary>
    /// Serialized container for a template variable's assigned value in a BehaviourTreeProfile.
    /// Used as the persisted source of profile values injected into the runtime parameters map.
    /// </summary>
    public class ProfileVariable { }
    [Serializable]
    public class ProfileVariableBinding
    {
        public string VariableName;
        public int IntValue;
        public float FloatValue;
        public bool BoolValue;
        public string StringValue;
        public UnityEngine.Object UnityObjectValue;
        public object ObjectValue;
        public int EnumIntValue;
    }
}