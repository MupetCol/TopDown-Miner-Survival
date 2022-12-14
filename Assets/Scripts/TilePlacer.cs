using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour
{
	public Tilemap tileMap;
	[SerializeField] private TileReference tile;

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
			location = tileMap.WorldToCell(mp);

			//Check if there's a tile on that position, else place a new tile
			if(tileMap.GetTile(location) == null)

			//Check the SO for a valir tile/ruletile to set on the spot
			if(tile.tile != null)
				{
					tileMap.SetTile(location, tile.tile);
				}
			else if(tile.ruletile != null)
				{
					tileMap.SetTile(location, tile.ruletile);
				}
			
		}
	}
}
