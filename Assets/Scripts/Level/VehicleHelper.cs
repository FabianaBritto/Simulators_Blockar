using UnityEngine;

public class VehicleHelper : MonoBehaviour
{
    public static int Vehicle { get; set; }
    private static VehicleHelper _instance;

    private void Awake()
    {
        if (_instance) Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
