using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{

    public bool mine;

    public Sprite[] Textures;
    public Sprite mineTextures;

    // Start is called before the first frame update
    void Start()
    {
        mine = Random.value < 0.15;   

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Playfield.elements[x,y] = this;

        //TEST
        //loadTexture(1);
    }

    void OnMouseUpAsButton() {
        if (mine) {
            // TODO: uncover all mines
            Playfield.uncoverMines();

            // game over
            print("you lose");
        }
        // It's not a mine
        else {
            // TODO: show adjacent mine number
            //loadTexture(...);

            // TODO: uncover area without mines
            // ...

            // TODO: find out if the game was won now
            // ...
        }
    }

    public void loadTexture(int adjacentCount) {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTextures;
        else
            GetComponent<SpriteRenderer>().sprite = Textures[adjacentCount];
    }

    public bool isCovered() {
    return GetComponent<SpriteRenderer>().sprite.texture.name == "Default";
    }
}
