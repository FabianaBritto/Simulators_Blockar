using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class MenuSelector : MonoBehaviour
    {
        [Header("Level Destination")]
        [SerializeField] private Constants.Levels level;

        private MeshRenderer mesh;
        [SerializeField] private MenuSelectorScrObj materialStatus;
        [SerializeField] private bool isAvailableLevel;

        private void Start()
        {
            mesh = gameObject.GetComponent<MeshRenderer>();
            mesh.material = materialStatus.standard;

            isAvailableLevel = Status.Instance.IsAvailableLevel(level);
            if (isAvailableLevel == false) mesh.material = materialStatus.blocked;
        }

        private void OnMouseEnter()
        {
            if (isAvailableLevel) mesh.material = materialStatus.over;
        }

        private void OnMouseDown()
        {
            //AudioManager.Instance.StopAll();
            if (isAvailableLevel) SceneManager.LoadScene(level.ToString());
            if (!isAvailableLevel) isAvailableLevel = true;
        }

        private void OnMouseExit()
        {
            if (isAvailableLevel) mesh.material = materialStatus.standard;
        }
    }
}
