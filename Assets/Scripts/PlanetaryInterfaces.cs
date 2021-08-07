using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This file contains interfaces and datatypes for interaction with other scripts
public interface IPlanetarySystemFactory
{
    IPlanetarySystem create(double mass);
}
public interface IPlanetarySystem
{
    IEnumerable<IPlanetaryObject> planetaryObjects { get; }
    void update(float deltaTime);
}

public enum MassClassEnum
{
    Asteroidan,
    Mercurian,
    Subterran,
    Terran,
    Superterran,
    Neptunian,
    Jovian
}
public interface IPlanetaryObject
{
    MassClassEnum massClass { get; }
    double mass { get; }
}
