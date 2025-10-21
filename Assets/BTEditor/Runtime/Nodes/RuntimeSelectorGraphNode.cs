using System;
using System.Collections.Generic;
using System.Linq;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="SelectorNode>"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public class RuntimeSelectorGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private List<RuntimeGraphNode> _children;

        public RuntimeSelectorGraphNode(List<RuntimeGraphNode> children)
        {
            _children = children;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            return new SelectorNode(_children.Select(x => x.Process(parameters)).ToList());
        }
    }
}