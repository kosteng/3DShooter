namespace ModelGame
{
    /// <summary>
    /// Базовый класс для всех контроллеров
    /// </summary>
    public abstract class BaseController
    {
        /// <summary>
        /// Свойство проверяет активный или нет объект
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Метод включение контроллера
        /// </summary>
        public virtual void On()
        {
            On(null);
        }
        /// <summary>
        /// Метод включение контроллера
        /// </summary>
        /// <param name="obj"></param>
        public virtual void On (BaseObjectScene obj)
        {
            IsActive = true;
        }

        /// <summary>
        /// Метод выключение контроллера
        /// </summary>
        public virtual void Off()
        {
            IsActive = false;
        }

        /// <summary>
        /// Метод переключения на противоположное состояние контроллера
        /// </summary>
        public void Switch()
        {
            if (IsActive)
            {
                Off();
            }
            else
            {
                On();
            }
        }

        public abstract void OnUpdate();
        
    }
}