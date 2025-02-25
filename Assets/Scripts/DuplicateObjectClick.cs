using UnityEngine;
using System.Collections;

public class CloneObjectController : MonoBehaviour
{
    public Camera mainCamera;
    public PlayerControllerScript playerController;
    public GameObject[] cloneableObjects;
    public float growthDuration = 0.5f; // Duração da animação em segundos

    private GameObject selectedObject;
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
                    StartCoroutine(CreateAndGrowObject(hit.point));
                }
            }
        }
    }

    IEnumerator CreateAndGrowObject(Vector3 position)
    {
        // Cria o objeto com escala zero
        GameObject clonedObject = Instantiate(selectedObject, position, Quaternion.identity);
        clonedObject.tag = "Removable";
        clonedObject.transform.localScale = Vector3.zero;

        Vector3 targetScale = selectedObject.transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < growthDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / growthDuration;
            clonedObject.transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, t);
            yield return null;
        }

        clonedObject.transform.localScale = targetScale; // Garante que o objeto termine exatamente no tamanho desejado
        Debug.Log("Created and grew object at: " + position);
    }
}
