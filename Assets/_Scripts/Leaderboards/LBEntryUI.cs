using TMPro;
using UnityEngine;

namespace HomeJC.leaderboards
{
    public class LBEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;

        public void Initialise(LBEntryData lbEntryData)
        {
            entryNameText.text = lbEntryData.entryName;
            entryScoreText.text = lbEntryData.entryScore.ToString();
        }

    }
}