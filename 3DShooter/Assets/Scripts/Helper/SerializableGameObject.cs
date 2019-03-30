using System;
using System.Collections.Generic;
using UnityEngine;

namespace ModelGame
{
	[Serializable]
	public class SerializableGameObject
	{
		public string Name;
		public bool IsEnable;
		public SerializableVector3 Pos;
		[SerializeField] public SerializableQuaternion Rot;
		public SerializableVector3 Scale;
		public Vector3 Test;
        public List<SeriazableWeaponInfo> Weapon = new List<SeriazableWeaponInfo>();

        public override string ToString()
		{
			return $"Name = {Name}; IsEnable = {IsEnable}; Pos = {Pos};";
		}
	}

    [Serializable]
    public class SeriazableWeaponInfo
    {
        public int CountClip;
        public int CountAmmunition;

        public SeriazableWeaponInfo(int CountClip, int CountAmmunition)
        {
                this.CountClip = CountClip;
                this.CountAmmunition = CountAmmunition;
        }

        public static implicit operator SeriazableWeaponInfo(Weapon value)
        {
            
            return new SeriazableWeaponInfo(value.CountClip, value.Clip.CountAmmunition);
        }
    }

	[Serializable]
	public struct SerializableVector3
	{
		public float X;
		public float Y;
		public float Z;
		public SerializableVector3(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}
		public static implicit operator Vector3(SerializableVector3 value)
		{
			return new Vector3(value.X, value.Y, value.Z);
		}
		public static implicit operator SerializableVector3(Vector3 value)
		{
			return new SerializableVector3(value.x, value.y, value.z);
		}

		public override string ToString()
		{
			return $"X = {X}; Y = {Y}; Z = {Z};";
		}
	}
	[Serializable]
	public struct SerializableQuaternion
	{
		public float X;
		public float Y;
		public float Z;
		public float W;
		public SerializableQuaternion(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}
		public static implicit operator Quaternion(SerializableQuaternion value)
		{
			return new Quaternion(value.X, value.Y, value.Z, value.W);
		}
		public static implicit operator SerializableQuaternion(Quaternion value)
		{
			return new SerializableQuaternion(value.x, value.y, value.z, value.w);
		}
	}
}