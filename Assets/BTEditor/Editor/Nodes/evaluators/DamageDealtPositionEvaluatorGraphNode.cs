using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using System;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing a <see cref="DamageDealtPositionEvaluator"/>.
    /// </summary>
    [Serializable]
    public class DamageDealtPositionEvaluatorGraphNode : PositionEvaluatorGraphNode
    {
        public override RuntimePositionEvaluatorGraphNode ToRuntimeGraphNode()
        {
            var weightVariableValue = GraphNodeHelpers.GetVariableValueFromPort<float>(this, "weight");
            return new RuntimeDamageDealtPositionEvaluatorGraphNode(weightVariableValue);
        }
    }
}