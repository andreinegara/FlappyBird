using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstacles;
    private float randomY;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 3f;

        //InvokeRepeating("createObstacles", waitTime, waitTime);
        StartCoroutine(Wait(waitTime));
        //createObstacles();
       
  
    }


    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            createObstacles();
            
            yield return new WaitForSeconds(waitTime);
            
        }
    }

   


    

    void createObstacles()
    {
        //Generates a random value that will be added to the Y Spawn Location
        randomY = Random.Range(-2f, 2f);

        //Creates a new vector at present position adding the random Y previously generated
        Vector2 pos = new Vector2(transform.position.x, transform.position.y+randomY);

        //Instatiates Obstacle prefab on the new position
        Instantiate(obstacles, pos, transform.rotation);
    }
}
