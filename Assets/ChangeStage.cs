using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeStage : MonoBehaviour
{
	private GameObject _currentStage;
	[SerializeField] private BoolReference _canPlayerMove;
	private TileDestroyer _destroyer;
	private TilePlacer _placer;

	private void Awake()
	{
		_destroyer = FindObjectOfType<TileDestroyer>();
		_placer = FindObjectOfType<TilePlacer>();
	}

	private void OnEnable()
	{
		_currentStage = FindObjectOfType<SetStagePopUp>().gameObject;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			int index = _currentStage.transform.GetSiblingIndex();

			if(index-1 >= 0)
			{
				// Activate new stage and set it on the scripts in charge on destroying and placing tiles
				GameObject newStage = _currentStage.transform.parent.GetChild(index - 1).gameObject;
				newStage.SetActive(true);
				_destroyer.tileMap = newStage.transform.GetChild(1).GetComponent<Tilemap>();
				_placer.tileMap = newStage.transform.GetChild(1).GetComponent<Tilemap>();

				// Deactivate old stage
				_currentStage.SetActive(false);

				// Let the player move again
				if (_canPlayerMove != null)
					_canPlayerMove.Toggle();

				// Turn off pop up
				this.gameObject.SetActive(false);
			}else
			{
				Debug.Log("No more stages above");
			}
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			int index = _currentStage.transform.GetSiblingIndex();

			if(index + 1 < _currentStage.transform.parent.childCount)
			{
				GameObject newStage = _currentStage.transform.parent.GetChild(index + 1).gameObject;
				newStage.SetActive(true);
				_destroyer.tileMap = newStage.transform.GetChild(1).GetComponent<Tilemap>();
				_placer.tileMap = newStage.transform.GetChild(1).GetComponent<Tilemap>();

				_currentStage.SetActive(false);

				if (_canPlayerMove != null)
					_canPlayerMove.Toggle();

				this.gameObject.SetActive(false);
			}else
			{
				Debug.Log("No more stages below");
			}


		}
	}
}
