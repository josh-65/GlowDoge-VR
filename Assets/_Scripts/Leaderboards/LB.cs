using System.IO;
using UnityEngine;

namespace HomeJC.leaderboards
{
    public class LB : MonoBehaviour
    {
        [SerializeField] private Transform scoresTransform = null;
        [SerializeField] private GameObject scoreEntryObject = null;

        [SerializeField] LBEntryData testEntryData = new LBEntryData();

        //Change to github path. Currently local only.
        private string SavePath => $"{Application.persistentDataPath}/leaderboard_cache.json";

        private void Start()
        {
            LBSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);
            saveScores(savedScores);
        }

        [ContextMenu("Add Test Data")]
        public void AddTestEntry()
        {
            AddEntry(testEntryData);
        }

        public void AddEntry(LBEntryData lbEntryData) //Overwrite score if name is present
        {
            LBSaveData savedScores = GetSavedScores();
            bool scoreAdded = false;

            for(int i = 0; i < savedScores.score.Count; i ++)
            {
                if(lbEntryData.entryScore > savedScores.score[i].entryScore) 
                {
                    savedScores.score.Insert(i, lbEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if(!scoreAdded)
            {
                savedScores.score.Add(lbEntryData);
            }

            UpdateUI(savedScores);
            saveScores(savedScores);
        }

        private void UpdateUI(LBSaveData savedScores)
        {
            foreach(Transform child in scoresTransform)
            {
                Destroy(child.gameObject);
            }

            foreach(LBEntryData score in savedScores.score)
            {
                Instantiate(scoreEntryObject, scoresTransform).GetComponent<LBEntryUI>().Initialise(score);
            }
        }

        private LBSaveData GetSavedScores()
        {
            if(!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new LBSaveData();
            }

            using(StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<LBSaveData>(json);
            }
        }

        private void saveScores(LBSaveData lbSaveData)
        {
            using(StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(lbSaveData, true);
                stream.Write(json);
            }
        }
    }
}