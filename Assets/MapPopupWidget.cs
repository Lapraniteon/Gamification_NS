using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MapPopupWidget : MonoBehaviour
{
    [SerializeField] private RectTransform rt;
    
    private void OnEnable()
    {
        rt.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        rt.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
    }

    public void Disable()
    {
        StartCoroutine(DisableCoroutine());
    }

    private IEnumerator DisableCoroutine()
    {
        Tween tween = rt.DOScale(Vector3.zero, 0.2f).SetEase(Ease.OutCubic);
        yield return tween.WaitForCompletion();
        gameObject.SetActive(false);
    }
}
