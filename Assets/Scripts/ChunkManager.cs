using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkManager : MonoBehaviour
{
	public int moveSpeed = 5;
    public List<GameObject> chunks = new List<GameObject>();
    private float _screenWidthGameUnits;
	private bool added = false;

	private List<GameObject> _chunkClones = new List<GameObject>();

    void Awake()
    {
        this._screenWidthGameUnits = this.getHalfScreenWidth();
    }

    void Start()
    {
		for (int i = 0; i < 3; i++)
		{
			_chunkClones.Add(getRandomChunk(Vector3.zero));
		}
		for (int j = 0; j < _chunkClones.Count; j++)
		{
			_chunkClones[j].transform.position = new Vector3(j * getHalfScreenWidth()-getChunkWidth(_chunkClones[j]),0);
		}

		_chunkClones[0].transform.position = new Vector3 (0 - _screenWidthGameUnits, 0);

		Vector3 eersteChunkPos = _chunkClones[0].transform.position;
		for (int k = 0; k < _chunkClones.Count; k++)
		{
			_chunkClones[k].transform.position = new Vector3(eersteChunkPos.x+getChunkWidth(_chunkClones[k])*k,0);
		}
    }

    void Update()
    {
		if (added) {
			_chunkClones.Add(getRandomChunk(Vector3.zero));
			added = false;
		}
		sortChunks (_chunkClones);
		for (int i = 0;i < _chunkClones.Count; i++)
		{
			moveChunk(_chunkClones[i],moveSpeed);
			if(checkBoundsChunk(_chunkClones[i]) == true)
			{
				Destroy(_chunkClones[i]);
				_chunkClones.RemoveAt(i);
				added = true;
			}
		}

    }

    private void sortChunks(List<GameObject> _chunks)
    {
        if (_chunks.Count<1)
        {
            Debug.Log("Error sort chunk! list heeft geen elementen");
            return;
        }
        var l_firstChunkV3 = _chunks[0].transform.position;
        for (int i = 0; i < _chunks.Count; i++)
        {
            _chunks[i].transform.position = new Vector3(l_firstChunkV3.x + (getChunkWidth(_chunks[i]) * i), 0);
        }
    }

    private bool checkBoundsChunk(GameObject _chunk)
    {
        if (_chunk.transform.position.x < 0 - (_screenWidthGameUnits + getChunkWidth(_chunk) / 2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void moveChunk(GameObject _chunk, float _speed)
    {
        _chunk.transform.position -= new Vector3(_speed * Time.deltaTime, 0);
    }

    private GameObject getRandomChunk(Vector3 _position)
    {
        return spawnChunk(chunks[Random.Range(0, chunks.Count)], _position);
    }
	
    private GameObject spawnChunk(GameObject _chunk, Vector3 _position)
    {
        return (GameObject)Instantiate(_chunk, _position, Quaternion.identity);
    }

    private float getChunkWidth(GameObject _chunk)
    {
        return _chunk.GetComponent<BoxCollider2D>().size.x;
    }

    private float getHalfScreenWidth()
    {
        return (Camera.main.orthographicSize / Camera.main.pixelHeight * Camera.main.pixelWidth);
    }
}
