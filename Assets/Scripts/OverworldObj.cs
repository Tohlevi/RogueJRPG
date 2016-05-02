using UnityEngine;
using System.Collections;
using System;

public class OverworldObj : MonoBehaviour {

    public enum objType { empty, player, enemy, item };
    public objType ObjType = objType.empty; //Sets Object to dummy as default. Use corresponding types when creating new objects inheriting Object class.
    public string objName = "Dummy";

    private Vector2 pos = new Vector2(1, 1);
    public Vector2 Pos
    {
        get
        {
            return pos;
        }
        set
        {
            pos = value;
        }
    }

    public void Draw(int x, int y) //Handles drawing of objects and movement to new position if it is allowed
    {
        int blockSize = Math.Abs(GameObject.Find("OverworldManager").GetComponent<OverworldManager>().BlockSize);
        if (transform.position != new Vector3(x * blockSize, y * blockSize, 0))
        {
            bool allowMove = GameObject.Find("OverworldManager").GetComponent<OverworldManager>().CheckLocation(x, y);
            if (allowMove == true) //If object tries to change their cordinate, it will be checked if it will be allowed to move, and if it is, it will change its position to the new position set to it, else it will revert to old position
            {
                Pos = new Vector2(x, y);
            }
        }
        transform.position = new Vector3(Pos.x * blockSize, Pos.y * blockSize, 0);
    }

	// Use this for initialization
	void Start ()
    {
        Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Draw((int)Pos.x, (int)Pos.y);
	}
}
