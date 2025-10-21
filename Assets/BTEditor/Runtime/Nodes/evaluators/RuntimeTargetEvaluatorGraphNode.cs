using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.Evaluators;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="ITargetEvaluator"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public abstract class RuntimeTargetEvaluatorGraphNode
    {
        public abstract ITargetEvaluator GetEvaluator(Dictionary<string, ProfileVariableBinding> parameters);
    }
}