using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

public class MoleculeFloat : MonoBehaviour
{
    public int electroNeg = 0;
    private int electronFull = 0;
    public GameObject me;
    private float temperature;
    public List<GameObject> bondedTo;
    // Public variable to set the distance
   /* public float _distance;
    
    // Variables for floating
    private Vector3 _top, _bottom, _left, _right;
    private float _percent = 0.0f;
    private float _speed = 0.1f;
   */
    private Vector3 scaledDirection;
   // public Direction _direction;

    // Define direction up and down
   // public enum Direction { UP, DOWN, LEFT, RIGHT };
    private Random rd;


    private Vector3 velocity;

    public int getElectronFill()
    {
        return electronFull;
    }
    public void steal()
    {
        electroNeg = 0;
    }

    // Set the direction to up, and the locations
    void Start()
    {
        temperature = Temperature.temperature;
        bondedTo = new List<GameObject>();

        rd = new Random();
        /*
        _top = new Vector3(transform.position.x,
                           transform.position.y + _distance,
                           transform.position.z);

        _bottom = new Vector3(transform.position.x,
                       transform.position.y - _distance,
                       transform.position.z);
        
        _left = _bottom = new Vector3(transform.position.x - _distance,
                       transform.position.y,
                       transform.position.z);

        _right = _bottom = new Vector3(transform.position.x + _distance,
                       transform.position.y,
                       transform.position.z);

        */
        float i = (float)rd.NextDouble();
        Vector3 rDir = new Vector3((float)rd.NextDouble(), (float)rd.NextDouble(), (float)rd.NextDouble());
        rDir = Vector3.Normalize(rDir); // now rDir is normalized. 

        scaledDirection = rDir * temperature;
        Rigidbody movement = me.GetComponent<Rigidbody>();
       // movement.velocity = scaledDirection;
        movement.AddForce(scaledDirection,ForceMode.Impulse);
        
     //   Debug.Log("START");
     //   Debug.Log(movement.velocity);
    //    Debug.Log(movement.mass);


    }

    void Update()
    {
        // ApplyFloatingEffect();
        //  ApplyRotationEffect();
        //Debug.Log(scaledDirection);
        //    Debug.Log(me.GetComponent<Rigidbody>().velocity);
     //   Rigidbody movement = me.GetComponent<Rigidbody>();
     //   movement.velocity = scaledDirection;

      //  me.transform.position = me.transform.position + scaledDirection * Time.deltaTime;
        if(electroNeg < 0 && bondedTo != null)
        {
            // master... bond!
            bool lr = true; // only works for two right now.
            foreach (GameObject ob in bondedTo)
            {
                ob.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Vector3 adj;
                if (lr)
                {
                    adj = new Vector3(-0.5001f, 0, 0.866026f);
                }
                else
                {
                    adj = new Vector3(0.5001f, 0, 0.866026f);
                }
                ob.transform.position = me.transform.position + adj;
                lr = !lr;
            }
        }
      // if bonded...
        

    }
   /*
    // Apply the floating effect between the given positions
    void ApplyFloatingEffect()
    {
        if (_direction == Direction.UP && _percent < 1)
        {

            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_top, _bottom, _percent);
        }
        else if (_direction == Direction.DOWN && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_bottom, _top, _percent);
        }
        else if (_direction == Direction.LEFT && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_left, _right, _percent);
        }
        else if (_direction == Direction.RIGHT && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_right, _left, _percent);
        }

        if (_percent >= 1)
        {
            _percent = 0.0f;
            if (_direction == Direction.UP)
            {
                _direction = Direction.DOWN;
            }
            else if (_direction == Direction.DOWN)
            {
                _direction = Direction.UP;
            }

            else if(_direction == Direction.LEFT)
            {
                _direction = Direction.RIGHT;
            }
            else
            {
                _direction = Direction.LEFT;
            }
        }
    }

    // Apply a random rotation effect
    void ApplyRotationEffect()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 25f);
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag != "walls")
        {
            Debug.Log("Other: " + collision.gameObject.name + " Me: " + me.name);
            int fillOfOther = collision.gameObject.GetComponent<MoleculeFloat>().getElectronFill();
            int enOther = collision.gameObject.GetComponent<MoleculeFloat>().electroNeg;
            if(electroNeg < 0 && enOther > 0) // I need 2, he has one!
            {
                electronFull = enOther + electronFull;
                collision.gameObject.GetComponent<MoleculeFloat>().steal(); // steal the electrons from the other
                collision.gameObject.GetComponent<MoleculeFloat>().bondedTo.Add(me);
                bondedTo.Add(collision.gameObject);
                // now bond!
            }
            // this atom will bond with the other atom if my fill is not at max fill. What is max fill? electroNeg
            // 

            //  scaledDirection = -1 * scaledDirection;
        }
        
    }
}