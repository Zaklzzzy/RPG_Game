using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(requiredComponent:typeof(MeshFilter), requiredComponent2: typeof(MeshRenderer))]

public class ChunkRenderer : MonoBehaviour
{
    public const int ChunkWidth = 25;
    public const int ChunkHeight = 128;
    public const float BlockScale = 1;

    public ChunkData ChunkData;
    public GameWorld ParentWorld;

    private List<Vector3> verticles = new List<Vector3>();
    private List<int> triangles = new List<int>();

    private void Start()
    {
        Mesh chunkMesh = new Mesh();

        for (int y = 0; y < ChunkHeight; y++)
        {
            for (int x = 0; x < ChunkWidth; x++)
            {
                for (int z = 0; z < ChunkWidth; z++)
                {
                    GenerateBlock(x, y, z);
                }
            }
        }

        chunkMesh.vertices = verticles.ToArray();
        chunkMesh.triangles = triangles.ToArray();

        chunkMesh.Optimize();

        chunkMesh.RecalculateBounds();
        chunkMesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = chunkMesh;
        GetComponent<MeshCollider>().sharedMesh = chunkMesh;
    }

    private void GenerateBlock(int x, int y, int z)
    {
        var blockPosition = new Vector3Int(x, y, z);

        if (ChunkData.Blocks[x, y, z] == 0) return;

        if (GetBlockPosition(blockPosition) == 0) return;
        if (GetBlockPosition(blockPosition+Vector3Int.right) == 0) GenerateRightSide(blockPosition);
        if (GetBlockPosition(blockPosition + Vector3Int.left) == 0) GenerateLeftSide(blockPosition);
        if (GetBlockPosition(blockPosition + Vector3Int.forward) == 0) GenerateFrontSide(blockPosition);
        if (GetBlockPosition(blockPosition + Vector3Int.back) == 0) GenerateBackSide(blockPosition);
        if (GetBlockPosition(blockPosition + Vector3Int.up) == 0) GenerateUpSide(blockPosition);
        if (GetBlockPosition(blockPosition + Vector3Int.down) == 0) GenerateDownSide(blockPosition);

    }

    private BlockType GetBlockPosition(Vector3Int blockPosition)
    {
        if (blockPosition.x >= 0 && blockPosition.x < ChunkWidth &&
            blockPosition.y >= 0 && blockPosition.y < ChunkHeight &&
            blockPosition.z >= 0 && blockPosition.z < ChunkWidth)
        {
            return ChunkData.Blocks[blockPosition.x, blockPosition.y, blockPosition.z];
        }
        else
        {
            if (blockPosition.y < 0 || blockPosition.y >= ChunkHeight) return BlockType.Air;

            Vector2Int adjChunkPos = ChunkData.ChunkPosition;

            if (blockPosition.x < 0)
            {
                adjChunkPos.x--;
                blockPosition.x += ChunkWidth;
            }
            else if (blockPosition.x >= ChunkWidth)
            {
                adjChunkPos.x++;
                blockPosition.x -= ChunkWidth;
            }

            if (blockPosition.z < 0)
            {
                adjChunkPos.y--;
                blockPosition.z += ChunkWidth;
            }
            else if (blockPosition.z >= ChunkWidth)
            {
                adjChunkPos.y++;
                blockPosition.z -= ChunkWidth;
            }

            if(ParentWorld.ChunkDatas.TryGetValue(adjChunkPos, out ChunkData adjChunk))
            {
                return adjChunk.Blocks[blockPosition.x, blockPosition.y, blockPosition.z];
            }
            else
            {
                return BlockType.Air;
            }           
        }
    }

    private void GenerateRightSide(Vector3Int blockPosition)
    {
        verticles.Add((new Vector3(1, 0, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 1, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 0, 1) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 1, 1) + blockPosition)*BlockScale);

        AddLastVerticlesSquare();
    }
    private void GenerateLeftSide(Vector3Int blockPosition)
    {
        verticles.Add((new Vector3(0, 0, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(0, 0, 1) + blockPosition)* BlockScale);
        verticles.Add((new Vector3(0, 1, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(0, 1, 1) + blockPosition)*BlockScale);

        AddLastVerticlesSquare();
    }
    private void GenerateFrontSide(Vector3Int blockPosition)
    {
        verticles.Add((new Vector3(0, 0, 1) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 0, 1) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(0, 1, 1) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 1, 1) + blockPosition)*BlockScale);

        AddLastVerticlesSquare();
    }
    private void GenerateBackSide(Vector3Int blockPosition)
    {
        verticles.Add((new Vector3(0, 0, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(0, 1, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 0, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 1, 0) + blockPosition)*BlockScale);

        AddLastVerticlesSquare();
    }
    private void GenerateUpSide(Vector3Int blockPosition)
    {
        verticles.Add((new Vector3(0, 1, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(0, 1, 1) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 1, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 1, 1) + blockPosition)*BlockScale);

        AddLastVerticlesSquare();
    }
    private void GenerateDownSide(Vector3Int blockPosition)
    {
        verticles.Add((new Vector3(0, 0, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 0, 0) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(0, 0, 1) + blockPosition)*BlockScale);
        verticles.Add((new Vector3(1, 0, 1) + blockPosition)*BlockScale);

        AddLastVerticlesSquare();
    }

    private void AddLastVerticlesSquare()
    {
        triangles.Add(verticles.Count - 4);
        triangles.Add(verticles.Count - 3);
        triangles.Add(verticles.Count - 2);

        triangles.Add(verticles.Count - 3);
        triangles.Add(verticles.Count - 1);
        triangles.Add(verticles.Count - 2);
    }
}
