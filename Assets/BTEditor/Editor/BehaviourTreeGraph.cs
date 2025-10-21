using System;
using UnityEditor;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor
{
    /// <summary>
    /// Represents a behaviour tree graph asset in the editor.
    /// </summary>
    [Graph(AssetExtension)]
    [Serializable]
    public class BehaviourTreeGraph : Graph
    {
        public const string AssetExtension = "btg";

        [MenuItem("Assets/Create/TBS Framework/Behaviour Tree Graph", false)]
        static void CreateAssetFile()
        {
            GraphDatabase.PromptInProjectBrowserToCreateNewAsset<BehaviourTreeGraph>();
        }
    }
}