using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	#region PRIVATE_VARIABLES

	[SerializeField] private float _speed = 1f;
	[SerializeField] private BoolReference _canMove;
	private Animator _animator;

	#endregion


	#region UNITY_METHODS

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (_canMove.toggle)
		{
			Move();
		}		
	}

	private void Move()
	{
		Vector3 totalMovement = Vector3.zero;


		// Each key adds to the total movement so it can be normalized before sent
		// Also sets animator bool on key press

		if (Input.GetKey(KeyCode.W))
		{
			totalMovement += transform.up;

			if (_animator != null)
				_animator.SetBool("DirUp", true);
		}

		if (Input.GetKey(KeyCode.A))
		{
			totalMovement -= transform.right;
			//transform.localScale = new Vector3(-1, 1, 1);

			if (_animator != null)
				_animator.SetBool("DirLeft", true);
		}

		if (Input.GetKey(KeyCode.S))
		{
			totalMovement -= transform.up;

			if (_animator != null)
				_animator.SetBool("DirDown", true);
		}

		if (Input.GetKey(KeyCode.D))
		{
			totalMovement += transform.right;

			if (_animator != null)
				_animator.SetBool("DirRight", true);
			//transform.localScale = new Vector3(1, 1, 1);
		}

		if (_animator != null)
		{
			// For reseting animators bool when each key is no longer pressed
			if (Input.GetKeyUp(KeyCode.W))
			{
				_animator.SetBool("DirUp", false);
			}
			if (Input.GetKeyUp(KeyCode.A))
			{
				_animator.SetBool("DirLeft", false);
			}
			if (Input.GetKeyUp(KeyCode.S))
			{
				_animator.SetBool("DirDown", false);
			}
			if (Input.GetKeyUp(KeyCode.D))
			{
				_animator.SetBool("DirRight", false);
			}
		}

		transform.Translate(totalMovement.normalized * Time.deltaTime * _speed);
		_animator.SetFloat("Speed", Mathf.Abs(totalMovement.x * _speed + totalMovement.y * _speed));
	}

	#endregion
}

