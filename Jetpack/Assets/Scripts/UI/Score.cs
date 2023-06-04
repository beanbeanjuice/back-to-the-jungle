using UnityEngine;
using TMPro;

/// <summary>
/// A class used to display the distance traveled and the amount of fish collected.
/// <remarks>Coded by Westley</remarks>
/// </summary>
public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI distanceScore;
    private float initialPlayerPosition;
    private float distanceTraveled;

    void Start()
    {
        this.initialPlayerPosition = player.position.x;
    }

    void UpdateDistanceScore()
    {
        // Calculate the distance traveled and update the UI element.
        distanceTraveled = player.position.x - initialPlayerPosition;
        distanceScore.text = distanceTraveled.ToString("0");
    }

    void Update()
    {
        UpdateDistanceScore();
    }
}