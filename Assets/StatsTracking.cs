using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsTracking : MonoBehaviour
{
    [Header("Stats")]
    public float totalCarbonSaved;
    public int currentLevel;

    [Header("XP Bar")] 
    [SerializeField] private Slider xpBar;
    [SerializeField] private TMP_Text carbonProgressToNextLevelText;
    [SerializeField] private TMP_Text totalCarbonAndTreesText;
    [Space] 
    [SerializeField] private TMP_Text currentLevelLabelText;
    [SerializeField] private TMP_Text nextLevelLabelText;
    [Space]
    [SerializeField] private float displayedCurrentXP;
    [SerializeField] private float xpToNextLevel;

    private void Update()
    {
        xpBar.maxValue = xpToNextLevel;

        if (!Mathf.Approximately(xpBar.value, displayedCurrentXP))
        {
            DOTween.To(() => xpBar.value, x => xpBar.value = x, displayedCurrentXP, 0.1f);
        }

        carbonProgressToNextLevelText.text = $"{displayedCurrentXP:n1}/{(int)xpToNextLevel} kg CO<sub>2</sub> <size=50%>to next lv.";

        totalCarbonAndTreesText.text = $"{(int)totalCarbonSaved}kg CO<sub>2</sub> saved!\nThat's {(int)(totalCarbonSaved / 25f)} trees!";
        
        currentLevelLabelText.text = currentLevel.ToString();
        nextLevelLabelText.text = (currentLevel + 1).ToString();
    }

    public void AddCarbonSaved(float value)
    {
        totalCarbonSaved += value;
        displayedCurrentXP += value;

        while (displayedCurrentXP >= 100f)
        {
            LevelUp();
            displayedCurrentXP -= 100f;
        }
    }
    
    [NaughtyAttributes.Button]
    private void Add1XP()
    {
        AddCarbonSaved(1f);
    }

    [NaughtyAttributes.Button]
    private void Add10XP()
    {
        AddCarbonSaved(10f);
    }

    private void LevelUp()
    {
        Debug.Log("Level up!");
        currentLevel++;
    }
}
