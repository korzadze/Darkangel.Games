using System;

namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Чем занимается группа</para>
    /// </summary>
    [Flags]
    public enum TroopOccupation
    {
        /// <summary>
        /// <para>Сборщики: работают</para>
        /// </summary>
        /// <remarks>тип + статус</remarks>
        Mining = 0,
        /// <summary>
        /// <para>Сборщики: разведка спайса</para>
        /// </summary>
        /// <remarks>тип + статус</remarks>
        Prospecting = 1 << 0,
        /// <summary>
        /// <para>Сборщики: ждут указаний</para>
        /// </summary>
        /// <remarks>статус</remarks>
        WaitingForOrders = 1 << 1,
        /// <summary>
        /// <para>Армия</para>
        /// </summary>
        /// <remarks>тип</remarks>
        Militaries = 1 << 2,
        /// <summary>
        /// <para>Экологи</para>
        /// </summary>
        /// <remarks>тип</remarks>
        Ecologists = 1 << 3,
        /// <summary>
        /// <para>Сборщики: работа закончена</para>
        /// </summary>
        /// <remarks>статус</remarks>
        JobsFinished = 1 << 4,
        /// <summary>
        /// <para>Свободные: в рабстве</para>
        /// </summary>
        /// <remarks>статус</remarks>
        Slaving = 1 << 5,
        /// <summary>
        /// <para>Сборщики: перемещаются в другое место</para>
        /// </summary>
        /// <remarks>статус</remarks>
        MovingToAnotherPlace = 1 << 6,
        /// <summary>
        /// <para>Свободные: не наняты</para>
        /// </summary>
        /// <remarks>тип</remarks>
        NotYetHired = 1 << 7,
        /// <summary>
        /// <para>Сборщики: в поисках оборудования</para>
        /// </summary>
        /// <remarks>статус</remarks>
        SearchEquipment = Prospecting | WaitingForOrders,
        /// <summary>
        /// <para>Армия: разведка (статус)</para>
        /// </summary>
        Espionage = Militaries | Prospecting,
        /// <summary>
        /// <para>Армия: атака</para>
        /// </summary>
        /// <remarks>статус</remarks>
        Attacking = Militaries | WaitingForOrders,
        /// <summary>
        /// <para>Армия: в поисках оборудования</para>
        /// </summary>
        /// <remarks>статус</remarks>
        MilitariesSearchEquipment = Militaries | Prospecting | WaitingForOrders,
        /// <summary>
        /// <para>Экологи: работают (собирают ветроловушку)</para>
        /// </summary>
        /// <remarks>статус</remarks>
        WindtrapAssembly = Ecologists | Prospecting,
        /// <summary>
        /// <para>Экологи: выращивают саженцы</para>
        /// </summary>
        /// <remarks>статус</remarks>
        BulbGrowing = Ecologists | WaitingForOrders,
        /// <summary>
        /// <para>Экологи: в поисках оборудования</para>
        /// </summary>
        /// <remarks>статус</remarks>
        EcologistsSearchEquipment = Ecologists | Prospecting | WaitingForOrders,
        /// <summary>
        /// <para>Сборщики Харконненов: работают?</para>
        /// </summary>
        /// <remarks>статус</remarks>
        HarkonnenMining = Militaries | Ecologists,
        /// <summary>
        /// <para>Сборщики Харконненов: разведка спайса?</para>
        /// </summary>
        /// <remarks>статус</remarks>
        HarkonnenProspecting = Militaries | Ecologists | Prospecting,
        /// <summary>
        /// <para>Сборщики Харконненов: ждут указаний</para>
        /// </summary>
        /// <remarks>статус</remarks>
        HarkonnenWaitingOrders = Militaries | Ecologists | WaitingForOrders,
        /// <summary>
        /// <para>Сборщики Харконненов: в поисках оборудования</para>
        /// </summary>
        /// <remarks>статус</remarks>
        HarkonnenSearchEquipment = Militaries | Ecologists | SearchEquipment,
        /// <summary>
        /// <para>Армия Харконненов</para>
        /// </summary>
        /// <remarks>тип</remarks>
        HarkonnenMilitaries = Militaries | Ecologists | JobsFinished,
        /// <summary>
        /// <para>Армия Харконненов: в поисках оборудования</para>
        /// </summary>
        /// <remarks>статус</remarks>
        HarkonnenMilitariesSearchEquipment = Militaries | Ecologists | JobsFinished | SearchEquipment,
        /// <summary>
        /// <para>Захваченные исследователи спайса</para>
        /// </summary>
        /// <remarks>статус</remarks>
        ProspectingCaptured = Prospecting | Slaving,
        /// <summary>
        /// <para>Свободные: группа была захвачена? (ожидающее сообщение)</para>
        /// </summary>
        TroopApologizeHasBeenCaptured = WaitingForOrders | Slaving,
        /// <summary>
        /// <para>Сборщики: в поисках оборудования?</para>
        /// </summary>
        /// <remarks>статус</remarks>
        MinersSearchHarvester = Prospecting | WaitingForOrders | Slaving,
        /// <summary>
        /// <para>Свободные: в плену у Харконненов?</para>
        /// </summary>
        /// <remarks>статус</remarks>
        HarkonnenSlaves = Slaving | NotYetHired,
    }
}
