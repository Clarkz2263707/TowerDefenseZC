using UnityEngine;
using UnityEditor;

public class LevelGenerator : EditorWindow
{
    //Summary
    //Handles the creation of the 4 levels that are used in game. Was used to make the grids which I then editted manually later
    //Summary

    private int gridSize = 10;
    private GameObject tilePrefab;
    private Transform gridParent;
    private GameObject[,] gridTiles;
    private int sectionSpacing = 10;


    [MenuItem("Tools/Level Generator")]

    public static void ShowWindow()
    {
        GetWindow<LevelGenerator>("Level Generator");
    }
    //gathers the tile prefabs, grid settings, and parent and establishes the buttons need pressing to clear and generate grids that are used. We made this was Gary
    private void OnGUI()
    {
        GUILayout.Label("Grid Settings", EditorStyles.boldLabel);
        gridSize = EditorGUILayout.IntField("Level Layout", gridSize);
        GUILayout.Space(sectionSpacing);

        GUILayout.Label("Tile Prefab", EditorStyles.boldLabel);
        tilePrefab = (GameObject)EditorGUILayout.ObjectField("Tile Prefab", tilePrefab, typeof(GameObject), false);
        GUILayout.Space(sectionSpacing);

        GUILayout.Label("Grid Parent", EditorStyles.boldLabel);
        gridParent = (Transform)EditorGUILayout.ObjectField("Tile Prefab", gridParent, typeof(Transform), true);
        GUILayout.Space(sectionSpacing);

        if (GUILayout.Button("Generate Grid"))
        {
            GenerateGrid();
        }

        if (GUILayout.Button("Clear Grid"))
        {
            ClearGrid();
        }
    }
    //generates a grid that follows the specifications we established.
    private void GenerateGrid()
    {
        if (tilePrefab == null)
        {
            Debug.LogError("Tile Prefab is not assigned!");
            return;
        }
        gridTiles = new GameObject[gridSize, gridSize];
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 position = new Vector3(x, 0, z);
                gridTiles[x, z] = (GameObject)PrefabUtility.InstantiatePrefab(tilePrefab, gridParent);
                gridTiles[x, z].transform.position = position;
                Debug.Log(position);
            }
        }
    }
    //clears the grid.
    private void ClearGrid()
    {
        if (gridTiles != null)
        {
            for (int x = 0; x < gridSize; x++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    if (gridTiles[x, z] != null)
                    {
                        DestroyImmediate(gridTiles[x, z]);
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("No grid to clear!");
            return;
        }
    }
}
    
