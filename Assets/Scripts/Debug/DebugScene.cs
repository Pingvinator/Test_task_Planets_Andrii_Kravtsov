using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScene : MonoBehaviour
{

    //Script to call creation of planet system for demo purposes
    PlanetarySystem sys;
    // Start is called before the first frame update
    void Start()
    {
        PlanetarySystemFactory fact = new PlanetarySystemFactory();
        sys =(PlanetarySystem)fact.create(100);
        
    }

    // Update is called once per frame
    void Update()
    {
        sys.update(Time.deltaTime);
    }
}
