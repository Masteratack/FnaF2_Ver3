using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Crazy.AI
{
    public class Misje : MonoBehaviour
    {
        public Mod.Animatronik animatronik { get; set; }
        public bool Morawiecki = false;
        public NavMeshAgent agent;
        public Vector3[] vector3;
        private int index = 1;
        private GameObject Player;

        private void Start()
        {
            if (animatronik != null)
            {
                if (animatronik.W³¹czony == false)
                {
                    Debug.Log(gameObject.name + "- Wy³¹czony");
                    gameObject.SetActive(false);
                }
                agent.speed = agent.speed * animatronik.Prêdkoœæ;
            }
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        // Update is called once per frame
        void Update()
        {
            if (index < vector3.Length-1)
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
                    Debug.LogWarning("Morawiecki: P³aæ podatki!");
                    SceneManager.LoadScene(1);
                }
                else
                {
                    Debug.Log("Z³apany przez " + gameObject.name);
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}

