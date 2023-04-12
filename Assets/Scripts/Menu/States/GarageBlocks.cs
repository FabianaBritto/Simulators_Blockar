using Audio;
using UnityEngine;

namespace Menu.States
{
    public class GarageBlocks : IMenuState
    {
        private readonly Menu menu;

        public GarageBlocks(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            //AudioManager.Instance.Stop("Motor");
            menu.inGarage.SetActive(true);
            menu.garageBlocks.SetActive(true);
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
