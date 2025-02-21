using UnityEngine;

public class KnobController : MonoBehaviour
{
    public Camera mainCamera;
    public string targetTag = "Knob";
    public float rotationSpeed = 50f;

    private GameObject selectedObject;
    private float lastMouseX;

    void Start()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Main Camera not attached adding Camera.main as fallback");
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("Ray: " + ray);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("SELECIONADO");
                selectedObject = hit.collider.gameObject;
                lastMouseX = Input.mousePosition.x;
                Debug.Log("Selected Object1: " + selectedObject);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Selected Object: NULL");
            selectedObject = null;
        }

        if (selectedObject != null)
        {
            float deltaX = Input.mousePosition.x - lastMouseX;
            float rotationY = -deltaX * rotationSpeed * Time.deltaTime;

            selectedObject.transform.Rotate(Vector3.up, rotationY, Space.World);

            lastMouseX = Input.mousePosition.x;
        }
    }
}
