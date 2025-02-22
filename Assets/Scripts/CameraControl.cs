using UnityEngine;
using UnityEngine.Animations;

public class CameraControl : MonoBehaviour
{
    public float cameraSpeed, rotationFinesse, zoomFinesse;
    public float maxRotation, minRotation;
    public float maxDist, minDist;
    private float targetRotation = 180;
    private float targetDist = -10;
    private Transform cameraPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraPosition = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if (targetRotation < maxRotation)
                targetRotation += rotationFinesse;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (targetRotation > minRotation)
                targetRotation -= rotationFinesse;

        }
        if (Input.GetKey(KeyCode.S))
        {
            if (targetDist > maxDist)
                targetDist -= zoomFinesse;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (targetDist < minDist)
                targetDist += zoomFinesse;

        }
        // Debug.Log("target: " + targetRotation);
        // Debug.Log("current: " + transform.rotation.eulerAngles);
        transform.localRotation = Quaternion.Euler(Vector3.Lerp(transform.localRotation.eulerAngles, new Vector3(0, targetRotation, 0), Time.deltaTime * cameraSpeed));
        cameraPosition.localPosition = Vector3.Lerp(cameraPosition.localPosition, new Vector3(0, cameraPosition.localPosition.y, targetDist), Time.deltaTime * cameraSpeed);


    }
}
