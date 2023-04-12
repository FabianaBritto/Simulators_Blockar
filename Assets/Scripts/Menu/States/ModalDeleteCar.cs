using UnityEngine;

namespace Menu.States
{
    public class ModalDeleteCar : IMenuState
    {
        private readonly Menu menu;
        
        public ModalDeleteCar(Menu menu)
        {
            this.menu = menu;
        }

        public void Enter()
        {
            menu.modalDeleteCar.SetActive(true);
            Time.timeScale = 0;
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            IMenuState newState = new InGarage(menu);
            menu.SetState(newState);
        }

        public void Exit()
        {
            Time.timeScale = 1;
        }
    }
}
