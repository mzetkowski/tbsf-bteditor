using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="DamageDealtTargetEvaluator"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeDamageDealtTargetEvaluatorGraphNode : RuntimeTargetEvaluatorGraphNode
    {
        [SerializeReference] private RuntimeValueReference<float> _weightVariableValue;

        public RuntimeDamageDealtTargetEvaluatorGraphNode(RuntimeValueReference<float> weightVariableValue)
        {
            _weightVariableValue = weightVariableValue;
        }

        public override ITargetEvaluator GetEvaluator(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var weightValue = _weightVariableValue.PassedByVariable ? parameters[_weightVariableValue.VariableName].FloatValue : _weightVariableValue.Value;
            return new DamageDealtTargetEvaluator(weightValue);
        }
    }
}