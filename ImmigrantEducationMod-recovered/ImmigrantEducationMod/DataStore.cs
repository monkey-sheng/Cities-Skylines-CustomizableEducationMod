// Decompiled with JetBrains decompiler
// Type: ImmigrantEducationMod.DataStore
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

using System;

namespace ImmigrantEducationMod
{
  [Serializable]
  public class DataStore
  {
    public int eduChanceAdult = 50;
    public int eduChanceYoung = 80;
    public int eduChanceTeen = 95;
    public int[] singleAge = new int[2]{ 65, 165 };
    public int[] familyAdultAge = new int[2]{ 85, 185 };
    public static DataStore instance;

    public static DataStore getInstance()
    {
      if (DataStore.instance == null)
        DataStore.instance = new DataStore();
      return DataStore.instance;
    }

    public static void releaseInstance()
    {
      DataStore.instance = (DataStore) null;
    }

    public static void SetDefault()
    {
      DataStore instance = DataStore.getInstance();
      instance.eduChanceAdult = 50;
      instance.eduChanceYoung = 80;
      instance.eduChanceTeen = 95;
      instance.singleAge = new int[2]{ 65, 165 };
      instance.familyAdultAge = new int[2]{ 85, 185 };
    }
  }
}
