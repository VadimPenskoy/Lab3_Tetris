using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Grid : MonoBehaviour {

    
    public static int w = 10;
    public static int h = 20;
    // grid storing the Transform element
    public static Transform[,] grid = new Transform[w, h];

    // convert a real vector to discret coordinates using Mathf.Round
    public static Vector2 roundVector2(Vector2 v) {
        return new Vector2 (Mathf.Round (v.x), Mathf.Round (v.y));
    }

    // check if some vector is inside the limits of game (borders left, right and down)
    public static bool insideBorder(Vector2 pos) {
        return ((int)pos.x >= 0 &&
                (int)pos.x < w &&
                (int)pos.y >= 0);
    }

    // destroy the row at y line
    public static void deleteRow(int y) {
        for (int x = 0; x < w; x++) {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }


    // Whenever a row was deleted, the above rows should fall towards the bottom by one unit. 
    // The following function will take care of that:
    public static void decreaseRow(int y) {
        for (int x = 0; x < w; x++) {
            if (grid[x, y] != null) {
                // move one twoards bottom
                grid[x, y - 1] = grid[x, y];
                grid[x,y] = null;

                // Update block position
                grid[x, y-1].position += new Vector3(0, -1, 0);
            }
        }
    }

    // whenever a row is deleted, all the above rows should be descreased by 1
    public static void decreaseRowAbove(int y) {
        for (int i = y; i < h; i++) {
            decreaseRow(i);
        }
    }

    // check if a row is full and, then, can be deleted (score +1)
    public static bool isRowFull(int y){
        for (int x = 0; x < w; x++) {
            if (grid[x, y] == null) {
                return false;
            }
        }
        return true;

    }

    public static void deleteFullRows() {
        for (int y = 0; y < h; y++) {
            if (isRowFull(y)) {
                deleteRow(y);
                decreaseRowAbove(y + 1);
                ScoreManager.score += (h - y) * 10;
                --y;
              
            }
        }
    }

}
