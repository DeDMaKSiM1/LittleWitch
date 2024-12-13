using UnityEngine;

public class EntryTriggerLocationDataComponent : MonoBehaviour
{
    [SerializeField] private LocationNames LocationNameToTransfer;
    public void SetScenePrefsData()
    { 
        PlayerPrefs.SetString("LocationName", LocationNameToTransfer.ToString());
    }
}
