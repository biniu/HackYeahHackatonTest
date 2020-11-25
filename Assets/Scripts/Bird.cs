using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
	[SerializeField] private float _launchForce = 1000;
	[SerializeField] private float _maxDragDistance = 3.5f;

	private Vector2 _startPosition;
	Rigidbody2D _rigidbody2D;
	SpriteRenderer _spriteRenderer;

	// Awake is called when the script instance is being loaded
	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Start is called before the first frame update
	private void Start()
	{
		_startPosition = _rigidbody2D.position;
		_rigidbody2D.isKinematic = true;
	}

	private void OnMouseDown()
	{
		_spriteRenderer.color = Color.red;
	}

	private void OnMouseUp()
	{
		Vector2 currentPosition = _rigidbody2D.position;
		Vector2 direction = _startPosition - currentPosition;
		direction.Normalize();

		_rigidbody2D.isKinematic = false;
		_rigidbody2D.AddForce(direction * _launchForce);

		_spriteRenderer.color = Color.white;
	}

	private void OnMouseDrag()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 desiredPosition = mousePosition;

		float distance = Vector2.Distance(desiredPosition, _startPosition);
		if (distance > _maxDragDistance)
		{
			Vector2 diretion = desiredPosition - _startPosition;
			diretion.Normalize();
			desiredPosition = _startPosition + (diretion * _maxDragDistance);
		}

		if (desiredPosition.x > _startPosition.x)
			desiredPosition.x = _startPosition.x;

		_rigidbody2D.position = desiredPosition;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		StartCoroutine(ResetAfterDelay());
	}

	private IEnumerator ResetAfterDelay()
	{
		yield return new WaitForSeconds(3);
		_rigidbody2D.position = _startPosition;
		_rigidbody2D.isKinematic = true;
		_rigidbody2D.velocity = Vector2.zero;
	}
}
