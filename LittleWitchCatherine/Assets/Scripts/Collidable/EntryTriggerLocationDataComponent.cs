using UnityEngine;

public class EntryTriggerLocationDataComponent : MonoBehaviour
{
    [SerializeField] private CatherineHouseLocationNames LocationNameToTransfer;
    public void SetScenePrefsData()
    { 
        PlayerPrefs.SetString("LocationName", LocationNameToTransfer.ToString());
    }
}
