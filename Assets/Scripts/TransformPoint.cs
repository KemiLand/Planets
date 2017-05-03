using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPoint : MonoBehaviour {

    [SerializeField] Transform bluePlanet;
    [SerializeField] Transform sun;
    [SerializeField] Rigidbody2D m_BlueBody;
    [SerializeField] Rigidbody2D m_SunBody;
    [SerializeField] Vector3 wantedForce;
    [SerializeField] Vector3 distance;
    [SerializeField] Vector3 acceleration;
    [SerializeField] Vector3 velocity;
    float wantedVelocity = 3.0f * Mathf.PI;
    float ray;

    //
    //Need demo, j'arrive pas a grand chose
    //

    void Start()
    {
        m_BlueBody = GetComponent<Rigidbody2D>();
        //m_BlueBody.velocity = new Vector2(0.0f, wantedVelocity);
    }

    void FixedUpdate ()
    {
        ray = transform.position.magnitude;
        distance = sun.transform.position - bluePlanet.transform.position;
        wantedForce = distance * (m_SunBody.mass * m_BlueBody.mass / (transform.position - sun.transform.position).magnitude);

        //Pas trop sûr de l'utilisation d'Addforce, mes forces donnent des trajectoires bizarres
        //m_Body.AddForce(Mathf.Pow(wantedForce, 2.0f) / ray * (-transform.position.normalized));

        acceleration = wantedForce / m_BlueBody.mass;
        velocity = acceleration * Time.deltaTime + velocity;
        transform.position += Time.deltaTime * velocity;
    }
}
