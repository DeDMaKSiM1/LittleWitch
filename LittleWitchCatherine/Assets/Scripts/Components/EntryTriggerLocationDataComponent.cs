using UnityEngine;

public class EntryTriggerLocationDataComponent : MonoBehaviour
{
    [SerializeField] LocationNames LocationNameToTransfer;
    public void SetScenePrefsData()
    { 
        PlayerPrefs.SetString("LocationName", LocationNameToTransfer.ToString());
    }
}
