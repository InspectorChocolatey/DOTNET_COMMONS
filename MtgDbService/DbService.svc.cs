namespace MtgDbService
{
    using System;                           /* _.Convert                                        */
    using System.Data;                      /* _.DataSet, _.SqlDbType, _.CommandType, _.DataRow */
    using System.Configuration;             /* _.ConfigurationManager                           */
    using System.Data.SqlClient;            /* _.SqlCommand, _.SqlConnection. _.SqlDataAdapter  */
    using System.Collections.Generic;       /* _.List<MtgSet>                                   */

    public class DbService : IDbService
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["mtg"].ConnectionString;
        }

        public int DeleteMtgSet(MtgSet mtgSet)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.DeleteSet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SetID", SqlDbType.Int).Value = mtgSet.SetId;
                    con.Open();
                    var ID = cmd.ExecuteNonQuery();
                    return ID;
                }
            }
        }

        public int InsertMtgSet(MtgSet mtgSet)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.InsertSet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(@"SetName", SqlDbType.VarChar, 100).Value = mtgSet.SetName;
                    cmd.Parameters.Add(@"SetSize", SqlDbType.Int).Value = mtgSet.SetSize;
                    cmd.Parameters.Add(@"SetRares", SqlDbType.VarChar).Value = mtgSet.SetRares;
                    cmd.Parameters.Add(@"SetUncommons", SqlDbType.VarChar).Value = mtgSet.SetUncommons;
                    cmd.Parameters.Add(@"SetCommons", SqlDbType.VarChar).Value = mtgSet.SetCommons;
                    cmd.Parameters.Add(@"SetBasicLands", SqlDbType.VarChar).Value = mtgSet.SetBasicLands;
                    cmd.Parameters.Add(@"SetReleaseDate", SqlDbType.VarChar).Value = mtgSet.SetReleaseDate;
                    con.Open();
                    var ID = cmd.ExecuteScalar();
                    mtgSet.SetId = Convert.ToInt32(ID.ToString());
                }
            }
            return mtgSet.SetId;
        }



        public List<MtgSet> SelectAllMtgSet()
        {
            List<MtgSet> mtgSets = new List<MtgSet>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SelectAllSet", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataSet dataSet = new DataSet();
                        da.Fill(dataSet);
                        if (dataSet.Tables.Count > 0)
                        {
                            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                            {
                                mtgSets.Add(

                                    new MtgSet
                                    {
                                        SetId = Convert.ToInt32(dataRow["SetID"].ToString()),
                                        SetName = dataRow["SetName"].ToString(),
                                        SetSize = (int)dataRow["SetSize"],
                                        SetRares = (int)dataRow["SetRares"],
                                        SetUncommons = (int)dataRow["SetUncommons"],
                                        SetCommons = (int)dataRow["SetCommons"],
                                        SetBasicLands = (int)dataRow["SetBasicLands"],
                                        SetReleaseDate = (String)dataRow["SetReleaseDate"].ToString()
                                    }

                                );
                            }
                        }
                    }
                }
            }
            return mtgSets;
        }

        public int UpdateMtgSet(MtgSet mtgSet)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.UpdateSet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SetID", SqlDbType.Int).Value = mtgSet.SetId;
                    cmd.Parameters.Add("@SetName", SqlDbType.VarChar, 100).Value = mtgSet.SetName;
                    cmd.Parameters.Add("@SetSize", SqlDbType.Int).Value = mtgSet.SetSize;
                    cmd.Parameters.Add("@SetRares", SqlDbType.Int).Value = mtgSet.SetRares;
                    cmd.Parameters.Add("@SetUncommons", SqlDbType.Int).Value = mtgSet.SetUncommons;
                    cmd.Parameters.Add("@SetCommons", SqlDbType.Int).Value = mtgSet.SetCommons;
                    cmd.Parameters.Add("@SetBasicLands", SqlDbType.Int).Value = mtgSet.SetBasicLands;
                    cmd.Parameters.Add("@SetReleaseDate", SqlDbType.DateTime).Value = mtgSet.SetReleaseDate;

                    con.Open();
                    var ID = cmd.ExecuteNonQuery();
                    return ID;
                }
            }
        }
    }
}
