using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CommonsOperations.BaseSql
{
 public class BaseDTO {
        protected List<SqlParameter> parametros = new List<SqlParameter>();
        protected internal SqlCommand command;
        protected internal SqlConnection connection;
        private string cadenaConexion;


        public BaseDTO(string cadenaConexion){
            this.cadenaConexion = cadenaConexion;
        }

        /// <summary>
        /// Execute a store procedure that return a Datareader, this Datareader is Mapper to the generict List
        /// </summary>
        /// <param name="ProcedureName"> Name of Procedure </param>
        /// <param name="objeto"> Object to pass into the procedure </param>
        /// <returns> Generic List  </returns>
        protected List<T> ExuecuteProcedure<T>(string ProcedureName)
        {
            command = null;
            SqlDataReader dataReader = null;
            try
            {

                connection = new SqlConnection(cadenaConexion);
                command = new SqlCommand(ProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                if (parametros != null) { foreach (SqlParameter item in parametros) { command.Parameters.Add(item); } }
                dataReader = command.ExecuteReader();
                return (dataReader.HasRows) ? Map.MapFromDataReader<T>(dataReader).ToList() : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                if (!dataReader.IsClosed)
                    dataReader.Dispose();

                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// Execute a Store Procedure that not return a value
        /// </summary>
        /// <returns></returns>
        protected bool ExecuteNonQueryBase(string ProcedureName)
        {
            Boolean Result = false;
            command = null;
            try
            {
                connection = new SqlConnection(cadenaConexion);
                command = new SqlCommand(ProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                if (parametros != null) { foreach (SqlParameter item in parametros) { command.Parameters.Add(item); } }
                command.ExecuteNonQuery();
                Result = true;
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }




        /// <summary>
        ///  Add the parameters to the Store Procedure
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// 
        protected void AddParameters(string name, SqlDbType type, object value)
        {
            SqlParameter NewParameter = new SqlParameter(name, value);
            NewParameter.SqlDbType = type;
            parametros.Add(NewParameter);
        }

    }
}
