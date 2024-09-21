using UnityEngine;

public class TimeCounter
{
    private float _maxTime;
    public TimeCounter(float maxTime)
    {
        _maxTime = maxTime;
    }

    public float CurrentTime { get; private set; }
    public bool IsTimeFinished => CurrentTime >= _maxTime;

    public void UpdateTime(float passedTime)
    {
        CurrentTime += passedTime;
    }
}
