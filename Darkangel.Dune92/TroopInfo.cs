using Darkangel.Xml;
using System.IO;
using System.Xml;

namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// <para>Информация о группе</para>
    /// </summary>
    public class TroopInfo : IBinaryData, IXmlWritable
    {
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public byte TroopId;
        /// <summary>
        /// Идентификатор следующей группы
        /// </summary>
        public byte NextTroopId;
        /// <summary>
        /// Расположение групы около поселения на карте
        /// </summary>
        public TroopPosition TownPosition;
        /// <summary>
        /// Чем занимается группа
        /// </summary>
        public TroopOccupation Occupation;
        /// <summary>
        /// Неизвестные данные
        /// </summary>
        public readonly UnknownFieldData Unknown01 = new(2);
        /// <summary>
        /// Расположение группы на карте
        /// </summary>
        public readonly MapCoord MapPosition = new();
        /// <summary>
        /// ??? Позиция
        /// </summary>
        public readonly MapCoord Position = new();
        /// <summary>
        /// Неизвестные данные
        /// </summary>
        public readonly UnknownFieldData Unknown02 = new(8);
        /// <summary>
        /// Неудовлетворенность
        /// </summary>
        public byte Dissatisfaction;
        /// <summary>
        /// Флаги группы
        /// </summary>
        public TroopFlags Flags;
        /// <summary>
        /// Отложенное сообщение
        /// </summary>
        public byte MissYouMessage;
        /// <summary>
        /// Мотивация группы
        /// </summary>
        public byte Motivation;
        /// <summary>
        /// Уровень умения добычи спайса
        /// </summary>
        public byte SpiceSkill;
        /// <summary>
        /// Уровень боевых умений
        /// </summary>
        public byte MilitarySkill;
        /// <summary>
        /// Уровень экологических умений
        /// </summary>
        public byte EcologySkill;
        /// <summary>
        /// Оборудование группы
        /// </summary>
        public TroopEquipmentFlags Equipment;
        /// <summary>
        /// Количество народа в группе, деленное на 10
        /// </summary>
        public int Population
        {
            get => _Population * 10;
            set => _Population = (byte)(value / 10);
        }
        private byte _Population;
        /// <inheritdoc/>
        public void Load(Stream stream)
        {
            TroopId = (byte)stream.ReadByte();
            NextTroopId = (byte)stream.ReadByte();
            TownPosition = (TroopPosition)stream.ReadByte();
            Occupation = (TroopOccupation)stream.ReadByte();
            Unknown01.Load(stream);
            MapPosition.Load(stream);
            Position.Load(stream);
            Unknown02.Load(stream);
            Dissatisfaction = (byte)stream.ReadByte();
            Flags = (TroopFlags)stream.ReadByte();
            MissYouMessage = (byte)stream.ReadByte();
            Motivation = (byte)stream.ReadByte();
            SpiceSkill = (byte)stream.ReadByte();
            MilitarySkill = (byte)stream.ReadByte();
            EcologySkill = (byte)stream.ReadByte();
            Equipment = (TroopEquipmentFlags)stream.ReadByte();
            _Population = (byte)stream.ReadByte();
        }
        /// <inheritdoc/>
        public void Store(Stream stream)
        {
            stream.WriteByte(TroopId);
            stream.WriteByte(NextTroopId);
            stream.WriteByte((byte)TownPosition);
            stream.WriteByte((byte)Occupation);
            Unknown01.Store(stream);
            MapPosition.Store(stream);
            Position.Store(stream);
            Unknown02.Store(stream);
            stream.WriteByte(Dissatisfaction);
            stream.WriteByte((byte)Flags);
            stream.WriteByte(MissYouMessage);
            stream.WriteByte(Motivation);
            stream.WriteByte(SpiceSkill);
            stream.WriteByte(MilitarySkill);
            stream.WriteByte(EcologySkill);
            stream.WriteByte((byte)Equipment);
            stream.WriteByte(_Population);
        }
        /// <inheritdoc/>
        public void AppendTo(XmlElement owner)
        {
            var root = owner.AddChild(nameof(TroopInfo));
            root.AddAttribute(nameof(TroopId), TroopId);
            root.AddAttribute(nameof(NextTroopId), NextTroopId);
            root.AddAttribute(nameof(TownPosition), TownPosition);
            root.AddAttribute(nameof(Occupation), Occupation);
            Unknown01.AppendTo(root.AddChild(nameof(Unknown01)));
            MapPosition.AppendTo(root.AddChild(nameof(MapPosition)));
            Position.AppendTo(root.AddChild(nameof(Position)));
            Unknown02.AppendTo(root.AddChild(nameof(Unknown02)));
            root.AddAttribute(nameof(Dissatisfaction), Dissatisfaction);
            root.AddAttribute(nameof(Flags), Flags);
            root.AddAttribute(nameof(MissYouMessage), MissYouMessage);
            root.AddAttribute(nameof(Motivation), Motivation);
            root.AddAttribute(nameof(SpiceSkill), SpiceSkill);
            root.AddAttribute(nameof(MilitarySkill), MilitarySkill);
            root.AddAttribute(nameof(EcologySkill), EcologySkill);
            root.AddAttribute(nameof(Equipment), Equipment);
            root.AddAttribute(nameof(Population), Population);
        }
    }
}
