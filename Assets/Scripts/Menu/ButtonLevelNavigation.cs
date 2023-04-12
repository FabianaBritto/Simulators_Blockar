using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class ButtonLevelNavigation : MonoBehaviour
    {
        private Button button;
        [SerializeField] private Constants.Levels goToLevel;

        // Start is called before the first frame update
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(HandleClick);
        }

        // Update is called once per frame
        private void HandleClick()
        {
            //AudioManager.Instance.StopAll();
            SceneManager.LoadScene(goToLevel.ToString());
        }
    }
}
