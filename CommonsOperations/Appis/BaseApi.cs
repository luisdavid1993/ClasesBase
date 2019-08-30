﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
namespace CommonsOperations.Appis
{
   public class BaseApi
    {
        protected readonly string _endpoint;
        protected readonly string _User;
        protected readonly string _Pass;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="endpoint">endpoint o url del servicio rest api</param>
        /// <Author>Jairo Sanabria</Author>
        public BaseApi(string endpoint)
        {
            _endpoint = endpoint;
            _User = ConfigurationManager.AppSettings["ApiUsuario"];
            _Pass = ConfigurationManager.AppSettings["ApiPassword"];
        }


        /// <summary>
        /// Metodo generico para realizar petición post para obtener una lista
        /// </summary>
        /// <typeparam name="T">Tipo de Objetoque envia y recibe</typeparam>
        /// <param name="statusCode">HttpStatusCode parametro de entrada-salida</param>
        /// <param name="parameters">diccionario de parametros</param>
        /// <returns>T</returns>
        /// <Author>Jairo Sanabria</Author>
        public T Get<T>(out HttpStatusCode statusCode, Dictionary<string, string> parameters)
        {
            using (var httpClient = NewHttpClient())
            {
                var endpoint = _endpoint;
                if (parameters != null)
                {
                    endpoint += "?";
                    string _parameters = string.Empty;
                    int iCount = 0;
                    foreach (var item in parameters)
                    {
                        iCount++;
                        _parameters += string.Format("{0}={1}", item.Key, item.Value);
                        if (parameters.Count() != iCount)
                            _parameters += "&";
                    }
                    endpoint += _parameters;
                }
                httpClient.SetBasicAuthentication(_User, _Pass);
                var response = httpClient.GetAsync(endpoint).Result;
                statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                else
                    return default(T);
            }
        }

        public T Get<T>(out HttpStatusCode statusCode)
        {
            using (var httpClient = NewHttpClient())
            {
                var endpoint = _endpoint;
                httpClient.SetBasicAuthentication(_User, _Pass);
                var response = httpClient.GetAsync(endpoint).Result;
                statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                else
                    return default(T);
            }
        }

        public T Get<T>(int id, out HttpStatusCode statusCode)
        {
            using (var httpClient = NewHttpClient())
            {
                httpClient.SetBasicAuthentication(_User, _Pass);
                var response = httpClient.GetAsync(_endpoint + id).Result;
                statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                else
                    return default(T);
            }
        }

        public T Post<T>(T data, out HttpStatusCode statusCode)
        {
            using (var httpClient = NewHttpClient())
            {
                httpClient.SetBasicAuthentication(_User, _Pass);
                var response = httpClient.PostAsJsonAsync(_endpoint, data).Result;
                statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public T Post<T, T1>(T1 data, out HttpStatusCode statusCode)
        {
            using (var httpClient = NewHttpClient())
            {
                httpClient.SetBasicAuthentication(_User, _Pass);
                var response = httpClient.PostAsJsonAsync(_endpoint, data).Result;
                statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public HttpStatusCode Put<T>(int? id, T data)
        {
            using (var httpClient = NewHttpClient())
            {
                httpClient.SetBasicAuthentication(_User, _Pass);
                var content = new ObjectContent<T>(data, new JsonMediaTypeFormatter());
                var response = httpClient.PutAsync(_endpoint + (id == null ? "" : id.ToString()), content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return response.StatusCode;
            }
        }

        public HttpStatusCode Delete(int id)
        {
            using (var httpClient = NewHttpClient())
            {
                httpClient.SetBasicAuthentication(_User, _Pass);
                var result = httpClient.DeleteAsync(_endpoint + id).Result;
                return result.StatusCode;
            }
        }

        protected HttpClient NewHttpClient()
        {
            return new HttpClient();
        }
    }
}
