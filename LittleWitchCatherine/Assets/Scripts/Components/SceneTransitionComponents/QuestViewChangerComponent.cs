using UnityEngine;

public class QuestViewChangerComponent : MonoBehaviour
{
    void Start()
    {
        var initialSceneName = PlayerPrefs.GetString("LocationName");
        var locationPrefab = Resources.Load($"QuestViewSprites/{initialSceneName}") as GameObject ;
        Instantiate(locationPrefab);
    }


}
