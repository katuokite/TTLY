using UnityEngine;
using UnityEditor;

namespace AC
{

	[CustomEditor (typeof (Player))]
	public class PlayerEditor : CharEditor
	{

		public override void OnInspectorGUI ()
		{
			Player _target = (Player) target;
			
			SharedGUIOne (_target);
			SharedGUITwo (_target);

			SettingsManager settingsManager = AdvGame.GetReferences ().settingsManager;
			if (settingsManager && (settingsManager.hotspotDetection == HotspotDetection.PlayerVicinity || settingsManager.playerSwitching == PlayerSwitching.Allow))
			{
				EditorGUILayout.BeginVertical ("Button");
				EditorGUILayout.LabelField ("Player settings", EditorStyles.boldLabel);

				if (settingsManager.hotspotDetection == HotspotDetection.PlayerVicinity)
				{
					_target.hotspotDetector = (DetectHotspots) EditorGUILayout.ObjectField ("Hotspot detector child:", _target.hotspotDetector, typeof (DetectHotspots), true);
				}

				if (settingsManager.playerSwitching == PlayerSwitching.Allow)
				{
					_target.associatedNPCPrefab = (NPC) EditorGUILayout.ObjectField ("Associated NPC prefab:", _target.associatedNPCPrefab, typeof (NPC), false);
				}

				EditorGUILayout.EndVertical ();
			}
			
			UnityVersionHandler.CustomSetDirty (_target);
		}

	}

}