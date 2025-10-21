using System.Collections.Generic;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using TurnBasedStrategyFramework.Unity.Controllers;
using TurnBasedStrategyFramework.Unity.Units;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Editor graph node representing an attack action within the behavior tree editor.
    /// </summary>
    public class AttackActionGraphNode : BehaviourTreeGraphNode
    {
        public override RuntimeGraphNode ToRuntimeGraphNode()
        {
            List<IPort> connectedPorts = new List<IPort>();
            GetInputPortByName("evaluators").GetConnectedPorts(connectedPorts);

            List<RuntimeTargetEvaluatorGraphNode> evaluators = new List<RuntimeTargetEvaluatorGraphNode>();
            foreach (var port in connectedPorts)
            {
                var evaluator = (port.GetNode() as TargetEvaluatorGraphNode).ToRuntimeGraphNode();
                evaluators.Add(evaluator);
            }

            var unitVariableValue = GraphNodeHelpers.GetVariableValueFromPort<Unit>(this, "unit");
            var gridControllerVariableValue = GraphNodeHelpers.GetVariableValueFromPort<UnityGridController>(this, "gridController");

            return new RuntimeAttackActionGraphNode(unitVariableValue, gridControllerVariableValue, evaluators);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("evaluators").Build();
            context.AddInputPort<Unit>("unit").Build();
            context.AddInputPort<UnityGridController>("gridController").Build();
            context.AddInputPort("input").WithDisplayName(string.Empty).WithConnectorUI(PortConnectorUI.Arrowhead).Build();
        }
    }
}