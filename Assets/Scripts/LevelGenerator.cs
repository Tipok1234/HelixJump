using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int NumberHelix => _numberHelix;

    [SerializeField] private GameObject[] _helixGeneration;
    [SerializeField] private GameObject _lastHelix;
    [SerializeField] private float _distanceHelix = 6f;
    [SerializeField] private float _ySpawn = 0;
    private int _numberHelix;

    private void Start()
    {
        _numberHelix = GameManager._currentLevelIndex + 5;

        for (int i = 0; i < _numberHelix; i++)
        {
            if (i == 0)
                SpawnHelix(0);
            else
                SpawnHelix(Random.Range(1, _helixGeneration.Length - 1));
        }
        SpawnHelix(_helixGeneration.Length - 1);
    }

    private void SpawnHelix(int helixIndex)
    {
        GameObject go = Instantiate(_helixGeneration[helixIndex], transform.up * _ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        _ySpawn -= _distanceHelix;
    }
}
