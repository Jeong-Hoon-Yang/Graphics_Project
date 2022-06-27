using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
{
    public static int room_num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickedBackButton()
    {
        Debug.Log("SELECT ROOM");
        SceneManager.LoadScene(0);
    }

    public void OnclickedOneRoomButton1()
    {
        room_num = 0;
        Debug.Log("SELECT ONE ROOM 1");
        SceneManager.LoadScene(2);
    }

    public void OnclickedOneRoomButton2()
    {
        room_num = 1;
        Debug.Log("SELECT ONE ROOM 2");
        SceneManager.LoadScene(3);
    }

    public void OnclickedTwoRoomButton()
    {
        room_num = 2;
        Debug.Log("SELECT TWO ROOM");
        SceneManager.LoadScene(4);
    }
}