using UnityEngine;

public class KnobController : MonoBehaviour
{
    public Camera mainCamera;
    public PlayerControllerScript playerController;
    public ObjectRemover objectRemover;

    public LayerMask knobLayer;
    public float rotationSpeed = 1f;
    public float maxRotation = 150f; 
    private string knobTag = "";

    private GameObject selectedKnob;
    private float lastMouseY;
    private bool isDragging = false;
    private float currentRotation = 0f;
    public float minControlValue = 1f;
    public float maxControlValue = 100f;

    void Awake()
    {
        playerController = FindFirstObjectByType<PlayerControllerScript>();
        objectRemover = FindFirstObjectByType<ObjectRemover>();
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

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, knobLayer))
            {   
                objectRemover.isEraserSelected = false;
                knobTag = hit.collider.tag;
                selectedKnob = hit.collider.gameObject;
                lastMouseY = Input.mousePosition.y;
                isDragging = true;
                currentRotation = selectedKnob.transform.localRotation.eulerAngles.z;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedKnob = null;
            isDragging = false;
        }

        if (isDragging && selectedKnob != null)
        {
            float deltaY = lastMouseY - Input.mousePosition.y;
            float rotationDelta = deltaY * rotationSpeed;

            UpdateControlValue(rotationDelta);

            selectedKnob.transform.Rotate(0f, 0f, -rotationDelta, Space.Self);

            lastMouseY = Input.mousePosition.y;
        }
    }

    void UpdateControlValue(float delta)
    {
        float changeInValue = delta / maxRotation;

        switch (knobTag)
        {
            case "HumidityKnob": 
            {
                playerController.humidity -= changeInValue;
                playerController.humidity = Mathf.Clamp(playerController.humidity, minControlValue, maxControlValue);
                Debug.Log($"Humidity Value: {playerController.humidity}");
                break;
            }
            case "TemperatureKnob":
            {
                playerController.lightStrength -= changeInValue;
                playerController.lightStrength = Mathf.Clamp(playerController.lightStrength, minControlValue, maxControlValue);
                Debug.Log($"Temperature Value: {playerController.lightStrength}");
                break;
            }
            case "MusicVolumeKnob":
                break;
            default:
                break;
        }
    }
}
