using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private int _maxPoints;
    [SerializeField] private Player _player;

    private TimeCounter _timeCounter;

    public PointsCounter PointsCounter { get; private set; }
    public bool IsFinished { get; private set; } = false;

    private void Start()
    {
        _timeCounter = new TimeCounter(_maxTime);
        PointsCounter = new PointsCounter(_maxPoints);
    }

    private void Update()
    {
        if (IsFinished)
            return;

        _timeCounter.UpdateTime(Time.deltaTime);

        Debug.Log(Mathf.Round(_timeCounter.CurrentTime));

        if (_timeCounter.IsTimeFinished)
            LoseGame();

        if (PointsCounter.IsOverMaxPoints)
            WinGame();

    }

    private void LoseGame()
    {
        Debug.Log("Вы не успели собрать нужное кол-во монет, время вышло");

        IsFinished = true;
    }

    private void WinGame()
    {
        Debug.Log($"Победа!Вы собрали {PointsCounter.TotalPoints} монет");

        IsFinished = true;
    }



}
