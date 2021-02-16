// Decompiled with JetBrains decompiler
// Type: ImmigrantEducationMod.XML
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ImmigrantEducationMod
{
  internal class XML
  {
    private static string fileLocation = LoadingExtension.currentFileLocation;

    public static void ReadFromBinaryFile()
    {
      try
      {
        using (Stream serializationStream = (Stream) File.Open(XML.fileLocation, FileMode.Open))
          DataStore.instance = (DataStore) new BinaryFormatter().Deserialize(serializationStream);
      }
      catch (Exception ex)
      {
        Debug.Log((object) string.Format("exception in ReadIntoXML(), used default. {0}", (object) ex));
        DataStore.SetDefault();
        XML.WriteToBinaryFile(DataStore.getInstance(), false);
      }
    }

    public static void WriteToBinaryFile(DataStore objectToWrite, bool append = false)
    {
      using (Stream serializationStream = (Stream) File.Open(XML.fileLocation, append ? FileMode.Append : FileMode.Create))
        new BinaryFormatter().Serialize(serializationStream, (object) objectToWrite);
    }
  }
}
