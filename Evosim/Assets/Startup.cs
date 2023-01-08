using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    
    public GameObject fishPrototype;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello fish!");
        for (int i = 0; i < 100; i++)
        {
            var fish = GameObject.Instantiate(fishPrototype);
            fish.transform.position = (new Vector3(Random.value, Random.value, Random.value) 
                                       - new Vector3(0.5f, 0.5f, 0.5f)) * 20 ;
            fish.GetComponent<FishMover>().moveTick = Random.Range(0, 100);
            // var mat = new Material();
            fish.GetComponent<FishMover>().SetColor(new Color(Random.value, Random.value, Random.value));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
