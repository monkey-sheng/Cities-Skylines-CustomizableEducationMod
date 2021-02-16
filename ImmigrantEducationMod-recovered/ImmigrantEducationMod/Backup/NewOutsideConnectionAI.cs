// Decompiled with JetBrains decompiler
// Type: ImmigrantEducationMod.NewOutsideConnectionAI
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

using Boformer.Redirection;
using ColossalFramework;
using ColossalFramework.Math;
using System;
using UnityEngine;

namespace ImmigrantEducationMod
{
  [TargetType(typeof (OutsideConnectionAI))]
  public class NewOutsideConnectionAI : OutsideConnectionAI
  {
    [RedirectMethod]
    private static bool StartConnectionTransferImpl(
      ushort buildingID,
      ref Building data,
      TransferManager.TransferReason material,
      TransferManager.TransferOffer offer,
      int touristFactor0,
      int touristFactor1,
      int touristFactor2)
    {
      BuildingManager instance1 = Singleton<BuildingManager>.instance;
      VehicleInfo info = (VehicleInfo) null;
      Citizen.Education education1 = Citizen.Education.Uneducated;
      int num1 = 0;
      bool flag1 = false;
      bool flag2 = false;
      bool transferToSource = false;
      if (material == TransferManager.TransferReason.DummyCar)
      {
        ushort building = offer.Building;
        if (building != (ushort) 0 && (double) Vector3.SqrMagnitude(instance1.m_buildings.m_buffer[(int) building].m_position - data.m_position) > 40000.0)
        {
          flag2 = true;
          switch (Singleton<SimulationManager>.instance.m_randomizer.Int32(38U))
          {
            case 0:
              material = TransferManager.TransferReason.Ore;
              break;
            case 1:
              material = TransferManager.TransferReason.Coal;
              break;
            case 2:
              material = TransferManager.TransferReason.Oil;
              break;
            case 3:
              material = TransferManager.TransferReason.Petrol;
              break;
            case 4:
              material = TransferManager.TransferReason.Grain;
              break;
            case 5:
              material = TransferManager.TransferReason.Food;
              break;
            case 6:
              material = TransferManager.TransferReason.Logs;
              break;
            case 7:
              material = TransferManager.TransferReason.Lumber;
              break;
            case 8:
              material = TransferManager.TransferReason.Goods;
              break;
            case 9:
              material = TransferManager.TransferReason.Goods;
              break;
            case 10:
              material = TransferManager.TransferReason.Single0;
              break;
            case 11:
              material = TransferManager.TransferReason.Single1;
              break;
            case 12:
              material = TransferManager.TransferReason.Single2;
              break;
            case 13:
              material = TransferManager.TransferReason.Single3;
              break;
            case 14:
              material = TransferManager.TransferReason.Single0B;
              break;
            case 15:
              material = TransferManager.TransferReason.Single1B;
              break;
            case 16:
              material = TransferManager.TransferReason.Single2B;
              break;
            case 17:
              material = TransferManager.TransferReason.Single3B;
              break;
            case 18:
              material = TransferManager.TransferReason.Family0;
              break;
            case 19:
              material = TransferManager.TransferReason.Family1;
              break;
            case 20:
              material = TransferManager.TransferReason.Family2;
              break;
            case 21:
              material = TransferManager.TransferReason.Family3;
              break;
            case 22:
              material = TransferManager.TransferReason.Shopping;
              break;
            case 23:
              material = TransferManager.TransferReason.ShoppingB;
              break;
            case 24:
              material = TransferManager.TransferReason.ShoppingC;
              break;
            case 25:
              material = TransferManager.TransferReason.ShoppingD;
              break;
            case 26:
              material = TransferManager.TransferReason.ShoppingE;
              break;
            case 27:
              material = TransferManager.TransferReason.ShoppingF;
              break;
            case 28:
              material = TransferManager.TransferReason.ShoppingG;
              break;
            case 29:
              material = TransferManager.TransferReason.ShoppingH;
              break;
            case 30:
              material = TransferManager.TransferReason.Entertainment;
              break;
            case 31:
              material = TransferManager.TransferReason.EntertainmentB;
              break;
            case 32:
              material = TransferManager.TransferReason.EntertainmentC;
              break;
            case 33:
              material = TransferManager.TransferReason.EntertainmentD;
              break;
            case 34:
              material = TransferManager.TransferReason.TouristA;
              break;
            case 35:
              material = TransferManager.TransferReason.TouristB;
              break;
            case 36:
              material = TransferManager.TransferReason.TouristC;
              break;
            case 37:
              material = TransferManager.TransferReason.TouristD;
              break;
          }
        }
      }
      switch (material - 13)
      {
        case TransferManager.TransferReason.Garbage:
          info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialOil, ItemClass.Level.Level2);
          break;
        case TransferManager.TransferReason.Crime:
          info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialOre, ItemClass.Level.Level2);
          break;
        case TransferManager.TransferReason.Sick:
          info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialForestry, ItemClass.Level.Level2);
          break;
        case TransferManager.TransferReason.Dead:
          info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialFarming, ItemClass.Level.Level2);
          break;
        case TransferManager.TransferReason.Worker0:
          info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialGeneric, ItemClass.Level.Level1);
          break;
        case TransferManager.TransferReason.Worker1:
        case TransferManager.TransferReason.Logs:
        case TransferManager.TransferReason.Grain:
        case TransferManager.TransferReason.Family0:
        case TransferManager.TransferReason.Family1:
        case TransferManager.TransferReason.Family2:
        case TransferManager.TransferReason.Single1:
        case TransferManager.TransferReason.Single2:
        case TransferManager.TransferReason.Single3:
        case TransferManager.TransferReason.PartnerYoung:
        case TransferManager.TransferReason.PartnerAdult:
        case TransferManager.TransferReason.Shopping:
          switch (material - 88)
          {
            case TransferManager.TransferReason.Garbage:
            case TransferManager.TransferReason.Crime:
            case TransferManager.TransferReason.Sick:
            case TransferManager.TransferReason.Dead:
              goto label_73;
            case TransferManager.TransferReason.Worker1:
            case TransferManager.TransferReason.Worker3:
              transferToSource = true;
              info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportPost, ItemClass.Level.Level5);
              break;
            case TransferManager.TransferReason.Worker2:
            case TransferManager.TransferReason.Student1:
              info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportPost, ItemClass.Level.Level5);
              break;
            default:
              return false;
          }
        case TransferManager.TransferReason.Worker2:
          info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialOre, ItemClass.Level.Level1);
          break;
        case TransferManager.TransferReason.Worker3:
          education1 = Citizen.Education.Uneducated;
          num1 = Singleton<SimulationManager>.instance.m_randomizer.Int32(2, 5);
          break;
        case TransferManager.TransferReason.Student1:
          education1 = Citizen.Education.OneSchool;
          num1 = Singleton<SimulationManager>.instance.m_randomizer.Int32(2, 5);
          break;
        case TransferManager.TransferReason.Student2:
          education1 = Citizen.Education.TwoSchools;
          num1 = Singleton<SimulationManager>.instance.m_randomizer.Int32(2, 5);
          break;
        case TransferManager.TransferReason.Student3:
          education1 = Citizen.Education.ThreeSchools;
          num1 = Singleton<SimulationManager>.instance.m_randomizer.Int32(2, 5);
          break;
        case TransferManager.TransferReason.Fire:
        case TransferManager.TransferReason.LeaveCity1:
          education1 = Citizen.Education.Uneducated;
          num1 = 1;
          break;
        case TransferManager.TransferReason.Bus:
        case TransferManager.TransferReason.LeaveCity2:
          education1 = Citizen.Education.OneSchool;
          num1 = 1;
          break;
        case TransferManager.TransferReason.Oil:
        case TransferManager.TransferReason.Entertainment:
          education1 = Citizen.Education.TwoSchools;
          num1 = 1;
          break;
        case TransferManager.TransferReason.Ore:
        case TransferManager.TransferReason.Lumber:
          education1 = Citizen.Education.ThreeSchools;
          num1 = 1;
          break;
        case TransferManager.TransferReason.Goods:
        case TransferManager.TransferReason.Family3:
        case TransferManager.TransferReason.GarbageMove:
        case TransferManager.TransferReason.MetroTrain:
        case TransferManager.TransferReason.PassengerPlane:
        case TransferManager.TransferReason.PassengerShip:
        case TransferManager.TransferReason.DeadMove:
        case TransferManager.TransferReason.DummyCar:
        case TransferManager.TransferReason.DummyTrain:
        case TransferManager.TransferReason.DummyShip:
        case TransferManager.TransferReason.DummyPlane:
        case TransferManager.TransferReason.Single0B:
label_73:
          flag1 = true;
          break;
        case TransferManager.TransferReason.PassengerTrain:
          info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialOil, ItemClass.Level.Level1);
          break;
        case TransferManager.TransferReason.Coal:
          info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialFarming, ItemClass.Level.Level1);
          break;
        case TransferManager.TransferReason.Single0:
          info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialForestry, ItemClass.Level.Level1);
          break;
        case TransferManager.TransferReason.Petrol:
          if ((int) offer.Building != (int) buildingID)
          {
            flag2 = true;
            info = Singleton<SimulationManager>.instance.m_randomizer.Int32(2U) != 0 ? Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportTrain, ItemClass.Level.Level1) : Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportTrain, ItemClass.Level.Level4);
            break;
          }
          break;
        case TransferManager.TransferReason.Food:
          if ((int) offer.Building != (int) buildingID)
          {
            flag2 = true;
            info = Singleton<SimulationManager>.instance.m_randomizer.Int32(2U) != 0 ? Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportShip, ItemClass.Level.Level1) : Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportShip, ItemClass.Level.Level4);
            break;
          }
          break;
        case TransferManager.TransferReason.LeaveCity0:
          if ((int) offer.Building != (int) buildingID)
          {
            flag2 = true;
            info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportPlane, ItemClass.Level.Level1);
            break;
          }
          break;
        default:
          switch (material - 88)
          {
            case TransferManager.TransferReason.Garbage:
            case TransferManager.TransferReason.Crime:
            case TransferManager.TransferReason.Sick:
            case TransferManager.TransferReason.Dead:
              goto label_73;
            case TransferManager.TransferReason.Worker1:
            case TransferManager.TransferReason.Worker3:
              transferToSource = true;
              info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportPost, ItemClass.Level.Level5);
              break;
            case TransferManager.TransferReason.Worker2:
            case TransferManager.TransferReason.Student1:
              info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportPost, ItemClass.Level.Level5);
              break;
            default:
              return false;
          }
      }
      if (num1 != 0)
      {
        CitizenManager instance2 = Singleton<CitizenManager>.instance;
        ushort building = offer.Building;
        if (building != (ushort) 0)
        {
          uint unitID = 0;
          if (!flag2)
            unitID = instance1.m_buildings.m_buffer[(int) building].GetEmptyCitizenUnit(CitizenUnit.Flags.Home);
          if (unitID > 0U | flag2)
          {
            int family = Singleton<SimulationManager>.instance.m_randomizer.Int32(256U);
            ushort otherInstance = 0;
            Citizen.Gender gender1 = Citizen.Gender.Male;
            DataStore instance3 = DataStore.getInstance();
            int[] singleAge = instance3.singleAge;
            int[] familyAdultAge = instance3.familyAdultAge;
            int[] numArray = num1 == 1 ? singleAge : familyAdultAge;
            int val2 = 0;
            int num2 = 0;
            int num3 = 0;
            for (int index = 0; index < num1; ++index)
            {
              Randomizer randomizer = Singleton<SimulationManager>.instance.m_randomizer;
              int eduChanceAdult = instance3.eduChanceAdult;
              int eduChanceYoung = instance3.eduChanceYoung;
              int eduChanceTeen = instance3.eduChanceTeen;
              uint citizen1 = 0;
              int min = numArray[0];
              int max = numArray[1];
              if (index == 1)
              {
                min = System.Math.Max(val2 - 20, familyAdultAge[0]);
                max = System.Math.Min(val2 + 20, familyAdultAge[1]);
              }
              else if (index >= 2)
              {
                min = num3;
                max = num2;
              }
              int num4 = Singleton<SimulationManager>.instance.m_randomizer.Int32(min, max);
              if (index == 0)
                val2 = num4;
              else if (index == 1)
              {
                val2 = System.Math.Min(num4, val2);
                num2 = System.Math.Max(val2 - 80, 0);
                num3 = System.Math.Max(val2 - 178, 0);
              }
              Citizen.Education education2 = Citizen.Education.Uneducated;
              int num5 = randomizer.Int32(0, 100);
              Citizen.AgeGroup ageGroup = Citizen.GetAgeGroup(num4);
              if (index < 2)
              {
                if (ageGroup == Citizen.AgeGroup.Young)
                  education2 = num5 <= eduChanceTeen ? (num5 <= eduChanceYoung ? Citizen.Education.TwoSchools : Citizen.Education.OneSchool) : Citizen.Education.Uneducated;
                if (ageGroup == Citizen.AgeGroup.Adult || ageGroup == Citizen.AgeGroup.Senior)
                  education2 = num5 <= eduChanceTeen ? (num5 <= eduChanceYoung ? (num5 <= eduChanceAdult ? Citizen.Education.ThreeSchools : Citizen.Education.TwoSchools) : Citizen.Education.OneSchool) : Citizen.Education.Uneducated;
              }
              else
                education2 = ageGroup != Citizen.AgeGroup.Teen ? Citizen.Education.Uneducated : (num5 <= eduChanceTeen ? Citizen.Education.OneSchool : Citizen.Education.Uneducated);
              bool citizen2;
              if (index == 1)
              {
                Citizen.Gender gender2 = Singleton<SimulationManager>.instance.m_randomizer.Int32(100U) >= 5 ? (gender1 != Citizen.Gender.Male ? Citizen.Gender.Male : Citizen.Gender.Female) : gender1;
                citizen2 = instance2.CreateCitizen(out citizen1, num4, family, ref Singleton<SimulationManager>.instance.m_randomizer, gender2);
              }
              else
                citizen2 = instance2.CreateCitizen(out citizen1, num4, family, ref Singleton<SimulationManager>.instance.m_randomizer);
              if (citizen2)
              {
                if (index == 0)
                  gender1 = Citizen.GetGender(citizen1);
                if (education2 >= Citizen.Education.ThreeSchools)
                {
                  instance2.m_citizens.m_buffer[(int) citizen1].Education1 = true;
                  instance2.m_citizens.m_buffer[(int) citizen1].Education2 = true;
                  instance2.m_citizens.m_buffer[(int) citizen1].Education3 = true;
                }
                else if (education2 >= Citizen.Education.TwoSchools)
                {
                  instance2.m_citizens.m_buffer[(int) citizen1].Education1 = true;
                  instance2.m_citizens.m_buffer[(int) citizen1].Education2 = true;
                }
                else if (education2 >= Citizen.Education.OneSchool)
                  instance2.m_citizens.m_buffer[(int) citizen1].Education1 = true;
                if (flag2)
                {
                  Citizen[] buffer = instance2.m_citizens.m_buffer;
                  UIntPtr num6 = (UIntPtr) citizen1;
                  buffer[(int) (uint) num6].m_flags = buffer[(int) (uint) num6].m_flags | Citizen.Flags.DummyTraffic;
                }
                else
                  instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen1].SetHome(citizen1, (ushort) 0, unitID);
                Citizen[] buffer1 = instance2.m_citizens.m_buffer;
                UIntPtr num7 = (UIntPtr) citizen1;
                buffer1[(int) (uint) num7].m_flags = buffer1[(int) (uint) num7].m_flags | Citizen.Flags.MovingIn;
                CitizenInfo citizenInfo = instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen1].GetCitizenInfo(citizen1);
                ushort instance4;
                if ((UnityEngine.Object) citizenInfo != (UnityEngine.Object) null && instance2.CreateCitizenInstance(out instance4, ref Singleton<SimulationManager>.instance.m_randomizer, citizenInfo, citizen1))
                {
                  if (otherInstance == (ushort) 0)
                  {
                    citizenInfo.m_citizenAI.SetSource(instance4, ref instance2.m_instances.m_buffer[(int) instance4], buildingID);
                    citizenInfo.m_citizenAI.SetTarget(instance4, ref instance2.m_instances.m_buffer[(int) instance4], building);
                    otherInstance = instance4;
                  }
                  else
                  {
                    citizenInfo.m_citizenAI.SetSource(instance4, ref instance2.m_instances.m_buffer[(int) instance4], buildingID);
                    citizenInfo.m_citizenAI.JoinTarget(instance4, ref instance2.m_instances.m_buffer[(int) instance4], otherInstance);
                  }
                  instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen1].CurrentLocation = Citizen.Location.Moving;
                }
              }
              else
                break;
            }
          }
        }
      }
      if (flag1)
      {
        CitizenManager instance2 = Singleton<CitizenManager>.instance;
        ushort building = offer.Building;
        ushort transportLine = offer.TransportLine;
        if (building != (ushort) 0)
        {
          int family = Singleton<SimulationManager>.instance.m_randomizer.Int32(256U);
          uint unitID = 0;
          if (!flag2)
            unitID = instance1.m_buildings.m_buffer[(int) building].GetEmptyCitizenUnit(CitizenUnit.Flags.Visit);
          if (unitID > 0U | flag2)
          {
            int age = Singleton<SimulationManager>.instance.m_randomizer.Int32(0, 240);
            Citizen.Wealth wealth = Citizen.Wealth.High;
            int num2 = touristFactor0 + touristFactor1 + touristFactor2;
            if (num2 != 0)
            {
              int num3 = Singleton<SimulationManager>.instance.m_randomizer.Int32((uint) num2);
              if (num3 < touristFactor0)
                wealth = Citizen.Wealth.Low;
              else if (num3 < touristFactor0 + touristFactor1)
                wealth = Citizen.Wealth.Medium;
            }
            uint citizen;
            if (instance2.CreateCitizen(out citizen, age, family, ref Singleton<SimulationManager>.instance.m_randomizer))
            {
              Citizen[] buffer1 = instance2.m_citizens.m_buffer;
              UIntPtr num3 = (UIntPtr) citizen;
              buffer1[(int) (uint) num3].m_flags = buffer1[(int) (uint) num3].m_flags | Citizen.Flags.Tourist;
              Citizen[] buffer2 = instance2.m_citizens.m_buffer;
              UIntPtr num4 = (UIntPtr) citizen;
              buffer2[(int) (uint) num4].m_flags = buffer2[(int) (uint) num4].m_flags | Citizen.Flags.MovingIn;
              instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen].WealthLevel = wealth;
              if (flag2)
              {
                Citizen[] buffer3 = instance2.m_citizens.m_buffer;
                UIntPtr num5 = (UIntPtr) citizen;
                buffer3[(int) (uint) num5].m_flags = buffer3[(int) (uint) num5].m_flags | Citizen.Flags.DummyTraffic;
              }
              else
                instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen].SetVisitplace(citizen, (ushort) 0, unitID);
              CitizenInfo citizenInfo = instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen].GetCitizenInfo(citizen);
              ushort instance3;
              if ((UnityEngine.Object) citizenInfo != (UnityEngine.Object) null && instance2.CreateCitizenInstance(out instance3, ref Singleton<SimulationManager>.instance.m_randomizer, citizenInfo, citizen))
              {
                citizenInfo.m_citizenAI.SetSource(instance3, ref instance2.m_instances.m_buffer[(int) instance3], buildingID);
                citizenInfo.m_citizenAI.SetTarget(instance3, ref instance2.m_instances.m_buffer[(int) instance3], building);
                instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen].CurrentLocation = Citizen.Location.Moving;
              }
              if (!flag2)
                Singleton<StatisticsManager>.instance.Acquire<StatisticArray>(StatisticType.IncomingTourists).Acquire<StatisticInt32>((int) wealth, 3).Add(1);
            }
          }
        }
        else if (transportLine != (ushort) 0)
        {
          TransportManager instance3 = Singleton<TransportManager>.instance;
          int num2 = instance3.m_lines.m_buffer[(int) transportLine].CountStops(transportLine);
          if (num2 > 0)
          {
            int index = Singleton<SimulationManager>.instance.m_randomizer.Int32((uint) num2);
            ushort stop = instance3.m_lines.m_buffer[(int) transportLine].GetStop(index);
            if (stop != (ushort) 0)
            {
              int family = Singleton<SimulationManager>.instance.m_randomizer.Int32(256U);
              int age = Singleton<SimulationManager>.instance.m_randomizer.Int32(0, 240);
              Citizen.Wealth wealth = Citizen.Wealth.High;
              int num3 = touristFactor0 + touristFactor1 + touristFactor2;
              if (num3 != 0)
              {
                int num4 = Singleton<SimulationManager>.instance.m_randomizer.Int32((uint) num3);
                if (num4 < touristFactor0)
                  wealth = Citizen.Wealth.Low;
                else if (num4 < touristFactor0 + touristFactor1)
                  wealth = Citizen.Wealth.Medium;
              }
              uint citizen;
              if (instance2.CreateCitizen(out citizen, age, family, ref Singleton<SimulationManager>.instance.m_randomizer))
              {
                Citizen[] buffer1 = instance2.m_citizens.m_buffer;
                UIntPtr num4 = (UIntPtr) citizen;
                buffer1[(int) (uint) num4].m_flags = buffer1[(int) (uint) num4].m_flags | Citizen.Flags.Tourist;
                Citizen[] buffer2 = instance2.m_citizens.m_buffer;
                UIntPtr num5 = (UIntPtr) citizen;
                buffer2[(int) (uint) num5].m_flags = buffer2[(int) (uint) num5].m_flags | Citizen.Flags.MovingIn;
                instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen].WealthLevel = wealth;
                CitizenInfo citizenInfo = instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen].GetCitizenInfo(citizen);
                ushort instance4;
                if ((UnityEngine.Object) citizenInfo != (UnityEngine.Object) null && instance2.CreateCitizenInstance(out instance4, ref Singleton<SimulationManager>.instance.m_randomizer, citizenInfo, citizen))
                {
                  citizenInfo.m_citizenAI.SetSource(instance4, ref instance2.m_instances.m_buffer[(int) instance4], buildingID);
                  citizenInfo.m_citizenAI.SetTarget(instance4, ref instance2.m_instances.m_buffer[(int) instance4], stop, true);
                  instance2.m_citizens.m_buffer[(int) (uint) (UIntPtr) citizen].CurrentLocation = Citizen.Location.Moving;
                  Singleton<StatisticsManager>.instance.Acquire<StatisticArray>(StatisticType.IncomingTourists).Acquire<StatisticInt32>((int) wealth, 3).Add(1);
                }
                else
                  instance2.ReleaseCitizen(citizen);
              }
            }
          }
        }
      }
      if ((UnityEngine.Object) info != (UnityEngine.Object) null)
      {
        Array16<Vehicle> vehicles = Singleton<VehicleManager>.instance.m_vehicles;
        ushort vehicle;
        if (Singleton<VehicleManager>.instance.CreateVehicle(out vehicle, ref Singleton<SimulationManager>.instance.m_randomizer, info, data.m_position, material, transferToSource, !transferToSource))
        {
          if (flag2)
          {
            vehicles.m_buffer[(int) vehicle].m_flags |= Vehicle.Flags.DummyTraffic;
            vehicles.m_buffer[(int) vehicle].m_flags &= Vehicle.Flags.Created | Vehicle.Flags.Deleted | Vehicle.Flags.Spawned | Vehicle.Flags.Inverted | Vehicle.Flags.TransferToTarget | Vehicle.Flags.TransferToSource | Vehicle.Flags.Emergency1 | Vehicle.Flags.Emergency2 | Vehicle.Flags.WaitingPath | Vehicle.Flags.Stopped | Vehicle.Flags.Leaving | Vehicle.Flags.Arriving | Vehicle.Flags.Reversed | Vehicle.Flags.TakingOff | Vehicle.Flags.Flying | Vehicle.Flags.Landing | Vehicle.Flags.WaitingSpace | Vehicle.Flags.GoingBack | Vehicle.Flags.WaitingTarget | Vehicle.Flags.Importing | Vehicle.Flags.Exporting | Vehicle.Flags.Parking | Vehicle.Flags.CustomName | Vehicle.Flags.OnGravel | Vehicle.Flags.WaitingLoading | Vehicle.Flags.Congestion | Vehicle.Flags.DummyTraffic | Vehicle.Flags.Underground | Vehicle.Flags.Transition | Vehicle.Flags.InsideBuilding | Vehicle.Flags.LeftHandDrive;
          }
          info.m_vehicleAI.SetSource(vehicle, ref vehicles.m_buffer[(int) vehicle], buildingID);
          info.m_vehicleAI.StartTransfer(vehicle, ref vehicles.m_buffer[(int) vehicle], material, offer);
          if (!flag2)
          {
            ushort building = offer.Building;
            if (building != (ushort) 0)
            {
              int size;
              int max;
              info.m_vehicleAI.GetSize(vehicle, ref vehicles.m_buffer[(int) vehicle], out size, out max);
              if (!transferToSource)
                OutsideConnectionAI.ImportResource(building, ref Singleton<BuildingManager>.instance.m_buildings.m_buffer[(int) building], material, size);
            }
          }
        }
      }
      return true;
    }
  }
}
