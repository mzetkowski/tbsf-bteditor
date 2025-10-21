using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing a turn delay within the behavior tree editor.
    /// </summary>
    public class DelayGraphNode : BehaviourTreeGraphNode
    {
        public override RuntimeGraphNode ToRuntimeGraphNode()
        {
            var delayVariableValue = GraphNodeHelpers.GetVariableValueFromPort<int>(this, "delay");
            var childNode = GraphNodeHelpers.GetChildNodeFromOutput(this, "output");
            
            return new RuntimeDelayGraphNode(delayVariableValue, childNode);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<int>("delay").WithConnectorUI(PortConnectorUI.Arrowhead).Build(); // The number of turns to delay before executing the child node.
            context.AddInputPort("input").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
            context.AddOutputPort("output").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
        }
    }
}
