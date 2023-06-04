using UnityEngine;
using TMPro;

/// <summary>
/// A class used to display the distance traveled and the amount of fish collected.
/// <remarks>Coded by Westley</remarks>
/// </summary>
public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI distanceScore;

    void Update()
    {
        distanceScore.text = player.position.x.ToString("0");
    }
}