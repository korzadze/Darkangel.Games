using Darkangel.IntegerX;
using Darkangel.Xml;
using System;
using System.IO;
using System.Xml;

namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Заголовок файла сохраненной игры</para>
    /// </summary>
    public class SaveHeader : IBinaryData, IXmlWritable
    {
        private const int GameBeginP = 3;
        private const int GameDayLengthP = 24 / 3 * 2;
        private const int PeriodMinutes = 90;
        private static TimeSpan GetGameTime(UInt16 periods)
        {
            int saveTime = periods + GameBeginP + GameDayLengthP;
            int minutes = saveTime * PeriodMinutes;
            return TimeSpan.FromMinutes(minutes);
        }
        /// <summary>
        /// <para>Игровое время</para>
        /// </summary>
        public TimeSpan GameTime => GetGameTime(Periods);
        /// <summary>
        /// <para>Количество периодов, прошедших с начала игры</para>
        /// </summary>
        public UInt16 Periods { get; set; } = 0;
        /// <inheritdoc/>
        public void Load(Stream stream)
        {
            Periods = stream.ReadUInt16(isLittleEndian: true);
        }
        /// <inheritdoc/>
        public void Store(Stream outStream)
        {
            outStream.Write(Periods, isLittleEndian: true);
        }
        /// <inheritdoc/>
        public void AppendTo(XmlElement owner)
        {
            var root = owner.AddChild(nameof(SaveHeader));
            root.AddAttribute(nameof(GameTime), GameTime);
        }
    }
}
