using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonsOperations.BaseSql
{
    public static class Map
    {

        public static Collection<T> MapFromDataReader<T>(IDataReader reader)
        {
            try
            {
                Type newType = typeof(T);
                Collection<T> returnList = new Collection<T>();
                object[] values = new object[reader.FieldCount];
                Dictionary<string, int> columnsIds = new Dictionary<string, int>(reader.FieldCount);
                DataTable dtSchema = null;
                while (reader.Read())
                {
                    reader.GetValues(values);
                    T objTarget = Activator.CreateInstance<T>();
                    dtSchema = reader.GetSchemaTable();
                    foreach (var prop in objTarget.GetType().GetProperties())
                    {
                        try
                        {
                            string nameOfColumn = "";
                            // Obtiene el nombre de las propiedades del objecto
                            PropertyInfo propertyInfo = objTarget.GetType().GetProperty(prop.Name);
                            // Obtiene el nombre del [Column(Name = "")] de la propiedad si la dataanotacion es de tipo [Column(Name = "")]
                            foreach (var tipoDato in prop.CustomAttributes)
                            {
                                if (tipoDato.AttributeType.Name == "ColumnAttribute")
                                {
                                    nameOfColumn = tipoDato.NamedArguments[0].TypedValue.Value.ToString();
                                    break;
                                }
                            }
                            // Le inserta el valor a la propiedad, 1 objeto, 2 valor, 3 tipo de la propiedad
                            int posicion = dtSchema.Select().ToList().Where(x => x.Field<string>("ColumnName").ToLower() == nameOfColumn.ToLower()).Select(y => y.Field<int>("ColumnOrdinal")).FirstOrDefault();
                            propertyInfo.SetValue(objTarget, Convert.ChangeType(values[posicion], propertyInfo.PropertyType), null);
                            //row[prop.Name]
                        }
                        catch
                        {
                            continue;
                        }
                    }







                    returnList.Add(objTarget);
                }

                reader.Dispose();
                return returnList.Count > 0 ? returnList : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
                reader.Dispose();
            }
        }
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    // Instancia un objecto del tipo que recibe en T
                    T obj = new T();
                    // Recorre las propiedades del objeto obj
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            string nameOfColumn = "";
                            // Obtiene el nombre de las propiedades del objecto
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            // Obtiene el nombre del [Column(Name = "")] de la propiedad si la dataanotacion es de tipo [Column(Name = "")]
                            foreach (var tipoDato in prop.CustomAttributes)
                            {
                                if (tipoDato.AttributeType.Name == "ColumnAttribute")
                                {
                                    nameOfColumn = tipoDato.NamedArguments[0].TypedValue.Value.ToString();
                                    break;
                                }
                            }
                            // Le inserta el valor a la propiedad, 1 objeto, 2 valor, 3 tipo de la propiedad
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[nameOfColumn], propertyInfo.PropertyType), null);
                            //row[prop.Name]
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }




        public static List<T> MapperList<T, T1>(this List<T1> table)
            where T : class, new()
            where T1 : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table)
                {
                    // Instancia un objecto del tipo que recibe en T
                    T obj = new T();
                    // Recorre las propiedades del objeto obj
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            string nameOfColumn = "";
                            // Obtiene el nombre de las propiedades del objecto
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            // Le inserta el valor a la propiedad, 1 objeto, 2 valor, 3 tipo de la propiedad

                            foreach (var tipoDato in prop.CustomAttributes)
                            {
                                if (tipoDato.AttributeType.Name == "ColumnAttribute")
                                {
                                    nameOfColumn = tipoDato.NamedArguments[0].TypedValue.Value.ToString();
                                    break;
                                }
                            }
                            propertyInfo.SetValue(obj, Convert.ChangeType(row.GetType().GetProperty(nameOfColumn).GetValue(row), propertyInfo.PropertyType), null);
                            //row[prop.Name]
                        }
                        catch { continue; }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

    }
}
