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

    // Start is called before the first frame update
    void Start()
    {
    }
    
    
    void OnCollisionEnter(Collision col) {
        Debug.Log("I collided!");

        var otherFish = col.gameObject;

        float myScore = mass;
        float theirScore = otherFish.GetComponent<FishMover>().mass;

        if (myScore < theirScore)
            gameObject.SetActive(false);
        else
        {
            mass += theirScore;
            direction += direction.normalized * 0.2f;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f) * Mathf.Pow(mass, 0.333f);
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
        if (Time.frameCount % 100 == moveTick)
            direction = direction + (new Vector3(Random.value, Random.value, Random.value) 
                                     - new Vector3(0.5f, 0.5f, 0.5f)) * Time.deltaTime * 100f;
        gameObject.transform.position = gameObject.transform.position + direction * Time.deltaTime;
        gameObject.transform.forward = Vector3.Normalize(direction);

        if (gameObject.transform.position.magnitude > 25f)
        {
            gameObject.transform.position = gameObject.transform.position.normalized * 25f;
            direction = direction * -1;
        }
    }
}
