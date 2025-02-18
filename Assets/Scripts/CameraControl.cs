using UnityEngine;
using UnityEngine.Animations;

public class CameraControl : MonoBehaviour
{
    public float cameraSpeed, cameraFinesse;
    public float maxRotation, minRotation;
    private float targetRotation = 180;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            if (targetRotation < maxRotation)
                targetRotation += cameraFinesse;
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (targetRotation > minRotation)
                targetRotation -= cameraFinesse;

        }
        // Debug.Log("target: " + targetRotation);
        // Debug.Log("current: " + transform.rotation.eulerAngles);
        transform.localRotation = Quaternion.Euler(Vector3.Lerp(transform.localRotation.eulerAngles, new Vector3(0, targetRotation, 0), Time.deltaTime * cameraSpeed));

    }
}
