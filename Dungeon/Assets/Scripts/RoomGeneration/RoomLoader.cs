using System;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
    public GameObject StartRoom;
    public GameObject roomTemplate; // The room template

    public int AmountOfRooms = 1;
    private GameObject currentRoom;
    void Start()
    {
        currentRoom = StartRoom;
        for(int i = 0; i<AmountOfRooms; i++){
            LoadRooms("left");
        }
    }

    void LoadRooms(string side)
    {
        GameObject newRoom = null;

        // left case
        if (side == "left")
        {
            Vector3 startPosition = currentRoom.transform.position;
            Vector3 roomPosition = startPosition + new Vector3(-3.75502f, 0f, 0f); // Adjust the x-coordinate as per your room size
            newRoom = Instantiate(roomTemplate, roomPosition, Quaternion.identity, transform);
        }

        // right case
        if (side == "right")
        {
            Vector3 startPosition = currentRoom.transform.position;
            Vector3 roomPosition = startPosition + new Vector3(3.75502f, 0f, 0f); // Adjust the x-coordinate as per your room size
            newRoom = Instantiate(roomTemplate, roomPosition, Quaternion.identity, transform);
        }

        // top case
        if (side == "top")
        {
            Vector3 startPosition = currentRoom.transform.position;
            Vector3 roomPosition = startPosition + new Vector3(0f, 1.9708f, 0f); // Adjust the y-coordinate as per your room size
            newRoom = Instantiate(roomTemplate, roomPosition, Quaternion.identity, transform);
        }

        // bottom case
        if (side == "bottom")
        {
            Vector3 startPosition = currentRoom.transform.position;
            Vector3 roomPosition = startPosition + new Vector3(0f, -1.9708f, -10f); // Adjust the y-coordinate as per your room size
            newRoom = Instantiate(roomTemplate, roomPosition, Quaternion.identity, transform);
        }

        // Update currentRoom to the newly instantiated room
        currentRoom = newRoom;
    }

}
