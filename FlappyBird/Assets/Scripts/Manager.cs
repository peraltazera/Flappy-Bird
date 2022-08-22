using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private Obstacles[] obs;
    public Transform start;
    public Transform end;
    public float distX;
    public TMP_Text pointsText;
    public TMP_Text pointsGameOverText;
    public TMP_Text bestPointsGameOverText;
    public int points = 0;
    public int bestPoints = 0;
    public int secondBestPoints = 0;
    public AudioSource hitSound;
    public AudioSource dieSound;
    public AudioSource pointSound;
    public AudioSource wingSound;
    public bool die = false;
    public GameObject menuGameUI;
    public GameObject gameoverUI;
    public GameObject gameUI;
    public GameObject menuUI;
    public Bird bird;
    public Vector3 startPositionBird;
    public GameObject goldCoin;
    public GameObject silverCoin;
    public GameObject bronzeCoin;

    public void EnabledObs(Transform obsPosition)
    {
        for(int i = 0;i < obs.Length; i++){
            if(obs[i].end){
                obs[i].gameObject.transform.position = new Vector2(obsPosition.position.x + distX, Random.Range(-0.7f,1.5f));
                obs[i].end = false;
                obs[i].start = false;
                obs[i].gameObject.SetActive(true);
                break;
            }
        }
    }

    public void AddPoint(){
        points++;
        pointsText.text = points.ToString();
    }

    public void StartGame(){
        for(int i = 0;i < obs.Length; i++){
            obs[i].gameObject.transform.position = new Vector2(3, 0);
            obs[i].end = true;
            obs[i].start = false;
            obs[i].gameObject.SetActive(false);
        }
        obs[0].end = false;
        bird.transform.position = startPositionBird;
        die = false;
        bird.boxCol.enabled = true;
        points = 0;
        pointsText.text = points.ToString();
        obs[0].gameObject.SetActive(true);
        bird.gameObject.SetActive(true);
        bird.Jump();
    }

    public void EndGame(){
        hitSound.Play();
        dieSound.Play();
        gameUI.SetActive(false);
        die = true;
        if(bestPoints <= points){
            bestPoints = points;
            goldCoin.SetActive(true);
        }else if(secondBestPoints <= points && points != 0){
            secondBestPoints = points;
            silverCoin.SetActive(true);
        }else{
            bronzeCoin.SetActive(true);
        }
        pointsGameOverText.text = points.ToString();
        bestPointsGameOverText.text = bestPoints.ToString();
    }
}
