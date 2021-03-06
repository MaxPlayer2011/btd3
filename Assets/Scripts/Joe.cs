using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Joe : MonoBehaviour
{
    public bool attacking;
    public bool killing;
    private GC_Finale gc;
    private NavMeshAgent agent;
    public AudioClip die;
    public Transform diePos;
    public Image fade;
    
    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GC_Finale>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (attacking)
        {
            if (!killing)
            {
                if (Vector3.Distance(transform.position, gc.player.position) > 5f)
                {
                    if (PlayerPrefs.GetInt("finaleFix") == 0)
                    {
                        agent.speed = 70f;
                    }

                    else
                    {
                        agent.speed = 20f;
                    }
                }

                else
                {
                    agent.speed = 5f;
                }

                agent.SetDestination(gc.player.position);
            }
        }

        else
        {
            agent.ResetPath();
        }

        if (killing)
        {
            gc.player.GetComponent<Player>().enabled = false;
            gc.player.position = diePos.position;
            gc.player.rotation = diePos.rotation;
            gc.player.GetComponent<Player>().cameraScript.transform.localRotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & attacking)
        {
            killing = true;
            AudioSource mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
            mainMus.Stop();
            mainMus.PlayOneShot(die, 2f);
            StartCoroutine(Die());
            StartCoroutine(Fade());
            StartCoroutine(FadeJoeSmile());
            GameObject.Find("Hud").SetActive(false);
            PlayerPrefs.SetInt("respawn", 1);
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(die.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Finale");
    }

    private IEnumerator Fade()
    {
        for (float i = 0f; i >= 0; i += Time.deltaTime * 0.1f)
        {
            fade.color = new Color(0f, 0f, 0f, i);
            yield return null;
        }
    }

    private IEnumerator FadeJoeSmile()
    {
        yield return new WaitForSeconds(die.length - 5f);
        for (float i = 1f; i >= 0; i -= Time.deltaTime * 0.5f)
        {
            gc.joeSprite.color = new Color(1f, 1f, 1f, i);
            yield return null;
        }
    }
}
