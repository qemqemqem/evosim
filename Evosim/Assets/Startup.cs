using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    
    public GameObject fishPrototype;
    private static Startup mainInstance;

    public static void CreateFish(Vector3 pos, Color color)
    {
        var fish = GameObject.Instantiate(mainInstance.fishPrototype);
        fish.transform.position = pos;
        fish.GetComponent<FishMover>().moveTick = Random.Range(0, 100);
        // var mat = new Material();
        fish.GetComponent<FishMover>().SetColor(color);
        fish.GetComponent<FishMover>().mass = Random.Range(0.9f, 1.1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        mainInstance = this;
        Debug.Log("Hello fish!");
        for (int i = 0; i < 100; i++)
        {
            CreateFish((new Vector3(Random.value, Random.value, Random.value) 
                        - new Vector3(0.5f, 0.5f, 0.5f)) * 20, 
                new Color(Random.value, Random.value, Random.value));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
