using Audio;
using UnityEngine;
using UnityEngine.UI;
using SaveCar;

namespace Menu
{
    public class ButtonSaveCar : MonoBehaviour
    {
        private Button button;
        [SerializeField] private int id;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(HandleClick);
        }

        private void HandleClick()
        {
            Vehicle2 vehicle;
            if (GameManager.instance.GetVehicle.TryGetComponent<Vehicle2>(out vehicle))
            {
                SaveManager.Save(vehicle, id);
            }
        }
    }
}
