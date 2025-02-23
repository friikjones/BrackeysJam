using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float humidity, lightStrength, lightRatio;
    public Light mainLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string selectedAction = "";
    void Start()
    {
        // cameraControlScript = transform.GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            humidity++;
        }
        if (Input.GetKey(KeyCode.K))
        {
            humidity--;
        }
        if (Input.GetKey(KeyCode.J))
        {
            lightStrength++;
        }
        if (Input.GetKey(KeyCode.L))
        {
            lightStrength--;
        }
        humidity = Mathf.Clamp(humidity, 0, 100);
        lightStrength = Mathf.Clamp(lightStrength, 0, 100);

        mainLight.intensity = lightStrength * lightRatio;

    }
}
