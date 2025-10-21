using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="EnemyProximityPositionEvaluator"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeEnemyProximityPositionEvaluatorGraphNode : RuntimePositionEvaluatorGraphNode
    {
        [SerializeReference] private RuntimeValueReference<float> _weightVariableValue;

        public RuntimeEnemyProximityPositionEvaluatorGraphNode(RuntimeValueReference<float> weightVariableValue)
        {
            _weightVariableValue = weightVariableValue;
        }

        public override IPositionEvaluator GetEvaluator(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var weightValue = _weightVariableValue.PassedByVariable ? parameters[_weightVariableValue.VariableName].FloatValue : _weightVariableValue.Value;
            return new EnemyProximityPositionEvaluator(weightValue);
        }
    }
}