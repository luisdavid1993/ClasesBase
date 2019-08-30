using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsOperations.BaseOracle
{
  public  class ejemploOracle : OracleRepositoryBase
    {

        //public ejemploOracle() : base(ConfigurationManager.ConnectionStrings["ConnectionPortalVenta"].ConnectionString) { }

        //public string ConsultaLinea(string linea)
        //{

        //    try
        //    {
        //        DataSet resultado = new DataSet();
        //        dbConnection = new OracleConnection(dbConnectionString);
        //        SetupCommand("USIMSERCON.SP_GETINFOMIN", true);
        //        dbCommand.Parameters.Add("In_min", OracleDbType.Varchar2, linea, ParameterDirection.Input);
        //        AddCommandCursor("p_recordset");
        //        dbConnection.Open();
        //        OracleDataAdapter adaptador = new OracleDataAdapter(dbCommand);
        //        adaptador.Fill(resultado);

        //        return resultado.Tables[0].Select().ToList().Select(x => x.Field<string>("mensaje")).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        DisposeResources();
        //    }


        //}

    }
}
