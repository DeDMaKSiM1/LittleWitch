using UnityEngine;

public class TransSceneData : MonoBehaviour
{
    [SerializeField] private Transform previousSpawnPosition;
    public bool IsFirstInstance { get; private set; } = true;
    public SpawnComponent spawnComponent { get; private set; }
    public GameObject CharacterPrefab { get; private set; }
    public static TransSceneData Instance { get; private set; }
    public Transform PreviousSpawnPosition {
        get => previousSpawnPosition;
        private set
        {
            previousSpawnPosition = value;
        } 
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            IsFirstInstance = false;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CharacterPrefab = Resources.Load("Witch") as GameObject;
            spawnComponent = GetComponent<SpawnComponent>();
            spawnComponent.Spawn(CharacterPrefab, PreviousSpawnPosition.position);
        }
    }
    private void Start()
    {
        if (IsFirstInstance)
            IsFirstInstance = false;
    }

    public void PreviousSpawnPositionSave()
    {
        PreviousSpawnPosition = transform;
        Debug.Log(PreviousSpawnPosition);
    }
}
