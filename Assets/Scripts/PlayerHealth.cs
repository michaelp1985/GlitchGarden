using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 5;
    Text healthText;

    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void TakeDamage(int damage)
    {
        if (health > damage)
        {
            this.health -= damage;
            UpdateDisplay();
        }
        else
        {
            PlayerDies();
        }
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void PlayerDies()
    {        
        FindObjectOfType<LevelController>().HandleLoseCondition();
    }
}
