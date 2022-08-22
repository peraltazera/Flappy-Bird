using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpVelocity;
    [SerializeField]
    private Transform trans;
    [SerializeField]
    public CircleCollider2D boxCol;
    [SerializeField]
    private Manager manager;

    private void Update()
    {
        if(manager.die){
            boxCol.enabled = false;
            if(this.gameObject.transform.position.y < -3){
                this.gameObject.SetActive(false);
                manager.gameoverUI.SetActive(true);
            }
        }else{
            if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1")) && !manager.die)
            {
                Jump();
            }
            if(rb.velocity.y > 0.5f && !manager.die){
                trans.eulerAngles = new Vector3(0,0,30);
            }else if(rb.velocity.y < -0.5f || manager.die){
                trans.eulerAngles = new Vector3(0,0,-30);
            }else{
                trans.eulerAngles = new Vector3(0,0,0);
            }
        }
    }

    public void Jump(){
        manager.wingSound.Play();
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            trans.eulerAngles = new Vector3(0,0,-30);
            manager.EndGame();
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Point") && !manager.die)
        {
            manager.pointSound.Play();
            manager.AddPoint();
        }
    }
}
