using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] private Room roomPrefab;
    [SerializeField] private Room startRoomPrefab;
    [SerializeField] private int dungeonSize ;
    [SerializeField] private int startRoom;

    private int count = 0;

    private Room[,] dungeonGrid;

    private void Start()
    {
        dungeonGrid = new Room[dungeonSize, dungeonSize];
        //dungeonGrid[startRoom, startRoom] = startRoomPrefab;

        Generate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void Generate()
    {
        int x = dungeonSize/2;
        int y = dungeonSize/2;

        count = 0;

        /*for (int i = 0; i < dungeonSize-1; i++)*/
        while (count < dungeonSize)
        {
            CreateRoom(x, y);
            Debug.Log("CreateRoom" + count + "X:" + x + "Y:" + y);
            int random = Random.Range(0, 4);
            switch (random)
            { 
                case 0:
                    if (x + 1 < dungeonSize && dungeonGrid[x + 1, y] == null) x++;
                    break;
                case 1:
                    if (y + 1 < dungeonSize && dungeonGrid[x, y + 1] == null) y++;
                    break;
                case 2:
                    if (x - 1 >= 0 && dungeonGrid[x - 1, y] == null) x--;
                    break;
                case 3:
                    if (y - 1 >= 0 && dungeonGrid[x, y - 1] == null) y--;
                    break;
            }           
        }
        DisableTunnels();
    }
    private void CreateRoom(int x, int y)
    {
        if(dungeonGrid[x, y] == null)
        {
            Room newRoom = Instantiate(roomPrefab);
            newRoom.transform.position = new Vector3(x, 0, y) * 103;
            dungeonGrid[x, y] = newRoom;
            count++;
        }
    }
    private void DisableTunnels()
    {
        for(int x = 0; x < dungeonSize; x++)
        {
            for (int y = 0; y < dungeonSize; y++)
            {
                if (dungeonGrid[x,y] != null)
                { 
                    if(x == dungeonSize - 1 || dungeonGrid[x + 1, y] == null) dungeonGrid[x, y].constRight = true;
                    if (x == 0 || dungeonGrid[x - 1, y] == null) dungeonGrid[x, y].constLeft = true;
                    if (y == dungeonSize - 1 || dungeonGrid[x, y + 1] == null) dungeonGrid[x, y].constFront = true;
                    if (y == 0 || dungeonGrid[x, y - 1] == null) dungeonGrid[x, y].constBack = true;
                    dungeonGrid[x, y].DisableConst();
                }
            }
        }
    }
}