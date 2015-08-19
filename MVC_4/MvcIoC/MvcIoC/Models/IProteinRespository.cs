using System;
namespace MvcIoC.Models
{
  public  interface IProteinRespository
    {
        ProteinData GetData ( DateTime dateTime );
        void SetGoal ( DateTime dateTime, int value );
        void SetTotal ( DateTime dateTime, int value );
    }
}
