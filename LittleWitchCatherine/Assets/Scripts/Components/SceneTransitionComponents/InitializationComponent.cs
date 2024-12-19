using UnityEngine;

public class InitializationComponent : MonoBehaviour
{
    private QuestViewChangerComponent changer;
    void Start()
    {
        changer = GetComponent<QuestViewChangerComponent>();
        changer.ChangeView();
    }


}
