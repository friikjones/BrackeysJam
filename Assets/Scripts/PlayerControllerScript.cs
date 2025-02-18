using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float humidity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // cameraControlScript = transform.GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            humidity++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            humidity--;
        }
        humidity = Mathf.Clamp(humidity, 0, 100);

    }
}
