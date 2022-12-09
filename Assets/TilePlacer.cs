using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour
{
	[SerializeField] private Tilemap tiles;
	[SerializeField] private RuleTile tile;

	[SerializeField] private Vector3Int location;

	private Camera m_Camera;

	private void Awake()
	{
		m_Camera = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Vector3 mp = m_Camera.ScreenToWorldPoint(Input.mousePosition);
			location = tiles.WorldToCell(mp);

			//Check if there's a tile on that position, else place a new tile
			if(tiles.GetTile(location) == null)
			tiles.SetTile(location, tile);
		}
	}
}
