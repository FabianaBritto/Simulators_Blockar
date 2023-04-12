using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class LevelListSwitch : MonoBehaviour
    {
        [SerializeField] private int activeList;
        [SerializeField] private Text activeListName;
        [SerializeField] private GameObject[] levelPanels;

        private void Start()
        {
            HiddenPanels();
            UpdateActivePanel();
        }

        private void HiddenPanels()
        {
            foreach (var panel in levelPanels)
            {
                panel.SetActive(false);
            }
        }

        public void PreviousPanel()
        {
            levelPanels[activeList].SetActive(false);
            
            activeList--;
            if (activeList < 0) activeList = levelPanels.Length - 1;
            
            UpdateActivePanel();
        }

        public void NextPanel()
        {
            levelPanels[activeList].SetActive(false);
            
            activeList++;
            if (activeList == levelPanels.Length) activeList = 0;
            
            UpdateActivePanel();
        }

        private void UpdateActivePanel()
        {
            levelPanels[activeList].SetActive(true);
            activeListName.text = levelPanels[activeList].name;
        }
    }
}
