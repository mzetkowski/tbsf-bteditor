using System.Collections.Generic;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing a selector node within the behavior tree editor.
    /// </summary>
    public class SelectorGraphNode : BehaviourTreeGraphNode
    {
        public override RuntimeGraphNode ToRuntimeGraphNode()
        {
            var children = new List<RuntimeGraphNode>();

            List<IPort> connectedPorts = new List<IPort>();
            GetOutputPortByName("children").GetConnectedPorts(connectedPorts);
            foreach (var port in connectedPorts)
            {
                var child = (port.GetNode() as BehaviourTreeGraphNode).ToRuntimeGraphNode();
                children.Add(child);
            }

            return new RuntimeSelectorGraphNode(children);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("input").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
            context.AddOutputPort("children").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
        }
    }
}