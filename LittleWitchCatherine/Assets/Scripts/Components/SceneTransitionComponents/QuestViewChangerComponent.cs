using UnityEngine;

public class QuestViewChangerComponent : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;
    public void ChangeView()
    {
        var initialSceneName = PlayerPrefs.GetString("LocationName");
        var locationPrefab = Resources.Load($"QuestViewLocation/{initialSceneName}") as GameObject;
        Instantiate(locationPrefab, parentTransform);
    }
}
