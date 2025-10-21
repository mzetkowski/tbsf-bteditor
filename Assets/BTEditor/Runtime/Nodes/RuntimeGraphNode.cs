using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Base class for all runtime behaviour tree graph nodes.
    /// Each derived node translates its editor counterpart into an executable ITreeNode,
    /// using provided variable bindings to resolve runtime parameters.
    /// </summary>
    [Serializable]
    public class RuntimeGraphNode
    {
        /// <summary>
        /// Builds an executable ITreeNode from this graph node,
        /// resolving variable references using the provided parameter bindings.
        /// </summary>
        /// <param name="parameters">Dictionary of bound profile variables.</param>
        /// <returns>Executable ITreeNode.</returns>
        public virtual ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters) { throw new NotImplementedException(); }
    }
}