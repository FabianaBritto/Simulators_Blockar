using UnityEngine;

namespace Menu.States
{
    public class TooltipCredits : IMenuState
    {
        private readonly Menu menu;

        public TooltipCredits(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            Time.timeScale = 0;
            menu.openSettings.SetActive(true);
            menu.tooltipCredits.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
        }

        public void Exit() { Time.timeScale = 1;}
    }
}
