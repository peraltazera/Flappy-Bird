using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer rend;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Manager manager;

    private void Update()
    {
        // if(!manager.die){
        //     rend.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        // }
        rend.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
