using UnityEngine;

namespace ModelGame
{
    public class Main : MonoBehaviour
    {
        public FlashLightController FlashLightController { get; private set; }
        public InputController InputController { get; private set; }
        public PlayerController PlayerController { get; private set; }
        public WeaponController WeaponController { get; private set; }
        public SelectionController SelectionController { get; private set; }
        public BotController BotController { get; private set; }
        public ObjectManager ObjectManager { get; private set; }
        public Transform Player { get; private set; }
        public Transform MainCamera { get; private set; }
        private BaseController[] Controllers;

        public Bot RefBotPrefab;
        public int CountBot;
        public static Main Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            MainCamera = Camera.main.transform;
            Player = GameObject.FindGameObjectWithTag("Player").transform;

            ObjectManager = new ObjectManager();
            ObjectManager.Start();

            PlayerController = new PlayerController(new UnitMotor(Player));
            PlayerController.On();
            FlashLightController = new FlashLightController();
            InputController = new InputController();
            InputController.On();
            SelectionController = new SelectionController();
            WeaponController = new WeaponController();

            BotController = new BotController();
            BotController.On();
            BotController.Init(CountBot);
            Controllers = new BaseController[6];
            Controllers[0] = FlashLightController;
            Controllers[1] = InputController;
            Controllers[2] = PlayerController;
            Controllers[3] = WeaponController;
            Controllers[4] = SelectionController;
            Controllers[5] = BotController;
        }

        private void Update()
        {
            for (var index = 0; index < Controllers.Length; index++)
            {
                var controller = Controllers[index];
                controller.OnUpdate();
            }
        }


        private void OnGUI()
        {
            GUI.Label(new Rect(0, 0, 100, 100), $"{1 / Time.deltaTime:0.0}");
        }
    }

}

