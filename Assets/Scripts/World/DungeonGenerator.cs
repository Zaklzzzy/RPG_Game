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

        for(int i = 0; i < dungeonSize; i++)
        {
            CreateRoom();
        }
    }

    private void CreateRoom()
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
        //newRoom.RandomConst();
        
        newRoom.transform.position = new Vector3(position.x - 5, 0, position.y - 5) * 103;
        dungeonGrid[position.x, position.y] = newRoom;
    }

    private bool ConnectRoom(Room room, Vector2Int pos)
    {
        int maxX = dungeonGrid.GetLength(0) - 1;
        int maxY = dungeonGrid.GetLength(1) - 1;

        List<Vector2Int> nearRooms = new List<Vector2Int>();

        if (!room.constLeft && pos.x < maxX && dungeonGrid[pos.x - 1, pos.y] != null && !dungeonGrid[pos.x - 1, pos.y].constRight) nearRooms.Add(Vector2Int.left);
        if (!room.constRight && pos.x > 0 && dungeonGrid[pos.x + 1, pos.y] != null && !dungeonGrid[pos.x + 1, pos.y].constLeft) nearRooms.Add(Vector2Int.right);
        if (!room.constLeft && pos.y < maxY && dungeonGrid[pos.x, pos.y + 1] != null && !dungeonGrid[pos.x, pos.y + 1].constBack) nearRooms.Add(Vector2Int.up);
        if (!room.constLeft && pos.y > 0 && dungeonGrid[pos.x, pos.y - 1] != null && !dungeonGrid[pos.x, pos.y - 1].constFront) nearRooms.Add(Vector2Int.down);

        if(nearRooms.Count == 0) return false;

        Vector2Int selectedDirection = nearRooms[Random.Range(0, nearRooms.Count)];
        Room selectedRoom = dungeonGrid[pos.x + selectedDirection.x, pos.y + selectedDirection.y];

        if(selectedDirection == Vector2Int.up)
        {
            room.FrontSwitcher();
        }
        if (selectedDirection == Vector2Int.down)
        {
            room.BackSwitcher();
        }
        if (selectedDirection == Vector2Int.left)
        {
            room.LeftSwitcher();
        }
        if (selectedDirection == Vector2Int.right)
        {
            room.RightSwitcher();
        }

        return true;
    }
}