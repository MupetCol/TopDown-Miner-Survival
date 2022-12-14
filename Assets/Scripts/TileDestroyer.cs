using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
	public Tilemap tileMap;

	[SerializeField] private Vector3Int location;

	private Camera m_Camera;

	private void Awake()
	{
		m_Camera = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mp = m_Camera.ScreenToWorldPoint(Input.mousePosition);
			location = tileMap.WorldToCell(mp);
			tileMap.SetTile(location, null);
		}
	}
}
