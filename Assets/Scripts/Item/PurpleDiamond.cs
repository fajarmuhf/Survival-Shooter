using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleDiamond : MonoBehaviour
{
    public GameOverManager gameOverManager;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            gameOverManager.aktifSpeed = true;
            //Destroy(this.transform.parent.gameObject);
        }
    }
}
