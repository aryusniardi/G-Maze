using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int currentScene = 0;

    public static void NextScene()
    {
        if (currentScene < 3)
        {
            Application.LoadLevel(index: currentScene + 1);
        } else
        {
            print ("You win!");
        }
    }
}
