using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
    [Header("Generator Properties")]
    [SerializeField] private Room _roomPrefab;
    [SerializeField] private Room _startRoomPrefab;
    [SerializeField] private int _dungeonSize;

    private int _count = 0;

    private int[] _typesOfRoom = new int[5] { 0,0,0,0,0};
    //basic - 0
    //chest - 1
    //type3 - 2
    //type4 - 3
    //type5 - 4

    private Room[,] _dungeonGrid;

    private void Start()
    {
        _dungeonGrid = new Room[_dungeonSize, _dungeonSize];
        //_dungeonGrid[startRoom, startRoom] = _startRoomPrefab;

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
        int x = _dungeonSize/2;
        int y = _dungeonSize/2;

        _count = 0;

        while (_count < _dungeonSize)
        {

/*            if (_count == 0)
            {
                CreateStartRoom(x, y);
                Debug.Log("CreateStartRoom" + _count + "X:" + x + "Y:" + y);
            }
            else
            {
                CreateRoom(x, y);
                Debug.Log("CreateRoom" + _count + "X:" + x + "Y:" + y);
            }*/

            CreateRoom(x, y);
            Debug.Log("CreateRoom" + _count + "X:" + x + "Y:" + y);

            int random = Random.Range(0, 4);
            switch (random)
            { 
                case 0:
                    if (x + 1 < _dungeonSize && _dungeonGrid[x + 1, y] == null) x++;
                    break;
                case 1:
                    if (y + 1 < _dungeonSize && _dungeonGrid[x, y + 1] == null) y++;
                    break;
                case 2:
                    if (x - 1 >= 0 && _dungeonGrid[x - 1, y] == null) x--;
                    break;
                case 3:
                    if (y - 1 >= 0 && _dungeonGrid[x, y - 1] == null) y--;
                    break;
            }           
        }
        DisableTunnels();
    }
/*    private void CreateRoom(int x, int y)
    {
        if(_dungeonGrid[x, y] == null)
        {
            Room newRoom = Instantiate(_roomPrefab);
            newRoom.transform.position = new Vector3(x, 0, y) * 103;
            _dungeonGrid[x, y] = newRoom;
            _count++;
        }
    }*/
    private void CreateRoom(int x, int y)
    {
        

        if (_dungeonGrid[x, y] == null)
        {
            Room Prefab = _roomPrefab;

            if (_typesOfRoom[0] > 2)
            {
                int swtch = Random.Range(0, 8);
                switch (swtch)
                {
                    case 0:
                        {
                            Prefab = _roomPrefab;//chestRoom
                            _typesOfRoom[1]++;
                            break;
                        }
                    case 2:
                        {
                            Prefab = _roomPrefab;//otherRoom
                            _typesOfRoom[2]++;
                            break;
                        }
                    case 4:
                        {
                            Prefab = _roomPrefab;//otherRoom
                            _typesOfRoom[3]++;
                            break;
                        }
                    case 6:
                        {
                            Prefab = _roomPrefab;//otherRoom
                            _typesOfRoom[4]++;
                            break;
                        }
                    case 8:
                        {
                            Prefab = _roomPrefab;//defaultRoom
                            _typesOfRoom[0]++;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else { _typesOfRoom[0]++; }

            Room newRoom = Instantiate(Prefab);
            newRoom.transform.position = new Vector3(x, 0, y) * 103;
            _dungeonGrid[x, y] = newRoom;
            _count++;
            Debug.Log("Types Of Room:" + _typesOfRoom[0] + ", " + _typesOfRoom[1] + ", " + _typesOfRoom[2] + ", " + _typesOfRoom[3] + ", " + _typesOfRoom[4]);
        }
    }
    private void CreateStartRoom(int x, int y)
    {
        if (_dungeonGrid[x, y] == null)
        {
            Room newRoom = Instantiate(_startRoomPrefab);
            newRoom.transform.position = new Vector3(x, 0, y) * 103;
            _dungeonGrid[x, y] = newRoom;
        }
    }
    private void DisableTunnels()
    {
/*        int tempX = _dungeonSize / 2, tempY = _dungeonSize / 2;
        if (_dungeonGrid[tempX - 1, tempY] == null) _dungeonGrid[tempX, tempY].transform.rotation = Quaternion.Euler(-90,0, 90);
        else if (_dungeonGrid[tempX, tempY + 1] == null) _dungeonGrid[tempX, tempY].transform.rotation = Quaternion.Euler(-90, 0, 180);
        else if (_dungeonGrid[tempX, tempY - 1] == null) _dungeonGrid[tempX, tempY].transform.rotation = Quaternion.Euler(-90, 0, 270);*/

        for (int x = 0; x < _dungeonSize; x++)
        {
            for (int y = 0; y < _dungeonSize; y++)
            {
                if (_dungeonGrid[x,y] != null)
                { 
                    if(x == _dungeonSize - 1 || _dungeonGrid[x + 1, y] == null) _dungeonGrid[x, y].constRight = true;
                    if (x == 0 || _dungeonGrid[x - 1, y] == null) _dungeonGrid[x, y].constLeft = true;
                    if (y == _dungeonSize - 1 || _dungeonGrid[x, y + 1] == null) _dungeonGrid[x, y].constFront = true;
                    if (y == 0 || _dungeonGrid[x, y - 1] == null) _dungeonGrid[x, y].constBack = true;
                    _dungeonGrid[x, y].DisableConst();
                }
            }
        }
    }
}