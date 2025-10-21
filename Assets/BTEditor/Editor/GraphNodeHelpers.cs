using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor
{
    public static class GraphNodeHelpers
    {
        public static RuntimeValueReference<T> GetVariableValueFromPort<T>(Node node, string portName)
        {
            var variableValue = new RuntimeValueReference<T>();
            var port = node.GetInputPortByName(portName);

            if (port.isConnected)
            {
                var connectedPort = port.firstConnectedPort;
                switch (connectedPort.GetNode())
                {
                    case IVariableNode variableNode:
                        variableValue.PassedByVariable = true;
                        variableValue.VariableName = variableNode.variable.name;
                        break;
                    case IConstantNode constantNode:
                        constantNode.TryGetValue<T>(out var constantValue);
                        variableValue.Value = constantValue;
                        break;
                }
            }
            else
            {
                port.TryGetValue<T>(out var value);
                variableValue.Value = value;
            }

            return variableValue;
        }

        public static RuntimeGraphNode GetChildNodeFromOutput(BehaviourTreeGraphNode node, string portName)
        {
            var outputPort = node.GetOutputPortByName(portName);
            if (!outputPort.isConnected) return null;

            return (outputPort.firstConnectedPort.GetNode() as BehaviourTreeGraphNode)?.ToRuntimeGraphNode();
        }
    }
}