using System;
using UnityEngine;

namespace ModelGame
{ 
    /// <summary>
    /// Базовый класс для всех объектов на сцене
    /// </summary>
    public abstract class BaseObjectScene : MonoBehaviour
    {
        /// <summary>
        /// Номер слоя на котором находится сам объект и все дочерние
        /// </summary>
        private int _layer;
        
        /// <summary>
        /// Ссылка на компонент Rigidbody 
        /// </summary>
        public Rigidbody Rigidbody { get; private set; }
       
        /// <summary>
        /// Ссылка на компонент Transform
        /// </summary>
        public Transform Transform { get; private set; }
        
        /// <summary>
        /// Свойство которое содержит номер слоя объекта и его дочерних объектов
        /// </summary>
        public int Layer
        {
            get => _layer;
            set
            {
                _layer = value;
                AskLayer(Transform, _layer);
            }
        }
        
        /// <summary>
        /// Метод изменяет номер слоя объекта включая и дочерних объектов если таковые имеются
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="layer">Номер слоя который нужно изменить</param>
        private void AskLayer(Transform obj, int layer)
        {
            obj.gameObject.layer = layer;
            if (obj.childCount <= 0) return;

            foreach (Transform child in obj)
            {
                AskLayer(child, layer);
            }
        }
        
        /// <summary>
        /// Кешируем ссылки
        /// </summary>
        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = transform;
            
        }
    }
}
