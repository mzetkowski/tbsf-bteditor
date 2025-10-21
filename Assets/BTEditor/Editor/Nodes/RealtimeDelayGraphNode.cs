using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing a realtime delay node within the behavior tree editor.
    /// </summary>
    public class RealtimeDelayGraphNode : BehaviourTreeGraphNode
    {
        public override RuntimeGraphNode ToRuntimeGraphNode()
        {
            var delayVariableValue = GraphNodeHelpers.GetVariableValueFromPort<float>(this, "delay");
            return new RuntimeRealtimeDelayGraphNode(delayVariableValue);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<float>("delay").WithConnectorUI(PortConnectorUI.Arrowhead).Build();
            context.AddInputPort("input").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
        }
    }
}
