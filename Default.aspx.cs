using System;
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
            to = "fQLxHW2fzuc:APA91bEkGKWqVlmZkM_Z9rZTF5bYbytOOsHFbfg7lL1vVzb6XycWkf-0NuMSdwo7hfpSlNuVBbx7o4i-E549eVCkvBbtPEb-dohuHiKLg18ROthj6ds3QIYyZKi_dsrHBn-uNxKGOhX-",
            data = new
            {
                body = "This is the message",
                title = "This is the title"
            }

        };
        string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(objNotification);
        Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
        tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAA80JHkUE:APA91bG2LuMawMpo9TiWbDxbc3GBRVbERu3TyKZIbNb_jTMs5C4q_pQrjLmF5-QJFGgj3FzMthR16nFCi2qrYOlCDrPvFop1uhlqMIMEoKaJsUu7vUZjKMvwazWZFbgalKEb1uhbOCIK7YK5yotusvbwyPO60pgANw"));
        tRequest.Headers.Add(string.Format("Sender: id={0}", "1044789039425"));
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

                        /*FCMResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                        if (response.success == 1)
                        {
                            //new NotificationBLL().InsertNotificationLog(dayNumber, notification, true);
                        }
                        else if (response.failure == 1)
                        {
                            //new NotificationBLL().InsertNotificationLog(dayNumber, notification, false);
                            //sbLogger.AppendLine(string.Format("Error sent from FCM server, after sending request : {0} , for following device info: {1}", responseFromFirebaseServer, jsonNotificationFormat));

                        }*/

                    }
                }

            }
        }

    }
}