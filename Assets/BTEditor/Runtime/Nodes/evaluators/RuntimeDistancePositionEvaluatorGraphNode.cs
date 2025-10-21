using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="DistancePositionEvaluator"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeDistancePositionEvaluatorGraphNode : RuntimePositionEvaluatorGraphNode
    {
        [SerializeReference] private RuntimeValueReference<float> _weightVariableValue;

        public RuntimeDistancePositionEvaluatorGraphNode(RuntimeValueReference<float> weightVariableValue)
        {
            _weightVariableValue = weightVariableValue;
        }

        public override IPositionEvaluator GetEvaluator(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var weightValue = _weightVariableValue.PassedByVariable ? parameters[_weightVariableValue.VariableName].FloatValue : _weightVariableValue.Value;
            return new DistancePositionEvaluator(weightValue, 8);
        }
    }
}