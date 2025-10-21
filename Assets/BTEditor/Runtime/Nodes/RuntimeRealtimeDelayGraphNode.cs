using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="RealtimeDelayNode"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeRealtimeDelayGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private RuntimeValueReference<float> _delayVariableValue;

        public RuntimeRealtimeDelayGraphNode(RuntimeValueReference<float> delayVariableValue) 
        {
            _delayVariableValue = delayVariableValue;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var delayValue = _delayVariableValue.PassedByVariable ? parameters[_delayVariableValue.VariableName].FloatValue : _delayVariableValue.Value;
            return new RealtimeDelayNode((int)delayValue);
        }
    }
}