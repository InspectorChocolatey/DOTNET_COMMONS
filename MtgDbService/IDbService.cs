namespace MtgDbService
{
    using System;                       /* _.Int32,                                          */
    using System.ServiceModel;          /* _.ServiceContrace,                                */
    using System.Collections.Generic;   /* _.List<MtgSet>,                                   */
    using System.Runtime.Serialization; /* _.DataMember, _.DataContract, _.OperationContract */

    [ServiceContract]
    public interface IDbService
    {
        [OperationContract]
        string GetConnectionString();

        [OperationContract]
        Int32 InsertMtgSet(MtgSet mtgSet);

        [OperationContract]
        int UpdateMtgSet(MtgSet mtgSet);

        [OperationContract]
        List<MtgSet> SelectAllMtgSet();

        [OperationContract]
        int DeleteMtgSet(MtgSet mtgSet);
    }

    [DataContract]
    public class MtgSet
    {
        private Int32 set_id;
        private string set_name;
        private int set_size;
        private int set_rares;
        private int set_uncommons;
        private int set_commons;
        private int set_basiclands;
        private string set_releasedate;

        [DataMember]
        public Int32 SetId
        {
            get { return set_id; }
            set { set_id = value; }
        }

        [DataMember]
        public string SetName
        {
            get { return set_name; }
            set { set_name = value; }
        }

        [DataMember]
        public int SetSize
        {
            get { return set_size; }
            set { set_size = value; }
        }

        [DataMember]
        public int SetRares
        {
            get { return set_rares; }
            set { set_rares = value; }
        }

        [DataMember]
        public int SetUncommons
        {
            get { return set_uncommons; }
            set { set_uncommons = value; }
        }

        [DataMember]
        public int SetCommons
        {
            get { return set_commons; }
            set { set_commons = value; }
        }

        [DataMember]
        public int SetBasicLands
        {
            get { return set_basiclands; }
            set { set_basiclands = value; }
        }

        [DataMember]
        public string SetReleaseDate
        {
            get { return set_releasedate; }
            set { set_releasedate = value; }
        }
    }
}
