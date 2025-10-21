using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing random node within the behavior tree editor.
    /// </summary>
    public class RandomGraphNode : BehaviourTreeGraphNode
    {
        public override RuntimeGraphNode ToRuntimeGraphNode()
        {
            var probabilityVariableValue = GraphNodeHelpers.GetVariableValueFromPort<float>(this, "probability");
            return new RuntimeRandomGraphNode(probabilityVariableValue);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<float>("probability").WithConnectorUI(PortConnectorUI.Arrowhead).Build();
            context.AddInputPort("input").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
            context.AddOutputPort("output").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
        }
    }
}
