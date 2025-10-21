using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using TurnBasedStrategyFramework.Unity.Units;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing a health threshold node within the behavior tree editor.
    /// </summary>
    public class HealthThresholdGraphNode : BehaviourTreeGraphNode
    {
        public override RuntimeGraphNode ToRuntimeGraphNode()
        {
            var unitVariableValue = GraphNodeHelpers.GetVariableValueFromPort<Unit>(this, "unit");
            var thresholdVariableValue = GraphNodeHelpers.GetVariableValueFromPort<float>(this, "threshold");

            return new RuntimeHealthThresholdGraphNode(unitVariableValue, thresholdVariableValue);
        }

        protected override void OnDefineOptions(IOptionDefinitionContext context)
        {
            base.OnDefineOptions(context);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<float>("threshold").Build();
            context.AddInputPort<Unit>("unit").Build();
            context.AddInputPort("input").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
        }
    }
}
