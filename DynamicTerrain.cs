using UnityEngine;

public class DynamicTerrain : MonoBehaviour
{
    public Terrain terrain;
    public float terrainHeight = 10f;
    public float terrainScale = 50f;
    private int seed;

    void Start()
    {
        seed = System.DateTime.Now.Day; // Changes terrain daily
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        TerrainData terrainData = terrain.terrainData;
        int width = terrainData.heightmapResolution;
        int height = terrainData.heightmapResolution;
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = (float)x / width * terrainScale + seed;
                float yCoord = (float)y / height * terrainScale + seed;
                heights[x, y] = Mathf.PerlinNoise(xCoord, yCoord) * terrainHeight / 600;
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }
}