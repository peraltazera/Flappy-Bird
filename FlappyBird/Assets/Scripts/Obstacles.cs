using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    public bool end;
    public bool start;
    [SerializeField]
    private Manager manager;

    private void Update()
    {
        if(Mathf.Abs(manager.end.position.x - this.gameObject.transform.position.x) < 0.5f){
            end = true;
            this.gameObject.SetActive(false);
        }
        if(!manager.die){
            if(Mathf.Abs(manager.start.position.x - this.gameObject.transform.position.x) < 0.5f && !start){
                start = true;
                manager.EnabledObs(this.gameObject.transform);
            }
            rb.velocity = new Vector2(speed, 0);
        }
    }
}
