using UnityEngine;

public class ClickRaycast : MonoBehaviour
{
    public Camera mainCamera;

    public GameObject[] cloneableObjects; 

    private GameObject selectedObject;

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
                    selectedObject = clickedObject;
                    Debug.Log("Selected object: " + selectedObject.name);
                }

                else if (hit.collider.CompareTag("Plane") && selectedObject != null)
                {
                    Instantiate(selectedObject, hit.point, Quaternion.identity);
                    Debug.Log("Created object at: " + hit.point);
                }
            }
        }
    }
}
