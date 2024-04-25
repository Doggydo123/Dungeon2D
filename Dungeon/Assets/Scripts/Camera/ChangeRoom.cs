using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour
{
    // Reference to the camera controller
    public CameraController cameraController;

    private Collider2D roomCollider;
    private bool canDisableCollider = true;
    private WaitForSeconds disableDuration = new WaitForSeconds(0.8f);

    private void Start()
    {
        roomCollider = GetComponent<Collider2D>();

        // Find the CameraController component attached to the main camera
        if (cameraController == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                cameraController = mainCamera.GetComponent<CameraController>();
                if (cameraController == null)
                {
                    Debug.LogError("CameraController component not found on MainCamera.");
                }
            }
            else
            {
                Debug.LogError("MainCamera not found in the scene.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify the camera controller that the player entered this room
            cameraController.ChangeRoom(transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canDisableCollider)
        {
            // Disable the collider of this room
            StartCoroutine(DisableColliderForDuration());
        }
    }

    private IEnumerator DisableColliderForDuration()
    {
        canDisableCollider = false;
        roomCollider.enabled = false;
        yield return disableDuration;
        roomCollider.enabled = true;
        canDisableCollider = true;
    }
}
