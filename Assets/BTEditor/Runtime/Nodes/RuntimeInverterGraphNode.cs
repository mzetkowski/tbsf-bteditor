using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="InverterNode"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeInverterGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private RuntimeGraphNode _child;

        public RuntimeInverterGraphNode(RuntimeGraphNode child)
        {
            _child = child;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var child = _child.Process(parameters);
            return new InverterNode(child);
        }
    }
}