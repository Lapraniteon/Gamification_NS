using DG.Tweening;
using UnityEngine;

public class Notification : MonoBehaviour
{
    
    [SerializeField] private RectTransform rectTransform;
    
    [NaughtyAttributes.Button]
    public void AnimateNotification()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOLocalMoveY(1102f + 272f, 0.25f));
        sequence.AppendInterval(3f);
        sequence.Append(rectTransform.DOLocalMoveY(1390f + 272f, 0.25f));
    }
}
