using UnityEngine;

public class StationPopupWidget : MapPopupWidget
{
    
    [SerializeField] private StationUniqueInfoPanel stationInfoPanelPrefab;
    
    public void SpawnInfoPanel()
    {
        Instantiate(stationInfoPanelPrefab, this.transform.parent);
    }
}
