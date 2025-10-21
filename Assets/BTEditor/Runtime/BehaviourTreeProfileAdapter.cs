using TurnBasedStrategyFramework.Common.Controllers;
using TurnBasedStrategyFramework.Common.Units;
using TurnBasedStrategyFramework.Unity.AI.BehaviourTrees;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime
{
    /// <summary>
    /// Adapter that allows a BehaviourTreeProfile to be used as a BehaviourTreeResource.
    /// Wraps a profile and generates a concrete runtime tree.
    /// </summary>
    public class BehaviourTreeProfileAdapter : BehaviourTreeResource
    {
        [SerializeField] private BehaviourTreeProfile _profile;
        public override void Initialize(IUnit unit, IGridController gridController)
        {
            BehaviourTree = _profile.GetRuntimeTree(unit, gridController);
        }
    }
}