using UnityEngine;

public class SetStagePopUp : MonoBehaviour
{
	[SerializeField] private GameObject _popUp;
	[SerializeField] private BoolReference _canPlayerMove;
	[SerializeField] private Animator _animator;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_canPlayerMove.Toggle();
			_popUp.SetActive(!_popUp.activeSelf);

			if(_canPlayerMove.toggle == false && _animator != null)
			{
				_animator.SetBool("DirUp", false);
				_animator.SetBool("DirLeft", false);
				_animator.SetBool("DirDown", false);
				_animator.SetBool("DirRight", false);
			}
		}
	}
}
