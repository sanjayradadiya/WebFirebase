'use strict';

console.log('Started', self);

self.addEventListener('install', function (event) {
    self.skipWaiting();
    console.log('Installed', event);
});

self.addEventListener('activate', function (event) {
    console.log('Activated', event);
});

self.addEventListener('push', function (event) {
    event.waitUntil(
      self.registration.pushManager.getSubscription().then(function (subscription) {
          var notificationsPath = 'http://localhost:11546?endpoint=' + encodeURIComponent(subscription.endpoint);
          var headers = new Headers();
          headers.append('Accept', 'application/json');
          return fetch(notificationsPath, { headers: headers }).then(function (response) {
              return response.json().then(function (notifications) {
                  return Promise.all(
                    notifications.map(function (notification) {
                        return self.registration.showNotification(notification.title, {
                            body: notification.body,
                            //icon: notification.icon_url
                        });
                    })
                  );
              });
          }).catch(function (xhr, status, error) {
              console.error('Unable to retrieve the server.', error);
          });
      })
    );
});