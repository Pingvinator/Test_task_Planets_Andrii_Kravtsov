using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryObject: IPlanetaryObject
{
    MassClassEnum massClass_;
    GameObject sphere;
    int speed = Random.Range(1, 90); // speed of rotation in deegrees
    public Vector3 startpos { get; private set; }
    public MassClassEnum massClass
    {
        get
        {
            
            return massClass_;
        }
        private set
        {
            massClass_=value;
        }
    }
    public double mass
    {
        get;
    }
    public float radius { get; }
    Color color;
    public PlanetaryObject( double mass, Vector3 startPos) //Constructor for the planet objects 
    {
        this.startpos = startPos;
        this.mass = mass;
        this.radius = radius;
        //Determine massClass and radius of the planet according to specsheet. Wonder if there is  a way to use the actual enum for this...
        switch (mass)
        {
            case double n when (n<=0.00001):
                massClass_ = MassClassEnum.Asteroidan;
                radius = Random.Range(0f, 0.003f);
                break;
            case double n when (n > 0.00001 && n<=0.1):
                massClass_ = MassClassEnum.Mercurian;
                radius = Random.Range(0.03f,0.7f);
                break;
            case double n when (n > 0.1 && n <= 0.5):
                massClass_ = MassClassEnum.Subterran;
                radius = Random.Range(0.5f, 1.2f);
                break;
            case double n when (n > 0.5 && n <= 2):
                massClass_ = MassClassEnum.Terran;
                radius = Random.Range(0.8f, 1.9f);
                break;
            case double n when (n > 2 && n <= 10):
                massClass_ = MassClassEnum.Superterran;
                radius = Random.Range(1.3f, 3.3f);
                break;
            case double n when (n > 10 && n <= 50):
                massClass_ = MassClassEnum.Neptunian;
                radius = Random.Range(2.1f, 5.7f);
                break;
            case double n when (n > 50 && n <= 5000):
                massClass_ = MassClassEnum.Neptunian;
                radius = Random.Range(3.5f, 27f);
                break;
        }
        //create visible sphere and set its position
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = startPos;
        sphere.transform.localScale = new Vector3(radius, radius, radius);
        sphere.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // assign random color

    }
    public void rotate(float timeDelta)
    {
        sphere.transform.RotateAround(new Vector3(0, 0,0),Vector3.forward, speed * timeDelta);
    }
}


public class PlanetarySystem : IPlanetarySystem
{
    public void update(float deltaTime)
    {
        foreach(PlanetaryObject planet in planets)
        {
            planet.rotate(deltaTime);
        }
    }
    
    LinkedList<PlanetaryObject> planets = new LinkedList<PlanetaryObject>(); // List to store planets

    public IEnumerable<IPlanetaryObject> planetaryObjects
    {
        get
        {
            return planets; 
        }
        
    }
    public Vector3 location  //Center of planetary system
    {
        get;
    }
    public float nextPlanetOffset { get; private set; }
    
    public void addPlanet(PlanetaryObject planet) //Add an instance of Planetary object to the system
    {
        if (planets.Count ==0) //Check if it is the first planet
        {
            nextPlanetOffset = 5f;
        }
        else
        {
            nextPlanetOffset+= planets.Last.Value.radius*2 + 1; //calculate distance for the next planets
        }
        planets.AddLast(planet);

    }
}
