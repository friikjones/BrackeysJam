using UnityEngine;

public class CloneObjectController : MonoBehaviour
{
    public Camera mainCamera;
    public PlayerControllerScript playerController;

    public GameObject[] cloneableObjects; 

    private GameObject selectedObject;
    private GameObject clonedObject;
    private string cloneAction = "cloneAction";

    void Awake()
    {
        playerController = FindFirstObjectByType<PlayerControllerScript>();
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
                    playerController.selectedAction = cloneAction;
                    selectedObject = clickedObject;
                    Debug.Log("Selected object: " + selectedObject.name);
                }

                else if (hit.collider.CompareTag("Plane") && selectedObject != null && playerController.selectedAction == cloneAction)
                {
                    clonedObject = Instantiate(selectedObject, hit.point, Quaternion.identity);
                    clonedObject.tag = "Removable";
                    Debug.Log("Created object at: " + hit.point);
                }
            }
        }
    }
}
