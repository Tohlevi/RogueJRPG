using UnityEngine;
using System.Collections;

public class PlayerObj : OverworldObj {

	// Use this for initialization
	void Start () {
        Pos = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        int posX = (int)Pos.x;
        int posY = (int)Pos.y;

        //Inputs
        if (Input.GetKeyDown(KeyCode.A)) posX -= 1;
        if (Input.GetKeyDown(KeyCode.S)) posY -= 1;
        if (Input.GetKeyDown(KeyCode.D)) posX += 1;
        if (Input.GetKeyDown(KeyCode.W)) posY += 1;
        //Updates position for sprite
        Draw(posX,posY);
	}
}