using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 targetRoomPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Assuming the initial room is the room the player starts in
        targetRoomPosition = player.position;
        targetRoomPosition.z = transform.position.z; // Maintain the camera's initial Z position
    }

    private void Update()
    {
        // Smoothly move the camera towards the target room position
        Vector3 newPosition = Vector3.Lerp(transform.position, targetRoomPosition, Time.deltaTime * 5f);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z); // Maintain the camera's Z position
    }

    // Called by RoomTrigger to update the target room position
    public void ChangeRoom(Vector3 roomPosition)
    {
        targetRoomPosition = roomPosition;
        targetRoomPosition.z = transform.position.z; // Maintain the camera's initial Z position
    }
}
