using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    private IEnumerator Start()
    {
        PlayerPrefs.SetInt("respawn", 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Warning");
    }
}