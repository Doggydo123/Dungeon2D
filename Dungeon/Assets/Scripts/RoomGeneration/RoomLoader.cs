using System;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
    public GameObject StartRoom;
    public GameObject roomTemplate; // The room template

    public int AmountOfRooms = 6;
    private GameObject currentRoom;
    void Start()
    {
        System.Random rnd = new System.Random();
        currentRoom = StartRoom;
        int previous = -1;
        for(int i = 0; i<AmountOfRooms; i++){
            int nextRoom = rnd.Next(0,4);
            while(nextRoom == previous){
                nextRoom = rnd.Next(0,4);
            }
            LoadRooms(nextRoom);
            if(nextRoom == 0){
                previous = 1;
            }
            if(nextRoom == 1){
                previous = 0;
            }else if(nextRoom == 2){
                previous = 3;
            }else if(nextRoom ==3){
                previous = 2;
            }
        }
    }

    void LoadRooms(int side)
    {
        GameObject newRoom = null;

        // left case
        if (side == 0)
        {
            Vector3 startPosition = currentRoom.transform.position;
            Vector3 roomPosition = startPosition + new Vector3(-3.75502f, 0f, 0f); // Adjust the x-coordinate as per your room size
            newRoom = Instantiate(roomTemplate, roomPosition, Quaternion.identity, transform);
        }

        // right case
        if (side == 1)
        {
            Vector3 startPosition = currentRoom.transform.position;
            Vector3 roomPosition = startPosition + new Vector3(3.75502f, 0f, 0f); // Adjust the x-coordinate as per your room size
            newRoom = Instantiate(roomTemplate, roomPosition, Quaternion.identity, transform);
        }

        // top case
        if (side == 2)
        {
            Vector3 startPosition = currentRoom.transform.position;
            Vector3 roomPosition = startPosition + new Vector3(0f, 1.9708f, 0f); // Adjust the y-coordinate as per your room size
            newRoom = Instantiate(roomTemplate, roomPosition, Quaternion.identity, transform);
        }

        // bottom case
        if (side == 3)
        {
            Vector3 startPosition = currentRoom.transform.position;
            Vector3 roomPosition = startPosition + new Vector3(0f, -1.9708f, 0f); // Adjust the y-coordinate as per your room size
            newRoom = Instantiate(roomTemplate, roomPosition, Quaternion.identity, transform);
        }

        // Update currentRoom to the newly instantiated room
        currentRoom = newRoom;
    }

}
