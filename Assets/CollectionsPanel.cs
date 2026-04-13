using DG.Tweening;
using UnityEngine;

public class CollectionsPanel : MonoBehaviour
{
    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }
    
    public void SetPanelPosition(float targetPosition)
    {
        /*Vector2 pos = rt.anchoredPosition;
        pos.y = targetPosition;
        rt.anchoredPosition = pos;*/
        
        rt.DOAnchorPosY(targetPosition, 0.2f).SetEase(Ease.OutCubic);
    }
}
