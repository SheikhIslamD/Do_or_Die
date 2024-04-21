using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Platformer()
    {
        SceneManager.LoadScene("PlatformerPrototype");
    }
        
    public void Maze()
    {
        SceneManager.LoadScene("MazePrototype");
    }
    public void Boss()
    {
        SceneManager.LoadScene("BossPrototype");
    }
}