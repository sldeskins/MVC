using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIoC.Models
{
    public class ProteinRespository : IProteinRespository
    {
        private readonly string dataSource;

        public ProteinRespository ( string dataSource )
        {
            this.dataSource = dataSource;
        }

        private static ProteinData data = new ProteinData();
        public ProteinData GetData ( DateTime dateTime )
        {
            return data;
        }

        public void SetTotal ( DateTime dateTime, int value )
        {
            data.Total = value;
        }

        public void SetGoal ( DateTime dateTime, int value )
        {
            data.Goal = value;
        }
    }
}