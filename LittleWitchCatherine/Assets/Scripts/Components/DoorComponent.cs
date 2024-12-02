using UnityEngine;

public class DoorComponent : MonoBehaviour
{
    [SerializeField] private bool IsExit;

    private Vector3 offset = new Vector3(1.5f, -0.8f, 0);
    private void Start()
    {
        if (TransSceneData.Instance.IsFirstInstance)
            return;
        if (!IsExit)
            TransSceneData.Instance.spawnComponent.Spawn(TransSceneData.Instance.CharacterPrefab, TransSceneData.Instance.PreviousSpawnPosition.position + offset);
        else
            TransSceneData.Instance.spawnComponent.Spawn(TransSceneData.Instance.CharacterPrefab, transform.position);
    }
}
