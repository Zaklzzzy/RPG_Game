using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] private Room roomPrefab;
    [SerializeField] private Room startRoomPrefab;
    [SerializeField] private int dungeonSize;

    private int count = 0;

    private int[] typesOfRoom = new int[5] { 0,0,0,0,0};
    //basic - 0
    //chest - 1
    //type3 - 2
    //type4 - 3
    //type5 - 4

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

        while (count < dungeonSize)
        {

/*            if (count == 0)
            {
                CreateStartRoom(x, y);
                Debug.Log("CreateStartRoom" + count + "X:" + x + "Y:" + y);
            }
            else
            {
                CreateRoom(x, y);
                Debug.Log("CreateRoom" + count + "X:" + x + "Y:" + y);
            }*/

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
/*    private void CreateRoom(int x, int y)
    {
        if(dungeonGrid[x, y] == null)
        {
            Room newRoom = Instantiate(roomPrefab);
            newRoom.transform.position = new Vector3(x, 0, y) * 103;
            dungeonGrid[x, y] = newRoom;
            count++;
        }
    }*/
    private void CreateRoom(int x, int y)
    {
        

        if (dungeonGrid[x, y] == null)
        {
            Room Prefab = roomPrefab;

            if (typesOfRoom[0] > 2)
            {
                int swtch = Random.Range(0, 8);
                switch (swtch)
                {
                    case 0:
                        {
                            Prefab = roomPrefab;//chestRoom
                            typesOfRoom[1]++;
                            break;
                        }
                    case 2:
                        {
                            Prefab = roomPrefab;//otherRoom
                            typesOfRoom[2]++;
                            break;
                        }
                    case 4:
                        {
                            Prefab = roomPrefab;//otherRoom
                            typesOfRoom[3]++;
                            break;
                        }
                    case 6:
                        {
                            Prefab = roomPrefab;//otherRoom
                            typesOfRoom[4]++;
                            break;
                        }
                    case 8:
                        {
                            Prefab = roomPrefab;//defaultRoom
                            typesOfRoom[0]++;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else { typesOfRoom[0]++; }

            Room newRoom = Instantiate(Prefab);
            newRoom.transform.position = new Vector3(x, 0, y) * 103;
            dungeonGrid[x, y] = newRoom;
            count++;
            Debug.Log("Types Of Room:" + typesOfRoom[0] + ", " + typesOfRoom[1] + ", " + typesOfRoom[2] + ", " + typesOfRoom[3] + ", " + typesOfRoom[4]);
        }
    }
    private void CreateStartRoom(int x, int y)
    {
        if (dungeonGrid[x, y] == null)
        {
            Room newRoom = Instantiate(startRoomPrefab);
            newRoom.transform.position = new Vector3(x, 0, y) * 103;
            dungeonGrid[x, y] = newRoom;
        }
    }
    private void DisableTunnels()
    {
/*        int tempX = dungeonSize / 2, tempY = dungeonSize / 2;
        if (dungeonGrid[tempX - 1, tempY] == null) dungeonGrid[tempX, tempY].transform.rotation = Quaternion.Euler(-90,0, 90);
        else if (dungeonGrid[tempX, tempY + 1] == null) dungeonGrid[tempX, tempY].transform.rotation = Quaternion.Euler(-90, 0, 180);
        else if (dungeonGrid[tempX, tempY - 1] == null) dungeonGrid[tempX, tempY].transform.rotation = Quaternion.Euler(-90, 0, 270);*/

        for (int x = 0; x < dungeonSize; x++)
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