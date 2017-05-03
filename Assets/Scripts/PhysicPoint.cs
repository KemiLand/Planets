using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicPoint : MonoBehaviour {
    Rigidbody2D m_Body;
    float wantedVelocity = 3.0f * Mathf.PI;
    [SerializeField]
    float ray = 0.0f;
    [SerializeField]
    float velocity;
	// Use this for initialization
	void Start () {
        m_Body = GetComponent<Rigidbody2D>();
        //m_Body.velocity = new Vector2(0.0f, wantedVelocity);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ray = transform.position.magnitude;
        m_Body.AddForce(Mathf.Pow(wantedVelocity, 2.0f) / ray * (-transform.position.normalized));
        
        velocity = m_Body.velocity.magnitude;
    }
}
