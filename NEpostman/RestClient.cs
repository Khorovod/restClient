using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace NEpostman
{
    public enum HttpMethods
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestClient
    {
        //ссылка
        public string EndPoint { get; set; }
        public HttpMethods HttpMethods { get; set; }

        public RestClient()
        {
            EndPoint = string.Empty;
            HttpMethods = HttpMethods.GET;
        }

        public string MakeRequest()
        {
            string responseValue = "";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
                request.Method = HttpMethods.ToString();

                //возможно надо сделать отдельный метод?
                using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                {
                    if (webResponse.StatusCode != HttpStatusCode.OK)
                    {
                        return MessageBox.Show(webResponse.StatusCode.ToString(), "Запрос закончился ошбикой:").ToString();
                    }

                    //Обработка респонса (json,....)
                    using (Stream responseStream = webResponse.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                        }
                    }
                }

                return responseValue;
            }
            catch (Exception ex)
            {
                return MessageBox.Show(ex.ToString(), "Ошибка в запросе:" ).ToString();
            }

        }
    }
}
