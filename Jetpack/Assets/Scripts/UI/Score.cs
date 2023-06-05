using UnityEngine;
using TMPro;

namespace Player
{
    /// <summary>
    /// A script used to display the distance traveled and the amount of fish collected.
    /// <remarks>Coded by Westley</remarks>
    /// </summary>
    public class Score : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private TextMeshProUGUI distanceScore;
        [SerializeField] private TextMeshProUGUI fishScore;
        private PlayerController _playerStats;

        void Start()
        {
            this._playerStats = this.gameObject.GetComponent<PlayerController>();
        }

        void Update()
        {
            // Updates the UI with distance traveled and fish collected scores.
            distanceScore.text = _playerStats.GetDistanceRun().ToString("0");
            fishScore.text = _playerStats.GetScore().ToString("0");
        }
    }
}