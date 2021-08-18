using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Crazy.AI
{
    public class Misje : MonoBehaviour
{
    public bool Morawiecki = false;
    public NavMeshAgent agent;
    public Vector3[] vector3;
    private int index = 1;
    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (index < vector3.Length)
        {
            if (!Morawiecki)
            {
                if (gameObject.transform.position.z == vector3[index].z && gameObject.transform.position.x == vector3[index].x)
                {
                    StartCoroutine(Wait(20f));
                    index++;
                }
                agent.SetDestination(vector3[index]);
            }

        }
        else
        {
            agent.SetDestination(Player.transform.position);
        }

    }
    IEnumerator Wait(float time)
    {
        float timeCoundown = time;
        while (timeCoundown <= 0)
        {
            timeCoundown -= Time.deltaTime;
            yield return 0.3;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (Morawiecki)
            {
                Debug.LogWarning("Morawiecki: P�a� podatki!");
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("Z�apany przez " + gameObject.name);
                SceneManager.LoadScene(1);
            }
        }
    }
}
}

