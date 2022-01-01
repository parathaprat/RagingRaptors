using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBird : MonoBehaviour
{
  [SerializeField] float _lauchForce = 500;
  [SerializeField] float _maxDragDistance = 3;

  Vector2 _startPosition;
  Rigidbody2D _rigidbody2D;
  SpriteRenderer _spriteRenderer;

  public bool isDragging { get; private set; }

    void Awake()
    {
      _rigidbody2D = GetComponent<Rigidbody2D>();
      _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
      _startPosition = _rigidbody2D.position;
      _rigidbody2D.isKinematic = true;
    }

    void OnMouseDown()
    {
      _spriteRenderer.color = Color.green;
      isDragging = true;
    }

    void OnMouseUp()
    {
      Vector2 currentPosition = _rigidbody2D.position;
      Vector2 direction = _startPosition - currentPosition;
      direction.Normalize();

      _rigidbody2D.isKinematic = false;
      _rigidbody2D.AddForce(direction * _lauchForce);

      _spriteRenderer.color = Color.white;
      isDragging = false;
    }

    void OnMouseDrag()
    {
      Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector2 desiredPosition = mousePosition;

      float distance = Vector2.Distance(desiredPosition, _startPosition);
      if(distance > _maxDragDistance)
      {
        Vector2 direction = desiredPosition - _startPosition; 
        direction.Normalize();
        desiredPosition = _startPosition + (direction * _maxDragDistance);
      }

      if(desiredPosition.x > _startPosition.x)
        desiredPosition.x = _startPosition.x;

      _rigidbody2D.position = desiredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
      yield return new WaitForSeconds(3);
      _rigidbody2D.position = _startPosition;
      _rigidbody2D.isKinematic = true;
      _rigidbody2D.velocity = Vector2.zero;
    }
}
