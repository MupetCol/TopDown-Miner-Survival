using UnityEngine;

public class ChangeParentSorLayer : MonoBehaviour
{
	[SerializeField] private int _newSortOrder;
	[SerializeField] private int _newLayer;

	[SerializeField] private bool _changeCollision;

	[SerializeField] private SpriteRenderer _renderer;

	private void Awake()
	{
		_renderer = transform.parent.parent.GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			_renderer.sortingOrder = _newSortOrder;

			if(_changeCollision)
			_renderer.transform.gameObject.layer = _newLayer;
		}
	}
}
