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

    [Header("Carbon Calculation")] 
    [SerializeField] private Vector2 previousStationPosition;

    private static StatsTracking _instance; // Game Manager singleton pattern
    public static StatsTracking Instance
    {
        get
        {
            if (_instance is null) // Error checking in case the Game Manager is not assigned
                Debug.LogError("GameManager is null!");

            return _instance;
        }
    } // Game Manager instance property

    private void Awake()
    {
        _instance = this;
    }
    
    private void Update()
    {
        xpBar.maxValue = xpToNextLevel;

        if (!Mathf.Approximately(xpBar.value, displayedCurrentXP))
        {
            DOTween.To(() => xpBar.value, x => xpBar.value = x, displayedCurrentXP, 0.1f);
        }

        carbonProgressToNextLevelText.text = $"{displayedCurrentXP:n1}/{(int)xpToNextLevel} kg CO<sub>2</sub> <size=50%>to next lv.";

        totalCarbonAndTreesText.text = $"{(int)totalCarbonSaved} kg CO<sub>2</sub> saved!\nThat's {(int)(totalCarbonSaved / 25f)} tree(s)!";
        
        currentLevelLabelText.text = currentLevel.ToString();
        nextLevelLabelText.text = (currentLevel + 1).ToString();
    }

    public void AddCarbonSaved(Vector2 newStationPosition)
    {
        float value = Vector2.Distance(newStationPosition, previousStationPosition);
        previousStationPosition = newStationPosition;
        
        value *= 0.0539457459926017f; // Fraction based on difference between pixel positions and actual carbon saves.
        
        totalCarbonSaved += value;
        displayedCurrentXP += value;

        while (displayedCurrentXP >= xpToNextLevel)
        {
            LevelUp();
            displayedCurrentXP -= xpToNextLevel;
        }
    }
    
    /*[NaughtyAttributes.Button]
    private void Add1XP()
    {
        AddCarbonSaved(1f);
    }

    [NaughtyAttributes.Button]
    private void Add10XP()
    {
        AddCarbonSaved(10f);
    }*/

    private void LevelUp()
    {
        Debug.Log("Level up!");
        currentLevel++;
    }
}
