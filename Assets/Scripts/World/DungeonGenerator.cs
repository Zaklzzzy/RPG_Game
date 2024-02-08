using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] private Room roomPrefab;
    [SerializeField] private Room startRoomPrefab;
    [SerializeField] private int dungeonSize = 5;
    [SerializeField] private int startRoom;

    private Room[,] dungeonGrid;

    private void Start()
    {
        dungeonGrid = new Room[dungeonSize, dungeonSize];
        dungeonGrid[startRoom, startRoom] = startRoomPrefab;

        Generate();

        /*for(int i = 0; i < dungeonSize; i++)
        {
            CreateRoom();
        }*/
    }

    /*private void CreateRoom()
    {
        HashSet<Vector2Int> roomPlaces = new HashSet<Vector2Int>();
        for(int x = 0; x < dungeonSize; x++)
        {
            for (int y = 0; y < dungeonSize; y++)
            {
                if (dungeonGrid[x, y] == null) continue;

                int maxX = dungeonSize - 1;
                int maxY = dungeonSize - 1;

                if(x > 0 && dungeonGrid[x - 1, y] == null) roomPlaces.Add(new Vector2Int(x - 1, y));
                if(x > 0 && dungeonGrid[x, y - 1] == null) roomPlaces.Add(new Vector2Int(x, y - 1));
                if(x < maxX && dungeonGrid[x + 1, y] == null) roomPlaces.Add(new Vector2Int(x + 1, y ));
                if(x < maxY && dungeonGrid[x, y + 1] == null) roomPlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        Room newRoom = Instantiate(roomPrefab);
        Vector2Int position = roomPlaces.ElementAt(Random.Range(0, roomPlaces.Count));
        
        newRoom.transform.position = new Vector3(position.x - 5, 0, position.y - 5) * 103;
        dungeonGrid[position.x, position.y] = newRoom;
    }*/
    private void Generate()
    {
        float x = 1;
        float y = 1;

        for (int i = 0; i < dungeonSize-1; i++)
        {
            CreateRoom(x, y);
            Debug.Log("CreateRoom" + i);
            int random = Random.Range(0, 4);
            if (random == 0 && x < dungeonSize) x++;
            if (random == 1 && y < dungeonSize) y++;
            Debug.Log("x" + x);
            Debug.Log("y" + y);
        }
    }
    private void CreateRoom(float x, float y)
    {
        if(dungeonGrid[(int)x, (int)y] == null)
        {
            Room newRoom = Instantiate(roomPrefab);
            newRoom.transform.position = new Vector3(x, 0, y) * 103;
            dungeonGrid[(int)x, (int)y] = newRoom;
        }
    }
}