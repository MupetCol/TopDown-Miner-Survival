using UnityEngine;

public class ChangeParentSorLayer : MonoBehaviour
{
	[SerializeField] private int _newSortOrder;
	[SerializeField] private SpriteRenderer _renderer;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			_renderer.sortingOrder = _newSortOrder;
		}
	}
}
