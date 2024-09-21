using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private int _minCoinValue;
    [SerializeField] private int _maxCoinValue;

    private int _coinValue;

    private void Start()
    {
        _coinValue = Random.Range(_minCoinValue, _maxCoinValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            _game.PointsCounter.AddPoints(_coinValue);

            Destroy(gameObject);
        }
    }
}
