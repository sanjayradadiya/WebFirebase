<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="manifest" href="manifest.json">
    <script type="text/javascript">
        if ('serviceWorker' in navigator) {
            console.log('Service Worker is supported');
            navigator.serviceWorker.register('sw.js').then(function () {
                return navigator.serviceWorker.ready;
            }).then(function (reg) {
                console.log('Service Worker is ready :^)', reg);

                reg.pushManager.subscribe({ userVisibleOnly: true }).then(function (sub) {
                    console.log('endpoint:', sub.endpoint);
                    document.getElementById("Hidden1").value = sub.endpoint;
                });
            }).catch(function (error) {
                console.log('Service Worker error :^(', error);
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="hidden" id="Hidden1" />
    </div>
    </form>
</body>
</html>
