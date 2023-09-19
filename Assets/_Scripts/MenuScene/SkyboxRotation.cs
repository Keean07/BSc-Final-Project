using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    private Material skybox;
    public float rotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        skybox = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = Time.deltaTime * rotationSpeed;
        skybox.SetFloat("_Rotation", skybox.GetFloat("_Rotation") + rotationAmount);
    }
}
