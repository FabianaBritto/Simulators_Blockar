using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookInput : MonoBehaviour
{
    private CinemachineFreeLook freeLookCamera;
    [SerializeField] private float speed = 2.0f;

    private string XAxisName = "Mouse X";
    private string YAxisName = "Mouse Y";

    // Start is called before the first frame update
    void Start()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();
        freeLookCamera.m_XAxis.m_InputAxisName = "";
        freeLookCamera.m_YAxis.m_InputAxisName = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (/* Input.GetKey(KeyCode.LeftAlt) &&  */Input.GetMouseButton(0))
        {
            freeLookCamera.m_XAxis.m_InputAxisValue = Input.GetAxis(XAxisName) * speed * Time.deltaTime;
            freeLookCamera.m_YAxis.m_InputAxisValue = Input.GetAxis(YAxisName) * speed * Time.deltaTime;
        }
        else
        {
            freeLookCamera.m_XAxis.m_InputAxisValue = 0;
            freeLookCamera.m_YAxis.m_InputAxisValue = 0;
        }
    }
}
