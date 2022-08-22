using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Manager manager;

    public void Ready(){
        manager.gameUI.SetActive(true);
        manager.menuGameUI.SetActive(false);
        manager.gameoverUI.SetActive(false);
        manager.StartGame();
    }

    public void Play(){
        manager.menuGameUI.SetActive(true);
        manager.menuUI.SetActive(false);
    }

    public void Ok(){
        manager.menuGameUI.SetActive(true);
        manager.gameoverUI.SetActive(false);
        manager.goldCoin.SetActive(false);
        manager.silverCoin.SetActive(false);
        manager.bronzeCoin.SetActive(false);
    }

    public void Menu(){
        manager.menuUI.SetActive(true);
        manager.gameoverUI.SetActive(false);
        manager.goldCoin.SetActive(false);
        manager.silverCoin.SetActive(false);
        manager.bronzeCoin.SetActive(false);
    }
}
