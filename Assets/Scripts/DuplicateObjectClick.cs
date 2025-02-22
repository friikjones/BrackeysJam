using UnityEngine;

public class ClickRaycast : MonoBehaviour
{
    public Camera mainCamera;
    public ObjectRemover objectRemover;
    public GameObject[] cloneableObjects; 
    private GameObject selectedObject;
    private GameObject clonedObject;

     void Awake()
    {
        objectRemover = FindFirstObjectByType<ObjectRemover>();
        Debug.Log("Check ObjectRemover instance", objectRemover);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {   
                GameObject clickedObject = hit.collider.gameObject;
                if (System.Array.Exists(cloneableObjects, obj => obj == clickedObject))
                {
                    objectRemover.isEraserSelected = false;
                    selectedObject = clickedObject;
                    Debug.Log("Selected object: " + selectedObject.name);
                }

                else if (hit.collider.CompareTag("Plane") && selectedObject != null && !objectRemover.isEraserSelected)
                {
                    clonedObject = Instantiate(selectedObject, hit.point, Quaternion.identity);
                    clonedObject.tag = "Removable";
                    Debug.Log("Created object at: " + hit.point);
                }
            }
        }
    }
}
