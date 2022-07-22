using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]GameObject DeathFX;
    [SerializeField]GameObject HitVFX;
    GameObject parentGameObject;
    ScoreBoard scoreBoard;
    [SerializeField] int EnemyScore = 5;
    [SerializeField] int HitPoints = 3;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRunTime");
        AddRigidBody();

    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (HitPoints < 1)
        {
            KillEnemy();
        }   
    }

    void ProcessHit()
    {
        HitPoints -= 1;
        Debug.Log("1");
        scoreBoard.IncreaseScore(EnemyScore);
        Debug.Log("2");
        GameObject VFX = Instantiate(HitVFX, transform.position, Quaternion.identity);
        Debug.Log("3");

        VFX.transform.parent = parentGameObject.transform;
  
    }
    void KillEnemy()
    {
        GameObject FX = Instantiate(DeathFX, transform.position, Quaternion.identity);
        FX.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
        scoreBoard.IncreaseScore(EnemyScore);
        Debug.Log("killme");
    }

   
}
