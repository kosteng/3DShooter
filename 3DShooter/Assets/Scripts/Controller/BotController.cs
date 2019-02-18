using System.Collections.Generic;
using UnityEngine;

namespace ModelGame
{   /// <summary>
    /// Констроллер ботов
    /// </summary>
    public class BotController : BaseController
    {   /// <summary>
        /// Массив ботов
        /// </summary>
        public List<Bot> GetBotList { get; } = new List<Bot>();
        /// <summary>
        /// Создание бота
        /// </summary>
        /// <param name="countBot">Количество ботов</param>
        public void Init(int countBot)
        {
            var bot = Resources.Load<Bot>("Bot");
            for (var index = 0; index < countBot; index++)
            {
                
                var tempBot = Bot.Instantiate(bot,
                    Patrol.GenericPoint(Main.Instance.Player),
                    Quaternion.identity);

                tempBot.Agent.avoidancePriority = index;
                tempBot.Target = Main.Instance.Player; // разных противников
                if (GetBotList.Count == 0)
                {

                    tempBot.Target = Main.Instance.Player;
                    AddBotToList(tempBot);
                }
                else
                {
                    tempBot.Target = GetBotList[Random.Range(0,GetBotList.Count)].transform;
                    AddBotToList(tempBot);
                }
            }
        }

        /// <summary>
        /// Метод добавляет ботов в массив
        /// </summary>
        /// <param name="bot">Бот</param>
        private void AddBotToList(Bot bot)
        {
            if (!GetBotList.Contains(bot))
            {
                GetBotList.Add(bot);
            }
        }

        /// <summary>
        /// Матод удаляет из массива ботов
        /// </summary>
        /// <param name="bot">Бот</param>
        public void RemoveBotToList(Bot bot)
        {
            if (GetBotList.Contains(bot))
            {
                GetBotList.Remove(bot);
            }
        }

        public override void OnUpdate()
        {
            if (!IsActive) return;
            foreach (var bot in GetBotList)
            {
                bot.Tick();
            }
        }
    }
}