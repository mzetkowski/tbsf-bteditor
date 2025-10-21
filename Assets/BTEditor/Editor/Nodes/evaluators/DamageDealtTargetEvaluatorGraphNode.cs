using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using TurnBasedStrategyFramework.Common.AI.Evaluators;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing a <see cref="DamageDealtTargetEvaluator"/>.
    /// </summary>
    public class DamageDealtTargetEvaluatorGraphNode : TargetEvaluatorGraphNode
    {
        public override RuntimeTargetEvaluatorGraphNode ToRuntimeGraphNode()
        {
            var weightVariableValue = GraphNodeHelpers.GetVariableValueFromPort<float>(this, "weight");
            return new RuntimeDamageDealtTargetEvaluatorGraphNode(weightVariableValue);
        }
    }
}