using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMover : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public int moveTick = 0;
    public float mass = 1;
    public GameObject myCapsule;
    public Color myColor = Color.white;
    
    float eatTimer = 1; // Seconds

    // Start is called before the first frame update
    void Start()
    {
    }
    
    
    void OnCollisionEnter(Collision col)
    {
        if (eatTimer > 0)
            return; // Eating is so tiring sometimes
        
        Debug.Log("I collided!");

        var otherFish = col.gameObject;

        if (myColor == otherFish.GetComponent<FishMover>().myColor)
            return; // Don't eat family

        float myScore = mass;
        float theirScore = otherFish.GetComponent<FishMover>().mass;

        if (myScore > theirScore)
        {
            otherFish.SetActive(false);
            direction += direction.normalized * 0.2f;
            mass += theirScore;

            if (mass >= 5)
            {
                mass -= 4f;
                eatTimer = 2f;
                for (int i = 0; i < 4; i++)
                {
                    Startup.CreateFish(gameObject.transform.position, myColor);
                }
            }
        }
    }

    public void SetColor(Color color)
    {
        myColor = color;
        myCapsule.GetComponent<MeshRenderer>().materials[0].SetColor("_Color", color);
    }


    // Update is called once per frame
    void Update()
    {
        eatTimer -= Time.deltaTime;
        
        if (Time.frameCount % 100 == moveTick)
            direction = direction + (new Vector3(Random.value, Random.value, Random.value) 
                                     - new Vector3(0.5f, 0.5f, 0.5f)) * Time.deltaTime * 100f;
        gameObject.transform.position = gameObject.transform.position + direction * Time.deltaTime;
        gameObject.transform.forward = Vector3.Normalize(direction);

        // Keep them in a sphere
        if (gameObject.transform.position.magnitude > 25f)
        {
            gameObject.transform.position = gameObject.transform.position.normalized * 25f;
            direction = direction * -1;
        }
        
        // Set size
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f) * Mathf.Pow(mass, 0.333f);
    }
}
