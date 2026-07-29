using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using System;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing a <see cref="HealthTargetEvaluator"/>.
    /// </summary>
    [Serializable]
    public class HealthTargetEvaluatorGraphNode : TargetEvaluatorGraphNode
    {
        public override RuntimeTargetEvaluatorGraphNode ToRuntimeGraphNode()
        {
            var weightVariableValue = GraphNodeHelpers.GetVariableValueFromPort<float>(this, "weight");
            return new RuntimeHealthTargetEvaluatorGraphNode(weightVariableValue);
        }
    }
}