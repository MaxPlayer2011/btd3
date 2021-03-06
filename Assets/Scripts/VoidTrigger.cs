using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidTrigger : MonoBehaviour
{
    public Animator fade;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        fade.Play("In");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
