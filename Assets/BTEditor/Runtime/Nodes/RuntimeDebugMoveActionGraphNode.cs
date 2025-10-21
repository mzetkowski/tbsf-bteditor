using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using UnityEngine;
using System;
using TurnBasedStrategyFramework.Unity.Units;
using TurnBasedStrategyFramework.Unity.AI.BehaviourTrees;
using TurnBasedStrategyFramework.Unity.Controllers;
using TurnBasedStrategyFramework.Common.Controllers;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="DebugMoveAction"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeDebugMoveActionGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private RuntimeValueReference<Unit> _unitVariableValue;
        [SerializeReference] private RuntimeValueReference<UnityGridController> _gridControllerVariableValue;
        [SerializeReference] private List<RuntimePositionEvaluatorGraphNode> _evaluatorsNodes;

        public RuntimeDebugMoveActionGraphNode(RuntimeValueReference<Unit> unitVariableValue, RuntimeValueReference<UnityGridController> gridControllerVariableValue, List<RuntimePositionEvaluatorGraphNode> evaluatorNodes)
        {
            _unitVariableValue = unitVariableValue;
            _gridControllerVariableValue = gridControllerVariableValue;
            _evaluatorsNodes = evaluatorNodes;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            Debug.Log("runitme debug move process");

            var unitReference = _unitVariableValue.PassedByVariable ? parameters[_unitVariableValue.VariableName].UnityObjectValue as Unit : _unitVariableValue.Value.GetComponent<Unit>();
            var gridController = _gridControllerVariableValue.PassedByVariable ? parameters[_gridControllerVariableValue.VariableName].ObjectValue as IGridController : _gridControllerVariableValue.Value.GetComponent<IGridController>();

            List<IPositionEvaluator> evaluators = new List<IPositionEvaluator>();
            foreach (var evaluatorNode in _evaluatorsNodes)
            {
                var evaluator = evaluatorNode.GetEvaluator(parameters);
                evaluators.Add(evaluator);
            }

            return new DebugMoveAction(unitReference, gridController, evaluators);
        }
    }
}