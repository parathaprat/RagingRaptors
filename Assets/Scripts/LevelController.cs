using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    
     Monster[] _monsters;

    void OnEnable()
    {
         _monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MonstersAreAllDead())
            GoToNextLevel();
    }

    void GoToNextLevel()
    {
        Debug.Log("Go to Level" + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

    bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if(monster.gameObject.activeSelf)
                return false;
        }

        return true;
    }
}
