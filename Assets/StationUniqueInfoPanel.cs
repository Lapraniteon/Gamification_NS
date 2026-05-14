using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class StationUniqueInfoPanel : MonoBehaviour
{
    private RectTransform rt;

    [SerializeField] private TMP_Text[] facts;
    private int activeIndex;
    
    private void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        
        foreach(var fact in facts)
            fact.gameObject.SetActive(false);

        activeIndex = UnityEngine.Random.Range(0, facts.Length);
        facts[activeIndex].gameObject.SetActive(true);
        
        rt.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        rt.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
    }

    public void ScrollIndex(int direction)
    {
        foreach(var fact in facts)
            fact.gameObject.SetActive(false);

        activeIndex += direction;
        if (activeIndex < 0) activeIndex = facts.Length - 1;
        if (activeIndex >= facts.Length) activeIndex = 0;
        facts[activeIndex].gameObject.SetActive(true);
    }

    public void Disable()
    {
        StartCoroutine(DisableCoroutine());
    }

    private IEnumerator DisableCoroutine()
    {
        Tween tween = rt.DOScale(Vector3.zero, 0.2f).SetEase(Ease.OutCubic);
        yield return tween.WaitForCompletion();
        Destroy(gameObject);
    }
}
