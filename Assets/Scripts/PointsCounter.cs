using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter
{
    private int _maxPoints;

   public PointsCounter(int maxPoints)
    {
        _maxPoints = maxPoints;
    }

    public int TotalPoints { get; private set; } = 0;

    public bool IsOverMaxPoints => TotalPoints >= _maxPoints;

    public void AddPoints(int points) => TotalPoints += points;


}
