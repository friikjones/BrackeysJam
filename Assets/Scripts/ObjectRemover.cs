using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    public Camera mainCamera;
    public PlayerControllerScript playerController;
    private string removableTag = "Removable";
    private string eraserTag = "Eraser";
    private string eraserAction = "EraserAction";

    void Awake()
    {
        playerController = FindFirstObjectByType<PlayerControllerScript>();
    }
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
                playerController.selectedAction = eraserAction;
                Debug.Log("Eraser Selected");
            }

            else if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(removableTag) && playerController.selectedAction == eraserAction)
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("Destroyed object: " + hit.collider.gameObject);
            }
        }
    }
}