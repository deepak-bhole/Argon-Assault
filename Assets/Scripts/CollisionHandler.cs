using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] ParticleSystem crashVFX;
    [SerializeField] AudioSource audioSource;


    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        audioSource.Play();
        GetComponent<Player_controller>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        MeshRenderer[] rs = GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer r in rs)
            r.enabled = false;
 
        Invoke("reLoadLevel", levelLoadDelay);
    }

    void reLoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
