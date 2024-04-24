using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLocal : MonoBehaviour
{
    public GameObject destinationPortal; // The portal to teleport to
    public float teleportOffsetX = 0.6f; // Offset along the x-axis from the destination portal

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the object entering the portal is the player
        {
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        Vector3 teleportPosition = destinationPortal.transform.position + new Vector3(teleportOffsetX, 0, 0);
        player.transform.position = teleportPosition;
    }
}
