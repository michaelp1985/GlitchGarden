using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public void AddStars(int stars)
    {
        FindObjectOfType<StarDisplay>().AddStars(stars);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
