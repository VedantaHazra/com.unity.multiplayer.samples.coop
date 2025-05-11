using System;
using Unity.BossRoom.Gameplay.GameplayObjects;
using Unity.BossRoom.Gameplay.GameplayObjects.Character;
using Unity.BossRoom.Utils;
using Unity.Netcode;

namespace Unity.BossRoom.Gameplay.Messages
{
    // public struct LifeStateChangedEventMessage : INetworkSerializeByMemcpy
    // {
    //     public LifeState NewLifeState;
    //     public CharacterTypeEnum CharacterType;
    //     public FixedPlayerName CharacterName;
    // }
    public struct LifeStateChangedEventMessage : INetworkSerializeByMemcpy
    {
        public LifeState NewLifeState;
        public ulong NetworkObjectId;
        public CharacterTypeEnum CharacterType;
        public FixedPlayerName CharacterName;
        // public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        // {
        //     serializer.SerializeValue(ref NewLifeState);
        //     serializer.SerializeValue(ref NetworkObjectId);
        // }
    }

}
