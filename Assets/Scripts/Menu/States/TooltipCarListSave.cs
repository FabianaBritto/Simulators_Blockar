using UnityEngine;

namespace Menu.States
{
    public class TooltipCarListSave : IMenuState
    {
        private readonly Menu menu;
        private static Menu _menu;
        public static Menu Menu => _menu;

        public TooltipCarListSave(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            _menu = menu;
            menu.inGarage.SetActive(true);
            menu.tooltipCarListSave.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            IMenuState newState = new InGarage(menu);
            menu.SetState(newState);
        }

        public void Exit() {}
    }
}
