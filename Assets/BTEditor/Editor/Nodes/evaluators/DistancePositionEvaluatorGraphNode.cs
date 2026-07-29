using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using System;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing a <see cref="DistancePositionEvaluator"/>.
    /// </summary>
    [Serializable]
    public class DistancePositionEvaluatorGraphNode : PositionEvaluatorGraphNode
    {
        public override RuntimePositionEvaluatorGraphNode ToRuntimeGraphNode()
        {
            var weightVariableValue = GraphNodeHelpers.GetVariableValueFromPort<float>(this, "weight");
            return new RuntimeDistancePositionEvaluatorGraphNode(weightVariableValue);
        }
    }
}