using Audio;
using Menu.States;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        private IMenuState state;
        public static Menu Instance;

        public MenuDefaultState defaultState = MenuDefaultState.InGame; 
        private bool musicIsPlaying = true;
        
        public SettingsPanelIn settingsPanelIn = SettingsPanelIn.InGame;
        public enum SettingsPanelIn
        {
            InGame,
            InGarage
        }
        
        [Header("Menu Panels")]
        [SerializeField] public GameObject inMain;
        [SerializeField] public GameObject inGame;
        [SerializeField] public GameObject inGarage;
        
        [Header("Settings Panels")]
        [SerializeField] public GameObject buttonSettings;
        [SerializeField] public GameObject openSettings;
        [SerializeField] public GameObject tooltipCredits;
        [SerializeField] public GameObject tooltipCarList;
        [SerializeField] public GameObject tooltipCarListSave;
        [SerializeField] public GameObject tooltipLevelList;
        
        [Header("Modals Panels")]
        [SerializeField] public GameObject modalExitGame;
        [SerializeField] public GameObject modalDeleteCar;
        
        [Header("Garage Panels")]
        [SerializeField] public GameObject garageBlocks;
        [SerializeField] public GameObject garageEngines;
        [SerializeField] public GameObject garageWheels;
        
        [SerializeField] private GameObject[] musicButtons;

        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            SaveCar.SaveManager.LoadJSON();
        }

        private void Start()
        {
            IMenuState newState;
            switch (defaultState)
            {
                case MenuDefaultState.InMain:
                {
                    newState = new InMain(this);
                    break;
                }
                case MenuDefaultState.InGarage:
                {
                    newState = new InGarage(this);
                    break;
                }
                case MenuDefaultState.InGame:
                default:
                    newState = new InGame(this);
                    break;
            }
            
            SetState(newState);
        }

        private void Update()
        {
            state?.Update();

            if(!Input.GetMouseButtonDown(1)) return;
            SetCursor(0);
        }

        [SerializeField] Texture2D[] cursorTexture;
        CursorMode cursorMode = CursorMode.Auto;
        Vector2 hotSpot = Vector2.zero;

        public void SetCursor(int i)
        {
            Cursor.SetCursor(cursorTexture[i], hotSpot, cursorMode);
        }

        public void SetState(IMenuState newState)
        {
            state?.Exit();
            HiddenAllPanels();
            
            state = newState;
            state?.Enter();

            SetCursor(0);
        }

        private void HiddenAllPanels()
        {
            inMain.SetActive(false);
            inGame.SetActive(false);
            inGarage.SetActive(false);

            buttonSettings.SetActive(false);
            openSettings.SetActive(false);
            tooltipCredits.SetActive(false);
            tooltipCarList.SetActive(false);
            tooltipCarListSave.SetActive(false);
            tooltipLevelList.SetActive(false);

            modalExitGame.SetActive(false);
            modalDeleteCar.SetActive(false);

            garageBlocks.SetActive(false);
            garageEngines.SetActive(false);
            garageWheels.SetActive(false);
        }

        public void Audio()
        {
            musicIsPlaying = !musicIsPlaying;
            AudioManager.Instance.MuteMusic(!musicIsPlaying);

            musicButtons[musicIsPlaying ? 1 : 0].SetActive(false);
            musicButtons[musicIsPlaying ? 0 : 1].SetActive(true);
        }

        public void SetSettingsPanelInGame()
        {
            settingsPanelIn = SettingsPanelIn.InGame;
        }

        public void SetSettingsPanelInGarage()
        {
            settingsPanelIn = SettingsPanelIn.InGarage;
        }
    }
}
