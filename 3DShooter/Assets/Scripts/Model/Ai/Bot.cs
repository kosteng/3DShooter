using UnityEngine;
using UnityEngine.AI;

namespace ModelGame {
    /// <summary>
    /// Класс поведения бота
    /// </summary>
    public sealed class Bot : BaseObjectScene, ISetDamage, ISetHealth
    {
        /// <summary>
        /// Количество жизней
        /// </summary>
        public float Hp = 100;

        /// <summary>
        /// Цель для бота
        /// </summary>
        public Transform Target { get; set; }

        /// <summary>
        /// Зрение вота
        /// </summary>
        public Vision Vision;
        
        /// <summary>
        /// Оружие бота
        /// </summary>
        public Weapon Weapon; // дз с разным орудием

        /// <summary>
        /// Ссылка на навигацию бота
        /// </summary>
        public NavMeshAgent Agent { get; private set; }
        
        /// <summary>
        /// Время ожидания перед движением
        /// </summary>
        private float _waitTime = 3;
        
        /// <summary>
        /// Состояние бота
        /// </summary>
        private StateBot _stateBot;

        /// <summary>
        /// Точка
        /// </summary>
        private Vector3 _point;

        protected override void Awake()
        {
            base.Awake();
            Agent = GetComponent<NavMeshAgent>();
            var bodyBot = GetComponentInChildren<BodyBot>();
            if (bodyBot != null) bodyBot.OnApplyDamageChange += ApplyDamage;

            var headBot = GetComponentInChildren<HeadBot>();
            if (headBot != null) headBot.OnApplyDamageChange += ApplyDamage;
        }

        public void Tick ()
        {
            if (_stateBot == StateBot.Died) return;

            if (_stateBot != StateBot.Detected)
            {
                if (!Agent.hasPath)
                {
                    if (_stateBot != StateBot.Patrol)
                    {
                        _stateBot = StateBot.Patrol;
                        _point = Patrol.GenericPoint(transform);
                        Agent.SetDestination(_point);
                        Agent.stoppingDistance = 0;

                    }
                    else
                    {
                        if (Vector3.Distance(_point, transform.position) <= 1)
                        {
                            _stateBot = StateBot.Inspection;
                            Invoke(nameof(ReadyPatrol), _waitTime);
                        }
                    }
                }
                if (Vision.VisionM(transform, Target))
                {
                    _stateBot = StateBot.Detected;
                }
            }
            else
            {
                Agent.SetDestination(Target.position);
                Agent.stoppingDistance = 2;
                if (Vision.VisionM(transform, Target))
                {
                    //дз остановить бота для стрельбы
                    Weapon.Fire();
                }
                // дз потеря персонажа и возрат на патруль
            }
        }



        public void ApplyDamage(InfoCollision info)
        {
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp < 0)
            {
                _stateBot = StateBot.Died;
                Agent.enabled = false;
                foreach(var child in GetComponentsInChildren<Transform>())
                {
                    child.parent = null;
                    var tempRbChild = child.gameObject.AddComponent<Rigidbody>();
                    if (!tempRbChild)
                    {
                        tempRbChild = child.gameObject.AddComponent<Rigidbody>();
                    }

                    Main.Instance.BotController.RemoveBotToList(this);
                    Destroy(child.gameObject, 10);
                }
            }
        }
    
        private void ReadyPatrol()
        {
            _stateBot = StateBot.Non;
        }

        public void MovePoint(Vector3 point)
        {
            Agent.SetDestination(point);
        }

        public void ApplyHealth(float health)
        {
            Debug.Log(2);
            Hp += health;
            if (Hp > 100)
                Hp = 100;
            Debug.Log(Hp);

        }
    }
}
/*using UnityEngine;
using UnityEngine.AI;

namespace ModelGame
{
    public sealed class Bot : BaseObjectScene
    {
        public float Hp = 100;
        public Transform Target { get; set; }
        public Vision Vision;
        public Weapon Weapon; // с разным оружием 
        public NavMeshAgent Agent { get; private set; }

        private float _waitTime = 3;
        private StateBot _stateBot;
        private Vector3 _point;

        protected override void Awake()
        {
            base.Awake();
            Agent = GetComponent<NavMeshAgent>();
            var bodyBot = GetComponentInChildren<BodyBot>();
            if (bodyBot != null) bodyBot.OnApplyDamageChange += SetDamage;

            var headBot = GetComponentInChildren<HeadBot>();
            if (headBot != null) headBot.OnApplyDamageChange += SetDamage;
        }

        public void Tick()
        {
            Debug.Log(_stateBot);
            if (_stateBot == StateBot.Died) return;

            if (_stateBot != StateBot.Detected)
            {
                if (!Agent.hasPath)
                {
                    if (_stateBot != StateBot.Inspection)
                    {
                        if (_stateBot != StateBot.Patrol)
                        {
                            _stateBot = StateBot.Patrol;
                            _point = Patrol.GenericPoint(transform);
                            Agent.SetDestination(_point);
                            Agent.stoppingDistance = 0;
                        }
                        else
                        {
                            if (Vector3.Distance(_point, transform.position) <= 1)
                            {
                                _stateBot = StateBot.Inspection;
                                Invoke(nameof(ReadyPatrol), _waitTime);
                            }
                        }
                    }
                }

                if (Vision.VisionM(transform, Target))
                {
                    _stateBot = StateBot.Detected;
                }
            }
            else
            {
                Agent.SetDestination(Target.position);
                Agent.stoppingDistance = 2;
                if (Vision.VisionM(transform, Target))
                {
                    // остановиться 
                    Weapon.Fire();
                }
                
                // Потеря персонажа
            }
        }

        public void SetDamage(InfoCollision info)
        {
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                _stateBot = StateBot.Died;
                Agent.enabled = false;
                foreach (var child in GetComponentsInChildren<Transform>())
                {
                    child.parent = null;
                    var tempRbChild = child.GetComponent<Rigidbody>();
                    if (!tempRbChild)
                    {
                        tempRbChild = child.gameObject.AddComponent<Rigidbody>();
                    }
                    //tempRbChild.AddForce(info.Dir * Random.Range(10, 300));

                    Main.Instance.BotController.RemoveBotToList(this);
                    Destroy(child.gameObject, 10);
                }
            }
        }

        private void ReadyPatrol()
        {
            _stateBot = StateBot.Non;
        }

        public void MovePoint(Vector3 point)
        {
            Agent.SetDestination(point);
        }
    }
}*/