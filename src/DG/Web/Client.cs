using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DG.Web
{
    /// <summary>
    /// WebClient
    /// </summary>
    public static class Client
    {
        /// <summary>
        /// 超时时间默认1分钟
        /// </summary>
        private const int OutTime = 60 * 1000;

        /// <summary>
        /// 调用Url返回结果（注：输入输出都为json格式）
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="url">Post的Url地址</param>
        /// <param name="data">输入的数据（实体、object）</param>
        /// <returns></returns>
        public static T JsonString<T>(string url,object data,int outTime= OutTime)
        {
            using (WebClient client = new WebClientTimer(outTime))
            {
                client.Proxy = null;
                
                var str=JsonConvert.SerializeObject(data);
                var json=client.UploadString(url,str);
                if (string.IsNullOrEmpty(json))
                {
                    throw new Exception("调用接口[" + url + "]失败，请求结果异常！");
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        /// <summary>
        ///调用Url返回结果（JsonString 注：输入输出都为json格式）
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <param name="url">Post的Url地址</param>
        /// <returns></returns>
        public static T JsonString<T>(this string jsonStr, string url, int outTime = OutTime)
        {
            using (WebClient client = new WebClientTimer(outTime))
            {
                var str = JsonConvert.SerializeObject(jsonStr);
                client.Proxy = null;
                var json = client.UploadString(url, str);
                if (string.IsNullOrEmpty(json))
                {
                    throw new Exception("调用接口["+url+"]失败，请求结果异常！");
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        /// <summary>
        /// 调用Url返回结果（NameValueCollection）
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="data"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T KVData<T>(this NameValueCollection data,string url, int outTime = OutTime)
        {
            using (WebClient client = new WebClientTimer(outTime))
            {
                client.Proxy = null;
                //调用方法将键值对上传
                byte[] bytes = client.UploadValues(url, data);

                //将字节数组的所有元素转换为一个字符串
                string json = Encoding.UTF8.GetString(bytes);

                if (string.IsNullOrEmpty(json))
                {
                    throw new Exception("调用接口[" + url + "]失败，请求结果异常！");
                }
                //将Json字符串转换为对象
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }

    public class WebClientTimer: WebClient
    {
        /// <summary>  
        /// 过期时间  
        /// </summary>  
        public int Timeout { get; set; }

        public WebClientTimer(int timeout)
        {
            Timeout = timeout;
        }

        /// <summary>  
        /// 重写GetWebRequest,添加WebRequest对象超时时间  
        /// </summary>  
        /// <param name="address"></param>  
        /// <returns></returns>  
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = Timeout;
            request.ReadWriteTimeout = Timeout;
            return request;
        }
    }
}
