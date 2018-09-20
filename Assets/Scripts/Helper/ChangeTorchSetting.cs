using UnityEngine;

public class ChangeTorchSetting : MonoBehaviour {

    [ContextMenu("Change value")]
	public void Change()
    {
        AudioSource[] torches = GetComponentsInChildren<AudioSource>();

        for (int i = 0; i < torches.Length; i++)
        {
            torches[i].volume = 0.4f;
            torches[i].priority = 200;
            torches[i].spatialBlend = 1f;
            torches[i].rolloffMode = AudioRolloffMode.Linear;
            torches[i].minDistance = 0.4f;
            torches[i].maxDistance = 3f;

        }

        DestroyImmediate(this);
    }
}
