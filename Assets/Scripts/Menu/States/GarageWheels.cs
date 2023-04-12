using Audio;
using UnityEngine;

namespace Menu.States
{
    public class GarageWheels : IMenuState
    {
        private readonly Menu menu;

        public GarageWheels(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            //AudioManager.Instance.Stop("Motor");
            menu.inGarage.SetActive(true);
            menu.garageWheels.SetActive(true);
            
            OnMouseEnter();
        }

        [SerializeField] Texture2D cursorTexture;
        CursorMode cursorMode = CursorMode.Auto;
        Vector2 hotSpot = Vector2.zero;
        
        void OnMouseEnter()
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.C)) return;
            
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
        }

        public void Exit() {}
    }
}
