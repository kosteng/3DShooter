using UnityEngine;
namespace ModelGame
{
    /// <summary>
    /// Структура запонимает данные остолковении объектов
    /// </summary>
    public struct InfoCollision
    {
        /// <summary>
        /// Положение объекта
        /// </summary>
        private readonly Vector3 _dir;
        /// <summary>
        /// Урон
        /// </summary>
        private readonly float _damage;
        /// <summary>
        
        /// Конструктор структуры
        /// </summary>
        /// <param name="damage">Урон</param>
        /// <param name="dir">Положение</param>
        public InfoCollision (float damage, Vector3 dir = default(Vector3))
        {
            _damage = damage;
            _dir = dir;
        }
        /// <summary>
        /// Положение объекта
        /// </summary>
        public Vector3 Dir => _dir;

        /// <summary>
        /// Урон
        /// </summary>
        public float Damage => _damage;
    }
}