using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformMM : MonoBehaviour
{
	public Vector3 finishPos = Vector3.zero;
	public float speed = 0.55f;
	private Vector3 _startPos;
	private float _trackPercent = 0;
	private int _direction = 1;
	
	void Start() {
		_startPos = transform.position;
	}
	
	void Update() {
		_trackPercent += _direction * speed * Time.deltaTime;
		float x = (finishPos.x - _startPos.x) * _trackPercent + _startPos.x;
		float y = (finishPos.y - _startPos.y) * _trackPercent + _startPos.y;
		transform.position = new Vector3(x, y, _startPos.z);
		
		if ((_direction == 1 && _trackPercent > 0.9f) || (_direction == -1 && _trackPercent < 0.1f)) {
			_direction *= -1; //platform reverses direction
		}
	}
}