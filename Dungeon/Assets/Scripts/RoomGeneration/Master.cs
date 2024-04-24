using UnityEngine;
using System.Collections.Generic;

public class Master : MonoBehaviour
{
    public GameObject[] roomPrefabs;

    public List<GameObject[]> GenerateDungeonPaths(int numPaths, int roomsPerPath)
    {
        List<GameObject[]> paths = new List<GameObject[]>();

        for (int i = 0; i < numPaths; i++)
        {
            GameObject[] path = new GameObject[roomsPerPath];

            for (int j = 0; j < roomsPerPath; j++)
            {
                int randomIndex = Random.Range(0, roomPrefabs.Length);
                GameObject roomPrefab = roomPrefabs[randomIndex];
                GameObject roomInstance = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity);
                path[j] = roomInstance;
            }

            paths.Add(path);
        }

        return paths;
    }

    public void InstantiateDungeonPaths(int numPaths, int roomsPerPath)
    {
        List<GameObject[]> paths = GenerateDungeonPaths(numPaths, roomsPerPath);
        int roomHeight = 1;
        int roomWidth = 1;
        for (int i = 0; i < numPaths; i++)
        {
            GameObject[] path = paths[i];
            for (int j = 0; j < roomsPerPath; j++)
            {
                GameObject room = path[j];
                // Position and orient the room according to your dungeon layout
                room.transform.position = new Vector3(j * roomWidth, 0f, i * roomHeight);
            }
        }
    }


}