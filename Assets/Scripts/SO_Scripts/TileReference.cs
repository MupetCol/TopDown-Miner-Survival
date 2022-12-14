using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(menuName = "TileReference", fileName = "TileSO")]
public class TileReference : ScriptableObject
{
	public Tile tile;
	public RuleTile ruletile;

	public bool reset;

	private void OnEnable()
	{
		hideFlags = HideFlags.DontUnloadUnusedAsset;
		if (reset)
		{
			tile = null;
			ruletile = null;
		}
			
	}

	public void ResetValues()
	{
		tile = null;
		ruletile = null;
	}
}
