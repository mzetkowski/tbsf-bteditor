using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="DelayNode"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeDelayGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private RuntimeValueReference<int> _delayVariableValue;
        [SerializeField] private RuntimeGraphNode _child;
        public RuntimeDelayGraphNode(RuntimeValueReference<int> delayVariableValue, RuntimeGraphNode child) 
        {
            _delayVariableValue = delayVariableValue;
            _child = child;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var delayValue = _delayVariableValue.PassedByVariable ? parameters[_delayVariableValue.VariableName].IntValue : _delayVariableValue.Value;
            var child = _child.Process(parameters);
            return new DelayNode(child, delayValue);
        }
    }
}