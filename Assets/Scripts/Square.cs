using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Square : MonoBehaviour
{
    
    void Start()
    {
        //À§Ä¡ ·£´ý
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector3(x, y, 0);

        //»çÀÌÁî ·£´ý

        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(size, size, 0); 
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }
}
