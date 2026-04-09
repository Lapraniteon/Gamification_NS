using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    
    public void ChangeScreen(string screenName)
    {
        foreach (RectTransform child in GetComponent<RectTransform>())
        {
            // Debug.Log(child.gameObject.name);
            child.gameObject.SetActive(screenName == child.gameObject.name);
        }
    }
}
