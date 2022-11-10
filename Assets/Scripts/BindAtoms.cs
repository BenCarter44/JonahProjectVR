using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindAtoms : MonoBehaviour
{

    // Start is called before the first frame update
    private int atomsBound;
    void Start()
    {
        atomsBound = 0;
    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "hydrogen" && atomsBound < 2)
        {
            atomsBound += 1;
            Debug.Log(this.tag + " collided with: " + col.gameObject.tag + " total = " + atomsBound);
            
            // creates joint
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            // sets joint position to point of contact
            joint.anchor = col.contacts[0].point;
            // conects the joint to the other object
            joint.connectedBody = col.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
            // Stops objects from continuing to collide and creating more joints
            joint.enableCollision = true;
        }
    }

    void Update()
    {
      
    }
}
