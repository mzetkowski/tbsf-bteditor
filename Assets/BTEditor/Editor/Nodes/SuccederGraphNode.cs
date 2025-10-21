using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor
{
    /// <summary>
    /// Editor graph node representing a succeder node within the behavior tree editor.
    /// </summary>
    public class SuccederGraphNode : BehaviourTreeGraphNode
    {
        public override RuntimeGraphNode ToRuntimeGraphNode()
        {
            RuntimeGraphNode childNode = GraphNodeHelpers.GetChildNodeFromOutput(this, "output");
            return new RuntimeSuccederGraphNode(childNode);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("input").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
            context.AddOutputPort("output").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
        }
    }
}