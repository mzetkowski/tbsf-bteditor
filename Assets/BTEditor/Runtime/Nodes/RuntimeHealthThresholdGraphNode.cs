using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using TurnBasedStrategyFramework.Unity.Units;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="HealthThresholdNode"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeHealthThresholdGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private RuntimeValueReference<Unit> _unitVariableValue;
        [SerializeReference] private RuntimeValueReference<float> _thresholdVariableValue;

        public RuntimeHealthThresholdGraphNode(RuntimeValueReference<Unit> unitVariableValue, RuntimeValueReference<float> thresholdVariableValue)
        {
            _unitVariableValue = unitVariableValue;
            _thresholdVariableValue = thresholdVariableValue;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var unitValue = _unitVariableValue.PassedByVariable ? parameters[_unitVariableValue.VariableName].UnityObjectValue as Unit : _unitVariableValue.Value;
            var thresholdValue = _thresholdVariableValue.PassedByVariable ? parameters[_unitVariableValue.VariableName].FloatValue : _thresholdVariableValue.Value;

            HealthThresholdNode healthThresholdNode = new HealthThresholdNode(unitValue, thresholdValue);
            return healthThresholdNode;
        }
    }
}