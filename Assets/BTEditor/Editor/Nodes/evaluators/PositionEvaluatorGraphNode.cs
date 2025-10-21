using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using TurnBasedStrategyFramework.Common.AI.Evaluators;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing a <see cref="IPositionEvaluator"/>.
    /// </summary>
    public abstract class PositionEvaluatorGraphNode : Node
    {
        public abstract RuntimePositionEvaluatorGraphNode ToRuntimeGraphNode();

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<float>("weight").Build();
            context.AddOutputPort("result").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
        }
    }
}