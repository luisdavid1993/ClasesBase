using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsOperations.BaseOracle
{
 public abstract class OracleRepositoryBase
    {
        ///// <summary>
        ///// Comando a ejecutar en la base de datos Oracle.
        ///// </summary>
        //protected internal OracleCommand dbCommand;

        ///// <summary>
        ///// Conexión a la base de datos Oracle.
        ///// </summary>
        //protected internal OracleConnection dbConnection;

        ///// <summary>
        ///// Cadena de conexión a la base de datos Oracle.
        ///// </summary>
        //protected internal string dbConnectionString;

        ///// <summary>
        ///// Lector de datos de un cursor Oracle.
        ///// </summary>
        //protected internal OracleDataReader dbDataReader;



        ///// <summary>
        ///// Constructor que prepara la conexión a la base de datos Oracle
        ///// </summary>
        ///// <param name="connectionString">Cadena de conexión a la base de datos Oracle.</param>
        //public OracleRepositoryBase(string connectionString)
        //{
        //    // Inicializar los campos
        //    dbConnectionString = connectionString;
        //    dbConnection = null;
        //    dbCommand = null;
        //    dbDataReader = null;
        //}

        ///// <summary>
        ///// Agrega un cursor al comando Oracle.
        ///// </summary>
        ///// <param name="name">Nombre del cursor.</param>
        //protected void AddCommandCursor(string name)
        //{
        //    // Declarar e inicializar el nuevo cursor
        //    OracleParameter newCursor = new OracleParameter(name, OracleDbType.RefCursor, ParameterDirection.Output);

        //    /*OracleParameter newCursor = new OracleParameter(name, OracleType.Cursor);
        //    newCursor.Direction = ParameterDirection.Output;*/

        //    // Agregar el nuevo cursor al comando
        //    dbCommand.Parameters.Add(newCursor);
        //}

        ///// <summary>
        ///// Agrega un parámetro al comando Oracle.
        ///// </summary>
        ///// <param name="type">Tipo de dato del parámetro.</param>
        ///// <param name="name">Nombre del parámetro.</param>
        ///// <param name="value">Valor del parámetro.</param>
        ///// <param name="direction">Indica si el parámetro es de entrada o de salida.</param>
        //protected internal void AddCommandParameter(DbType type, string name, object value, ParameterDirection direction)
        //{
        //    // Declarar e inicializar el nuevo parámetro
        //    OracleParameter newParameter = new OracleParameter(name, value);
        //    newParameter.Direction = direction;
        //    newParameter.DbType = type;

        //    // Agregar el nuevo parámetro al comando
        //    dbCommand.Parameters.Add(newParameter);
        //}

        //protected internal void AddCommandParameter(OracleDbType type, string name, object value, ParameterDirection direction)
        //{
        //    // Declarar e inicializar el nuevo parámetro
        //    OracleParameter newParameter = new OracleParameter(name, type, value, direction);
        //    // Agregar el nuevo parámetro al comando
        //    dbCommand.Parameters.Add(newParameter);
        //}

        ///// <summary>
        ///// Agrega un parámetro al comando Oracle.
        ///// </summary>
        ///// <param name="type">Tipo de dato del parámetro.</param>
        ///// <param name="name">Nombre del parámetro.</param>
        ///// <param name="value">Valor del parámetro.</param>
        ///// <param name="size">Tamaño del parámetro. Si el valor es '0', no se tiene en cuenta.</param>
        ///// <param name="direction">Indica si el parámetro es de entrada o de salida.</param>
        //protected internal void AddCommandParameter(DbType type, string name, object value, int size, ParameterDirection direction)
        //{
        //    // Declarar e inicializar el nuevo parámetro
        //    OracleParameter newParameter = new OracleParameter(name, value);
        //    newParameter.Direction = direction;
        //    newParameter.DbType = type;
        //    if (size != 0)
        //    {
        //        newParameter.Size = size;
        //    }

        //    // Agregar el nuevo parámetro al comando
        //    dbCommand.Parameters.Add(newParameter);
        //}

        ///// <summary>
        ///// Libera los recursos de la conexión, comando y data reader.
        ///// </summary>
        //protected internal void DisposeResources()
        //{
        //    if (dbDataReader != null)
        //    {
        //        dbDataReader.Dispose();
        //        dbDataReader = null;
        //    }
        //    if (dbCommand != null)
        //    {
        //        dbCommand.Dispose();
        //        dbCommand = null;
        //    }
        //    if (dbConnection != null)
        //    {
        //        dbConnection.Close();
        //        dbConnection.Dispose();
        //        dbConnection = null;
        //    }
        //}

        ///// <summary>
        ///// Inicializa el comando Oracle.
        ///// </summary>
        ///// <param name="name">Contiene el texto del comando. Si es un StoredProcedure, contiene el nombre del mismo.</param>
        ///// <param name="isProcedure">Indica si el comando a inicializar es o no un Procedure.</param>
        //protected internal void SetupCommand(string name, bool isProcedure)
        //{
        //    // Inicializar el comando
        //    dbCommand = new OracleCommand(name, dbConnection);
        //    dbCommand.CommandType = (isProcedure) ? CommandType.StoredProcedure : CommandType.Text;
        //    dbCommand.BindByName = true;
        //}



    }
}

