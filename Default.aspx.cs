﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        tRequest.Method = "post";
        tRequest.ContentType = "application/json";
        var objNotification = new
        {
            to = "cmwf1CbB-fA:APA91bHSAlzQkgtU853DMpmaW9qQvwC-EKzmxdWPjIev59GikhHlhORWv1g1k3AIuJaPPbkrte7cxztb5Hx6vJWO_Dfs-AUKTIsj4vdDdvbtVQarUi9fOijDeoyBmDy1wUp41uBt2tFD",
            notification = new
            {
                body = "This is the message1",
                title = "This is the title1"
            }

        };
        string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(objNotification);
        Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
        tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAaGSN358:APA91bHeYq6Ywnhj4iSTEhEIr2-LQUziLJR6_ExMf-q1Y_ADM5WMLLw0CB2OK2GR5vltZq7LkrTxXYADgP-cJxXkpa6wxKCE9oFmjP6hWeEfXNOgZx-7-_ymuivxpwyxyy5s21682Xsq2GiQvG8ptt_JJJayUUxpLA"));
        tRequest.Headers.Add(string.Format("Sender: id={0}", "448363618207"));
        tRequest.ContentLength = byteArray.Length;
        tRequest.ContentType = "application/json; charset=UTF-8";
        using (Stream dataStream = tRequest.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);

            using (WebResponse tResponse = tRequest.GetResponse())
            {
                using (Stream dataStreamResponse = tResponse.GetResponseStream())
                {
                    using (StreamReader tReader = new StreamReader(dataStreamResponse))
                    {
                        String responseFromFirebaseServer = tReader.ReadToEnd();

                        FCMResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                        if (response.success == 1)
                        {

                        }
                        else if (response.failure == 1)
                        {
                            
                        }

                    }
                }

            }
        }

    }
}

public class FCMResponse
{
    public long multicast_id { get; set; }
    public int success { get; set; }
    public int failure { get; set; }
    public int canonical_ids { get; set; }
    public List<FCMResult> results { get; set; }
}


public class FCMResult { }
