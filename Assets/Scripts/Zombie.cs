using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombie : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip lost_father;

    public NavMeshAgent agent;
    private Transform playerPos;
    [Range(2f, 5f)]
    public float maxDistance = 3;
    public static int ZsDead = 0;
    private Animator animator;
    
    private GameObject GameOverPanel;
    public float Health = 100;
    private GunManager gunManager;
    // Start is called before the first frame update
    public int get_ZsDead()
    {
        return ZsDead;
    }
    void Start()
    {

        animator = GetComponent<Animator>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        GameObject ui = GameObject.Find("Ui");
        //GameOverPanel = ui.transform.GetChild(3).gameObject;
        gunManager = GameObject.Find("Player").GetComponent<GunManager>();

    }

    // Update is called once per frame
    public float tt=4f;
    void Update()
    {
        tt -= Time.deltaTime;
        if (tt < 0)
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    {
                        PlaySound(lost_father);
                    }; break;
                default: break;
            }
            tt = 8f;
        }
        agent.SetDestination(playerPos.position);
        CheckDamage();
        CheckHealth();

    }
    void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    void CheckDamage()
    {
        if (agent.isStopped)
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, playerPos.position)) >= maxDistance)
            {
                agent.isStopped = false;
                agent.SetDestination(playerPos.position);
                //agent.updateRotation = true;
                animator.SetBool("Attack", false);

            }
        }
        else
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, playerPos.position)) <= maxDistance)
            {
                agent.isStopped = true;
                //agent.updateRotation = false;


             
                animator.SetBool("Attack", true);
                //Vector3 directionToPlayer = (playerPos.position - transform.position);
                //directionToPlayer.y = 0;
                //if (directionToPlayer != Vector3.zero)
                //{
                //    transform.rotation = Quaternion.LookRotation(directionToPlayer);
                //}
            }


        }
    }

    void CheckHealth()
    {
        if (Health <= 0)
        {
            animator.SetBool("dead", true);
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                Destroy(collider);
            }

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Destroy(rb);
            }
            agent.enabled = false;

            StartCoroutine(DestroyAfterDelay(3f));
          
        }

    }
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ZsDead++;
        Destroy(gameObject);
    }


    //private System.Collections.IEnumerator OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        while (Mathf.Abs(Vector3.Distance(transform.position, playerPos.position)) <= maxDistance)
    //        {
    //            yield return new WaitForSeconds(1);
    //            gunManager.playerManager.PlayerHealth -= 15;
    //            //yield return new WaitForSeconds(1.5f);
    //        }
    //    }
    //    else if (other.CompareTag("Bullet"))
    //    {
    //        Health -= gunManager.BulletNeed;

    //    }

    //}
    private float timer = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //timer = 1f;
            StartCoroutine(AttackPlayer());
        }
        else if (other.CompareTag("Bullet"))
        {
            Health -= gunManager.BulletNeed;
        }
    }

    private IEnumerator AttackPlayer()
    {
        while ((Mathf.Abs(Vector3.Distance(transform.position, playerPos.position)) <= maxDistance))
        {
            //if ((timer -= Time.time) > 0) continue;
            yield return new WaitForSeconds(1f);
            if (Mathf.Abs(Vector3.Distance(transform.position, playerPos.position)) <= maxDistance)
                gunManager.playerManager.PlayerHealth -= 15;
            else yield return new WaitForSeconds(0);
            yield return new WaitForSeconds(1.5f);
            //if ((timer -= Time.time) < 0) timer = 1f;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        gunManager.playerManager.PlayerHealth -= 25;
    //    }
    //    else if (other.CompareTag("Bullet"))
    //    {
    //        Health -= gunManager.BulletNeed;

    //    }

    //}

    void LateUpdate()
    {
        // Rotate towards player during attack
        if (animator.GetBool("Attack") && Health > 0)
        {
            Vector3 directionToPlayer = (playerPos.position - transform.position).normalized;
            directionToPlayer.y = 0; // Lock to Y-axis
            if (directionToPlayer != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
                Debug.Log($"Zombie {gameObject.name} rotating to face player: {transform.rotation.eulerAngles}");
            }
        }
    }
}

