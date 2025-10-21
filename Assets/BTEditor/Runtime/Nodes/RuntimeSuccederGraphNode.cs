using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="SuccederNode>"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeSuccederGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private RuntimeGraphNode _child;

        public RuntimeSuccederGraphNode(RuntimeGraphNode child)
        {
            _child = child;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            var child = _child.Process(parameters);
            return new SuccederNode(child);
        }
    }
}