using UnityEngine;
using System.Collections;
using System;

public class TileObj : OverworldObj
{

    private SpriteRenderer spriteRenderer;
    private float scale = 32;
    public Texture2D SpriteSheet;
    public enum tileType { floor, wall };
    public tileType TileType;

    private Vector2 spriteIndex;

    private Sprite sprite;
    public enum TileIndex
    {
        OOO_OXX_OXX = 1, OOO_XXX_XXX = 2, OOO_XXO_XXO = 3, OOO_OXO_OXO = 4,
        OXX_OXX_OXX = 5, XXX_XXX_XXX = 6, XXO_XXO_XXO = 7, OXO_OXO_OXO = 8,
        OXX_OXX_OOO = 9, XXX_XXX_OOO = 10, XXO_XXO_OOO = 11, OXO_OXO_OOO = 12,
        OOO_OXX_OOO = 13, OOO_XXX_OOO = 14, OOO_XXO_OOO = 15, OOO_OXO_OOO = 16
    };

    // Use this for initialization
    void Start()
    {
        Pos = transform.position;
    }

    public void AssingSprite(int indexT)
    {
        if (spriteRenderer == null) spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        //Creates sprite to use based on the texture given
        SetSpriteIndex(indexT);
        Vector2 SprPos = new Vector2(0+scale* spriteIndex.x, 256-scale-scale*spriteIndex.y);
        Vector2 TileSize = new Vector2(scale, scale);
        sprite = Sprite.Create(SpriteSheet, new Rect(SprPos, TileSize), new Vector2(0,1), scale);
        spriteRenderer.sprite = sprite;
    }

    private void SetSpriteIndex(int index)
    {
        TileIndex tileIndex = (TileIndex)index;

        switch(tileIndex)
        {
            case (TileIndex)1:
                spriteIndex = new Vector2(0, 0);
                break;

            case (TileIndex)2:
                spriteIndex = new Vector2(1, 0);
                break;

            case (TileIndex)3:
                spriteIndex = new Vector2(2, 0);
                break;

            case (TileIndex)4:
                spriteIndex = new Vector2(3, 0);
                break;

            case (TileIndex)5:
                spriteIndex = new Vector2(0, 1);
                break;

            case (TileIndex)6:
                spriteIndex = new Vector2(1, 1);
                break;

            case (TileIndex)7:
                spriteIndex = new Vector2(2, 1);
                break;

            case (TileIndex)8:
                spriteIndex = new Vector2(3, 1);
                break;

            case (TileIndex)9:
                spriteIndex = new Vector2(0, 2);
                break;

            case (TileIndex)10:
                spriteIndex = new Vector2(1, 2);
                break;

            case (TileIndex)11:
                spriteIndex = new Vector2(2, 2);
                break;

            case (TileIndex)12:
                spriteIndex = new Vector2(3, 2);
                break;

            case (TileIndex)13:
                spriteIndex = new Vector2(0, 3);
                break;

            case (TileIndex)14:
                spriteIndex = new Vector2(1, 3);
                break;

            case (TileIndex)15:
                spriteIndex = new Vector2(2, 3);
                break;

            case (TileIndex)16:
                spriteIndex = new Vector2(3, 3);
                break;



            default: //If none found
                spriteIndex = new Vector2(0, 0);
                break;
        }
        if (TileType == tileType.floor) spriteIndex.y += 4;
    }


    // Update is called once per frame
    void Update()
    {
        Draw((int)Pos.x, (int)Pos.y);
    }
}