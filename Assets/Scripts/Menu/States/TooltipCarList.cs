using UnityEngine;

namespace Menu.States
{
    public class TooltipCarList : IMenuState
    {
        private readonly Menu menu;

        public TooltipCarList(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            menu.inGame.SetActive(true);
            menu.tooltipCarList.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
        }

        public void Exit() {}
    }
}
