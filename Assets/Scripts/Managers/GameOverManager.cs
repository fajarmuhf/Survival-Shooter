using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text warningText;
    public PlayerHealth playerHealth;       
    public float restartDelay = 5f;
    int mulas = 0;
    public bool aktifSpeed = false;
    public bool aktifHeal = false;
    int mulas2 = 0;
    int mulas3 = 0;


    Animator anim;                          
    float restartTimer;                    


    void Awake()
    {
        anim = GetComponent<Animator>();
        mulas = 0;
    }


    void Update()
    {
        if (aktifSpeed)
        {
            mulas2++;
            if (mulas2 == 1)
            {
                StartCoroutine(SpeedNormal(GameObject.Find("Player").transform, GameObject.Find("Diamond").gameObject));
            }
        }
        if (aktifHeal)
        {
            mulas3++;
            if (mulas3 == 1)
            {
                StartCoroutine(Healing(GameObject.Find("Player").transform, GameObject.Find("Diamond_Red").gameObject));
            }
        }
        if (playerHealth.currentHealth <= 0)
        {
            mulas++;
            if(mulas==1)
            anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }

    public IEnumerator SpeedNormal(Transform collider,GameObject go)
    {
        collider.GetComponent<PlayerMovement>().speed = 12f;
        Destroy(go);
        yield return new WaitForSeconds(5f);
        collider.GetComponent<PlayerMovement>().speed = 6f;
        mulas2 = 0;
        aktifSpeed = false;
    }

    public IEnumerator Healing(Transform collider, GameObject go)
    {
        yield return new WaitForSeconds(.0f);
        collider.GetComponent<PlayerHealth>().currentHealth += 20;
        collider.GetComponent<PlayerHealth>().healthSlider.value = collider.GetComponent<PlayerHealth>().currentHealth;
        Destroy(go);
        mulas3 = 0;
        aktifHeal = false;
    }
}