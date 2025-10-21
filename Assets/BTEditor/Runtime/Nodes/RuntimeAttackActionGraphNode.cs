using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using TurnBasedStrategyFramework.Common.Controllers;
using TurnBasedStrategyFramework.Unity.Controllers;
using TurnBasedStrategyFramework.Unity.Units;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates an <see cref="AttackSequenceNode"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeAttackActionGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private RuntimeValueReference<Unit> _unitVariableValue;
        [SerializeReference] private RuntimeValueReference<UnityGridController> _gridControllerVariableValue;
        [SerializeReference] private List<RuntimeTargetEvaluatorGraphNode> _evaluatorsNodes;

        public RuntimeAttackActionGraphNode(RuntimeValueReference<Unit> unitVariableValue, RuntimeValueReference<UnityGridController> gridControllerVariableValue, List<RuntimeTargetEvaluatorGraphNode> evaluatorNodes)
        {
            _unitVariableValue = unitVariableValue;
            _gridControllerVariableValue = gridControllerVariableValue;
            _evaluatorsNodes = evaluatorNodes;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var unitReference = _unitVariableValue.PassedByVariable ? parameters[_unitVariableValue.VariableName].UnityObjectValue as Unit : _unitVariableValue.Value.GetComponent<Unit>();
            var gridController = _gridControllerVariableValue.PassedByVariable ? parameters[_gridControllerVariableValue.VariableName].ObjectValue as IGridController : _gridControllerVariableValue.Value.GetComponent<IGridController>();

            List<ITargetEvaluator> evaluators = new List<ITargetEvaluator>();
            foreach (var evaluatorNode in _evaluatorsNodes)
            {
                var evaluator = evaluatorNode.GetEvaluator(parameters);
                evaluators.Add(evaluator);
            }

            return new AttackSequenceNode(unitReference, gridController, evaluators);
        }
    }
}