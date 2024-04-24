using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform roomA;
    [SerializeField] private Transform roomB;

    private bool isPlayerInRoomA = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isPlayerInRoomA)
            {
                Camera.main.transform.position = new Vector3(roomB.position.x, roomB.position.y, Camera.main.transform.position.z);
            }
            else
            {
                Camera.main.transform.position = new Vector3(roomA.position.x, roomA.position.y, Camera.main.transform.position.z);
            }

            isPlayerInRoomA = !isPlayerInRoomA;
        }
    }
}
