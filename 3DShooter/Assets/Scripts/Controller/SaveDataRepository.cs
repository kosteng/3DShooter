using System.IO;
using UnityEngine;

namespace ModelGame
{
	public class SaveDataRepository
	{
		private IData<SerializableGameObject> _data;

		private string _folderName = "dataSave";
		private string _fileName = "data.bat";
		private string _path;

		public SaveDataRepository()
		{

			_data = new JsonData<SerializableGameObject>();
			
			_path = Path.Combine(Application.dataPath, _folderName);
		}

		public void Save()
		{
			if (!Directory.Exists(Path.Combine(_path)))
			{
				Directory.CreateDirectory(_path);
			}
            var player = new SerializableGameObject
            {

                Pos = Main.Instance.Player.position,
                Name = "Kos",
                IsEnable = true,
                Rot = Main.Instance.Player.rotation


            };

			_data.Save(player, Path.Combine(_path, _fileName));
		}

		public void Load()
		{
			var file = Path.Combine(_path, _fileName);
			if (!File.Exists(file)) return;
			var player = _data.Load(file);
            
			Main.Instance.Player.position = player.Pos;
            Main.Instance.Player.name = player.Name;
			Main.Instance.Player.gameObject.SetActive(player.IsEnable);
            Main.Instance.Player.rotation = player.Rot;

            Debug.Log(Main.Instance.Player);
		}
	}
}