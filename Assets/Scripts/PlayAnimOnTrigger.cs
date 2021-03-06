using UnityEngine;

public class PlayAnimOnTrigger : MonoBehaviour
{
    public Animator anim;
    public string animName;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play(animName);
            Destroy(gameObject);
        }
    }
}
