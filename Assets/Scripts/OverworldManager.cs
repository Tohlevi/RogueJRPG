using UnityEngine;

public class OverworldManager : MonoBehaviour {

    public GameObject Tile;
    public GameObject Tile_Wall;
    public int mapSizeX = 10; //Max X cordinate
    public int mapSizeY = 10; //Max Y cordinate
    private int[,] overworldPos;
    private int blockSize = 1;

    // Use this for initialization


    #region Check & Set

    public int BlockSize
    {
        get { return blockSize; }
    }

    public bool CheckIsInArray(int x, int y) //Used to check if value is in or outside of array to prevent errors with arrays.
    {
        if (x >= 0 && x < mapSizeX && y >= 0 && y < mapSizeY) return true;
        else return false;
    }

    public bool CheckLocation(int x, int y) //Returns true if position is free
    {
        if (CheckIsInArray(x, y) == true)
        {
            if (overworldPos[x, y] == 0)
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    public void SetArrayPos(int x, int y, int value)
    {
        if (CheckIsInArray(x, y) == true)
        {
            overworldPos[x, y] = value;
        }
    }

    public void FreePos(int x, int y)
    {
        if (CheckIsInArray(x, y) == true)
        {
            overworldPos[x, y] = 0;
        }
    }

    #endregion

    #region LevelLoader
    void LevelBuilder() //Used for creating basic tiles based on if array cordinate is empty or not. Empty = tilegraphic
    {
        BuildFloor();
        BuildWalls();
    }

    void BuildFloor()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                if(overworldPos[x, y] == 0)
                {
                    GameObject TileBlock = Instantiate(Tile, new Vector3(x, y), Quaternion.identity) as GameObject;
                    TileBlock.transform.parent = GameObject.Find("OverworldManager").transform;
                    TileBlock.GetComponent<TileObj>().AssingSprite(6);
                }
            }
        }
    }

    void BuildWalls()
    {
        for (int x = 0; x < mapSizeX+2; x++)
        {
            for (int y = 0; y < mapSizeY+2; y++)
            {
                if (CheckIsInArray(x - 1, y - 1) == false || overworldPos[x - 1, y - 1] == 1)
                {
                    GameObject TileBlock_Wall = Instantiate(Tile_Wall, new Vector3(x-1, y-1), Quaternion.identity) as GameObject;
                    TileBlock_Wall.transform.parent = GameObject.Find("OverworldManager").transform;
                    TileBlock_Wall.GetComponent<TileObj>().AssingSprite(6);
                }
            }
        }
    }



    #endregion

    void Start()
    {
        overworldPos = new int[mapSizeX, mapSizeY];
        //Set the array first empty
        for (int i = 0; i < mapSizeX; i++)
        {
            for (int a = 0; a < mapSizeY; a++)
            {
                overworldPos[i, a] = 0;
            }
        }
        Debug.Log("Array succesfully set to default");
        overworldPos[2, 2] = 1; //Sets one tile to 1

        LevelBuilder();
    }

    // Update is called once per frame
    void Update()
    {

	}
}