using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Camera mainCamera; // Assign in Inspector or we'll get it automatically
    private IInteractable currentInteractable;

    void Start()
    {
        // Try to get camera if not assigned
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        
        if (_input != null)
        {
            _input.On_F_Pressed += HandleInteraction;
        }
        else
        {
            Debug.LogError("PlayerInput reference not set in PlayerInteraction!");
        }
    }

    private void HandleInteraction()
    {
        if(currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void Update()
    {
        // Early exit if no camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null) return; // Still no camera, skip this frame
        }

        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.green);

        if (Physics.Raycast(ray, out hit, 2f))
        {
            currentInteractable = hit.collider.GetComponent<IInteractable>();
        }
        else
        {
            currentInteractable = null;
        }
    }
}