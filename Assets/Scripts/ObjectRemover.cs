using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    public Camera mainCamera;
    private string removableTag = "Removable";
    private string eraserTag = "Eraser";
    public bool isEraserSelected = false;
    void Start()
    {   
        if (mainCamera == null)
        {
            Debug.LogWarning("Main Camera not attached using Camera.main as fallback");
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(eraserTag))
            {
                isEraserSelected = true;
                Debug.Log("Eraser Selected");
            }

            else if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(removableTag) && isEraserSelected)
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("Destroyed object: " + hit.collider.gameObject);

            }
        }
    }
}
