using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }   

    public void AddStars(int amount)
    {
        this.stars += amount;
        UpdateDisplay();
    }

    public void SpendingStars(int amount)
    {
        if (amount <= this.stars)
        {
            this.stars -= amount;
        }
    }
    
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }
}
