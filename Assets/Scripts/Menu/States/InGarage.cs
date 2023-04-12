using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.States
{
    public class InGarage : IMenuState
    {
        private readonly Menu menu;

        public InGarage(Menu menu)
        {
            this.menu = menu; 
        }
        
        public void Enter()
        {
            menu.inGarage.SetActive(true);
            menu.garageBlocks.SetActive(true);
            menu.buttonSettings.SetActive(true);
            Menu.Instance.SetSettingsPanelInGarage();

            if (SceneManager.GetActiveScene().name != "SampleCarCreation")
            {
                SceneManager.LoadScene("SampleCarCreation");
                EditModeLevelController.BackToEditScene();
            }
        }

        public void Update()
        {
            IMenuState newState = null;

            if (Input.GetKeyDown(KeyCode.C))
            {
                newState = new InGame(menu);
                SceneManager.LoadScene(EditModeLevelController.instance.currentScene);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                newState = new OpenSettings(menu);
            }

            if (newState != null) menu.SetState(newState);
        }

        public void Exit() {}
    }
}
