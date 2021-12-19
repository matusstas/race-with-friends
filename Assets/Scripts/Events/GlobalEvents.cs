using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GlobalEvents
{
    public static CarStateChangedEvent CarStateChanged = new CarStateChangedEvent();
    public static CarDestroyedEvent CarDestroyed = new CarDestroyedEvent();
    public static UnityEvent CarTurnEnd = new UnityEvent();
    public static UnityEvent BoostPickedUp = new UnityEvent();
}

public class CarStateChangedEvent: UnityEvent<CarState>{}
public class CarDestroyedEvent: UnityEvent<GameObject>{}