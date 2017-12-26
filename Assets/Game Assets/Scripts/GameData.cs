using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    private Grid grid;
    private int score;
    private int highScore;

    public GameData()
    {
        score = 0;
        highScore = 0;
    }

    
    public Grid getGridValues()
    {
        return grid;
    }

    public int getScore()
    {
        return score;
    }

    public int getHighScore()
    {
        return highScore;
    }

    public void setScore(int score)
    {
        this.score = score;
    }

    public void setHighScore(int highScore)
    {
        this.highScore = highScore;
    }

    public void setGridValues(Grid grid)
    {
        this.grid = grid;
    }

}