using System;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing the root of a behavior tree graph.
    /// </summary>
    [Serializable]
    public class RootGraphNode : BehaviourTreeGraphNode
    {
        public override RuntimeGraphNode ToRuntimeGraphNode()
        {
            RuntimeGraphNode childNode = null;
            var outputPort = GetOutputPort(0);
            if (outputPort.isConnected)
            {
                childNode = (outputPort.firstConnectedPort.GetNode() as BehaviourTreeGraphNode).ToRuntimeGraphNode();
            }

            return new RuntimeRootGraphNode(childNode);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddOutputPort("result").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
        }
    }
}
