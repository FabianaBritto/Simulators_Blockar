using Audio;
using Menu.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuStateDefine : MonoBehaviour
    {
        public static void SetInMainState()
        {
            IMenuState newState = new InMain(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetInGameState()
        {
            IMenuState newState = new InGame(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetInGameStateWithDelay()
        {
            IMenuState newState = new Empty(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetInGarageState()
        {
            IMenuState newState = new InGarage(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetGarageBlocksState()
        {
            IMenuState newState = new GarageBlocks(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetGarageEnginesState()
        {
            IMenuState newState = new GarageEngines(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetGarageWheelsState()
        {
            IMenuState newState = new GarageWheels(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetOpenSettingsState()
        {
            IMenuState newState = new OpenSettings(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetTooltipCreditsState()
        {
            IMenuState newState = Menu.Instance.tooltipCredits.activeInHierarchy
                ? new OpenSettings(Menu.Instance)
                : new TooltipCredits(Menu.Instance);
            
            Menu.Instance.SetState(newState);
        }
        
        public static void SetTooltipLevelListState()
        {
            IMenuState newState = Menu.Instance.tooltipLevelList.activeInHierarchy
                ? new InGame(Menu.Instance)
                : new TooltipLevelList(Menu.Instance);
            
            Menu.Instance.SetState(newState);
        }
        
        public static void SetTooltipCarListState()
        {
            IMenuState newState = Menu.Instance.tooltipCarList.activeInHierarchy
                ? new InGame(Menu.Instance)
                : new TooltipCarList(Menu.Instance);
            
            Menu.Instance.SetState(newState);
        }
        public static void SetTooltipCarListSaveState()
        {
            IMenuState newState = Menu.Instance.tooltipCarListSave.activeInHierarchy
                ? new InGarage(Menu.Instance)
                : new TooltipCarListSave(Menu.Instance);
            
            Menu.Instance.SetState(newState);
        }
        
        public static void SetModalExitGameState()
        {
            IMenuState newState = new ModalExitGame(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetModalDeleteCarState()
        {
            IMenuState newState = new ModalDeleteCar(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetEmptyState()
        {
            IMenuState newState = new Empty(Menu.Instance);
            Menu.Instance.SetState(newState);
        }

        public static void CloseTooltip()
        {
            IMenuState newState;
            
            if (Menu.Instance.settingsPanelIn == Menu.SettingsPanelIn.InGame)
                newState = new InGame(Menu.Instance);
            else
                newState = new InGarage(Menu.Instance);
            
            Menu.Instance.SetState(newState);
        }
        
        public static void ReloadLevel()
        {
            SetInGameStateWithDelay();
            //AudioManager.Instance.StopAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public static void QuitGame()
        {
            Application.Quit();
        }
    }
}
