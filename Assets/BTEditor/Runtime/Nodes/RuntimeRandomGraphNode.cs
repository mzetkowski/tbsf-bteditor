using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="RandomNode>"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeRandomGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private RuntimeValueReference<float> _probabilityVariableValue;

        public RuntimeRandomGraphNode(RuntimeValueReference<float> probabilityVariableValue)
        {
            _probabilityVariableValue = probabilityVariableValue;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var probabilityValue = _probabilityVariableValue.PassedByVariable ? parameters[_probabilityVariableValue.VariableName].FloatValue : _probabilityVariableValue.Value;
            return new RandomNode(new System.Random(), probabilityValue);
        }
    }
}