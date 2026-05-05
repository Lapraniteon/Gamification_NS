using NaughtyAttributes;
using UnityEngine;

public class StationPopupWidget : MapPopupWidget
{

    [SerializeField] public RectTransform carbonCalculationRect;
    [SerializeField] private StationUniqueInfoPanel stationInfoPanelPrefab;

    [Header("Values")] 
    [SerializeField] private float carbonKilos;
    
    public void SpawnInfoPanel()
    {
        Instantiate(stationInfoPanelPrefab, this.transform.parent);
    }

    public void AddCarbonKilos()
    {
        StatsTracking.Instance.AddCarbonSaved(carbonCalculationRect.transform.position);
    }
}
