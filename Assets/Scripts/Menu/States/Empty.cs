using UnityEngine;

namespace Menu.States
{
    public class Empty : IMenuState
    {
        private readonly Menu menu;
        private readonly float maxTime;
        
        public Empty(Menu menu, float delayTime = 2.6f)
        {
            this.menu = menu;
            maxTime = Time.time + delayTime;
        }
        
        public void Enter() {}

        public void Update()
        {
            if (!(Time.time >= maxTime)) return;
            
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
        }
        
        public void Exit() {}
    }
}
