﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapGrid))]
public class GridView : View
{
    private ObjectPool tilePool;
    private MapGrid mapGrid;

    [SerializeField] GameObject tilePrefab;

    [SerializeField] float tileWidth  = 20f;
    [SerializeField] float tileHeight = 20f;


    void Awake()
    {
        mapGrid = GetComponent<MapGrid>();

        tilePool = new ObjectPool(tilePrefab, transform);

        Square[][] matrix = mapGrid.GetGridMatrix();
        int columns = mapGrid.GetColumnCount();
        int rows = mapGrid.GetRowCount();

        


        for(int c = 0; c < columns; c++)
        {
            for(int r = 0; r < rows; r++)
            {
                TileView tile = tilePool.GetInstance().GetComponent<TileView>();
                float x_pos = ( (-columns + 1) * tileWidth  * 0.5f) + c * tileWidth;
                float y_pos = ( (rows - 1)     * tileHeight * 0.5f) - r * tileHeight;
                // Position in pixels:
                Vector2 position = new Vector2(x_pos,y_pos);
                tile.transform.SetParent(transform);
                tile.Initialize(position);
                tile.gameObject.SetActive(true);
            }
        }
    }















}