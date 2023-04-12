using UnityEngine;

namespace Menu.States
{
    public class TooltipLevelList : IMenuState
    {
        private readonly Menu menu;

        public TooltipLevelList(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            menu.inGame.SetActive(true);
            menu.tooltipLevelList.SetActive(true);
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
