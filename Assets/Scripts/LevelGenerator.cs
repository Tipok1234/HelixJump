using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _helixGeneration;
    [SerializeField] private GameObject _lastHelix;
    [SerializeField] private float _distanceHelix = 6f;
    [SerializeField] private float _ySpawn = 0;

    private GameObject[] _go;
    private int _numberHelix;

    public void PrepareLevel(int floorCount)
    {
        _numberHelix = floorCount;

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
        GameObject go = Instantiate(_helixGeneration[helixIndex], transform.up * _ySpawn, _helixGeneration[helixIndex].transform.rotation);
        go.transform.parent = transform;
        _ySpawn -= _distanceHelix;
        GameObject[] _go = new GameObject[_helixGeneration.Length];
        _go[helixIndex] = go;
    }

    public void ClearLevel()
    {
        for (int i = 0; i < _go.Length; i++)
        {
            Destroy(_go[i]);
        }
    }
}
