using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    public Dictionary<Vector2Int,ChunkData> ChunkDatas = new Dictionary<Vector2Int,ChunkData>();
    public ChunkRenderer ChunkPrefab;

    void Start()
    {
        for(int x = 0; x<10; x++)
        {
            for (int y = 0; y<10; y++)
            {

                int xPos = x * ChunkRenderer.ChunkWidth;
                int zPos = y * ChunkRenderer.ChunkWidth;
                ChunkData chunkData = new ChunkData();
                chunkData.Blocks = TerrainGenerator.GenerateTerrain(xPos, zPos);
                chunkData.ChunkPosition = new Vector2Int(x,y);
                ChunkDatas.Add(new Vector2Int(x, y), chunkData);

                var chunk = Instantiate(ChunkPrefab,new Vector3(xPos,0,zPos), Quaternion.identity,transform);
                chunk.ChunkData = chunkData;
                chunk.ParentWorld = this;
            }
        }
    }
}