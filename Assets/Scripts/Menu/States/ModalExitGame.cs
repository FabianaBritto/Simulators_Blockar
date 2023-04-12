using UnityEngine;

namespace Menu.States
{
    public class ModalExitGame : IMenuState
    {
        private readonly Menu menu;

        public ModalExitGame(Menu menu)
        {
            this.menu = menu;
        }

        public void Enter()
        {
            menu.modalExitGame.SetActive(true);
            Time.timeScale = 0;
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
        }

        public void Exit()
        {
            Time.timeScale = 1;
        }
    }
}
