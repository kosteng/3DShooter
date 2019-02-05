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
        /// Цвет объекта
        /// </summary>
        private Color _color;

        /// <summary>
        /// Видимость объекта на сцене
        /// </summary>
        private bool _isVisible;
        /// <summary>
        /// Ссылка на компонент Rigidbody 
        /// </summary>
        [HideInInspector] public Rigidbody Rigidbody;
        
        /// <summary>
        /// Есть ли компонент на объекте
        /// </summary>
        /// <returns></returns>
        public bool IsRigitBody() => Rigidbody;

        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name
        {
            get => gameObject.name;
            set => gameObject.name = value;
        }

        /// <summary>
        /// Свойство которое содержит номер слоя объекта и его дочерних объектов
        /// </summary>
        public int Layer
        {
            get => _layer;
            set
            {
                _layer = value;
                AskLayer(transform, _layer);
            }
        }
        /// <summary>
        /// Цвет материала объекта
        /// </summary>
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                AskColor(transform, _color);
            }
        }

        /// <summary>
        /// Видимость объекта
        /// </summary>
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                var tempRenderer = GetComponent<Renderer>();
                if (tempRenderer)
                    tempRenderer.enabled = _isVisible;
                if (transform.childCount <= 0) return;
                foreach (Transform d in transform)
                {
                    tempRenderer = d.gameObject.GetComponent<Renderer>();
                    if (tempRenderer)
                        tempRenderer.enabled = _isVisible;
                }
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
        /// Метод изменяет цвет объекта
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="color">Цвет</param>
        private void AskColor(Transform obj, Color color)
        {
            foreach (var curMaterial in obj.GetComponent<Renderer>().materials)
            {
                curMaterial.color = color;
            }
            if (obj.childCount <= 0) return;
            foreach (Transform d in obj)
            {
                AskColor(d, color);
            }
        }

        /// <summary>
		/// Выключает физику у объекта и его детей
		/// </summary>
		public void DisableRigidBody()
        {
            if (!IsRigitBody()) return;

            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = true;
            }
        }

        /// <summary>
        /// Включает физику у объекта и его детей
        /// </summary>
        public void EnableRigidBody(float force)
        {
            EnableRigidBody();
            Rigidbody.isKinematic = false;
            Rigidbody.AddForce(transform.forward * force);
        }

        /// <summary>
        /// Включает физику у объекта и его детей
        /// </summary>
        public void EnableRigidBody()
        {
            if (!IsRigitBody()) return;
            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
        }
        /// <summary>
        /// Кешируем ссылки
        /// </summary>
        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Заморозка оси физического свойства объекта
        /// </summary>
        /// <param name="constraints"> В качестве аргумента передаем нужную ось</param>
        /// почему-то когда этот метод делаю с модификатором protected то не могу вызвать у потомка в данном случае у фонарика в скрипте FlashLightController
        public void FreezeRigid(RigidbodyConstraints constraints)
        {
            if (Rigidbody == null) return;
            if (constraints == RigidbodyConstraints.FreezePositionX)
                Rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
            if (constraints == RigidbodyConstraints.FreezePositionY)
                Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            if (constraints == RigidbodyConstraints.FreezePositionZ)
                Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            if (constraints == RigidbodyConstraints.FreezeAll)
                Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        /// <summary>
        /// Включение и отключение объект
        /// </summary>
        /// <param name="value"></param>
        public void SetActive(bool value)
        {
            IsVisible = value;

            var tempCollider = GetComponent<Collider>();
            if (tempCollider)
            {
                tempCollider.enabled = value;
            }
        }
    }
}
