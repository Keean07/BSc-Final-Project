using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera cam;

    private Vector3 plat1pos;
    private Quaternion plat1rot;

    private Vector3 plat2pos;
    private Quaternion plat2rot;

    // Start is called before the first frame update
    void Start()
    {
        plat1pos = new Vector3(0.0f, 14.0f, -4.0f);
        plat1rot = Quaternion.Euler(50.0f, 0.0f, 0.0f);

        plat2pos = new Vector3(0.0f, 25.0f, 4.5f);
        plat2rot = Quaternion.Euler(40.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CamToPlatform(int i)
    {
        if (i == 1)
        {
            cam.transform.position = plat1pos;
            cam.transform.rotation = plat1rot;
        }
        
        if (i == 2)
        {
            cam.transform.position = plat2pos;
            cam.transform.rotation = plat2rot;
        }
    }
}
