using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionListItem : MonoBehaviour
{
    [SerializeField] private Slider progressBar;

    [SerializeField] private TMP_Text percentageText;
    [SerializeField] private TMP_Text fractionText;

    private void Start()
    {
        OnBarValueChanged(progressBar.value);
    }
    
    public void ChangeProgress(float progress)
    {
        progressBar.value += progress;
        OnBarValueChanged(progressBar.value);
    }

    [NaughtyAttributes.Button]
    public void AddOne()
    {
        progressBar.value++;
        OnBarValueChanged(progressBar.value);
    }

    private void OnBarValueChanged(float value)
    {
        int percentage = (int)(value / progressBar.maxValue * 100);
        percentageText.text = percentage + "%";

        fractionText.text = $"{value}/{progressBar.maxValue}";
    }
}
