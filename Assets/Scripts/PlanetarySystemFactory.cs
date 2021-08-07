using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystemFactory :IPlanetarySystemFactory
{
    double[] generatePlanetSizes(double mass, int planetCount) // This methods randomly generates multipliers to randomly distribute system mass across planets
    {
        double[] planetSizes = new double[planetCount];
        double[] planetMassFractions = new double[planetCount];
        double sumOfFractions = 0;
        for (int i = 0; i < planetCount; i++) //Generate random numbers and sum them up
        {
            planetMassFractions[i] = Random.Range(1, 5);
            sumOfFractions += planetMassFractions[i];
        }
        for (int i = 0; i < planetCount; i++)// divide numbers generated before to get multiplier and multiply total mass to get individual planet mass
        {
            planetSizes[i] = (planetMassFractions[i] / sumOfFractions) * mass;
        }
        return planetSizes;
    }
    public IPlanetarySystem create(double mass)
    {
        PlanetarySystem system = new PlanetarySystem();
        int numOfPlanets = Random.Range(3, 15);
        double[] planetSizes = generatePlanetSizes(mass, numOfPlanets);
        for (int i = 0; i < numOfPlanets; i++)
        {
            system.addPlanet(new PlanetaryObject(planetSizes[i], new Vector3(system.nextPlanetOffset,0,0))); //system.NextPlanetOffset returns plants radius+1 to avoid collisons
        }
            return system;

    }
}
