using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _helixGeneration;
    [SerializeField] private GameObject _lastHelix;
    [SerializeField] private float _distanceHelix = 6f;
    [SerializeField] private float _ySpawn = 0;

    [SerializeField] private float _rotationHelix;

    private GameObject[] _go;
    private int _numberHelix;

    private void Update()
    {
        //gameObject.transform.Rotate(0, _rotationHelix * Time.deltaTime, 0);
    }
    public void PrepareLevel(int floorCount)
    {
        _ySpawn = 0f;
        _go = new GameObject[floorCount];
        _numberHelix = floorCount;

        for (int i = 0; i < _numberHelix; i++)
        {
            if (i == 0)
                SpawnHelix(0,i);
            else
                SpawnHelix(Random.Range(1, _helixGeneration.Length - 1), i);
        }
        SpawnHelix(_helixGeneration.Length - 1,floorCount -1);
    }

    private void SpawnHelix(int helixIndex, int i)
    {
        GameObject go = Instantiate(_helixGeneration[helixIndex], transform.up * _ySpawn, _helixGeneration[helixIndex].transform.rotation);
        go.transform.parent = transform;
        _ySpawn -= _distanceHelix;
        _go[i] = go;
    }

    public void ClearLevel()
    {
        for (int i = 0; i < _go.Length; i++)
        {
            _go[i].SetActive(false);
            //Destroy(_go[i]);
        }
    }
}
