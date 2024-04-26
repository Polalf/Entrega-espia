using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int index;

    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ChargeScene(index);
        }
    }
    public void ChargeScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }
}   
