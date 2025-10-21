using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="HealthTargetEvaluator"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeHealthTargetEvaluatorGraphNode : RuntimeTargetEvaluatorGraphNode
    {
        [SerializeReference] private RuntimeValueReference<float> _weightVariableValue;

        public RuntimeHealthTargetEvaluatorGraphNode(RuntimeValueReference<float> weightVariableValue)
        {
            _weightVariableValue = weightVariableValue;
        }

        public override ITargetEvaluator GetEvaluator(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var weightValue = _weightVariableValue.PassedByVariable ? parameters[_weightVariableValue.VariableName].FloatValue : _weightVariableValue.Value;
            return new HealthTargetEvaluator(weightValue);
        }
    }
}