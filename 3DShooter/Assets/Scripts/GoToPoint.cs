
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;
public class GoToPoint : MonoBehaviour
{
    private AICharacterControl _agent;
    [SerializeField] private GameObject _point;
    private GameObject _lineObj;
    [SerializeField ]private LineRenderer _lineRenderer;
    private const int _leftMouseButton = 0;
    private NavMeshAgent _path;
    private Queue<Transform> _points = new Queue<Transform>();
    private float _destroyPoint = 1f; // по всей логики поле нужно было для жизни точки, пока оставлю здесь
    private Transform temp;
    private int _indexPoint =1;

    private void Awake()
    {
        _agent = FindObjectOfType<AICharacterControl>();
       
    }
    void Start()
    {
        _lineObj = new GameObject("LineObj");
        _lineRenderer = _lineObj.AddComponent<LineRenderer>();
        _path = _agent.GetComponent<NavMeshAgent>();
        _lineRenderer.SetPosition(0, _agent.transform.position);
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                PrintPoint(hit.point);
                _lineRenderer.SetPosition(_indexPoint, hit.point);
                _indexPoint++;
                _lineRenderer.SetVertexCount(_indexPoint+1);
            }

          
        }

        if (_points.Count > 0) 
            {
            
             if (_path.remainingDistance < _path.stoppingDistance)
            {
                
                _agent.SetTarget(_points.Dequeue());
             //   if (_path.remainingDistance < _path.stoppingDistance) // вариант не работает. Роман посмотрите пожалуйста что я делаю не так.
             //       Destroy(_points.Dequeue().gameObject);
            }
           
        }
        
            

    }

    private void PrintPoint(Vector3 point)
    {
        GameObject tempPoint = Instantiate(_point, point, Quaternion.identity) as GameObject;
        _points.Enqueue(tempPoint.transform);
    }
}
