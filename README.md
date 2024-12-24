Server: 
1) app.MapHub<ChatHub>("/chatHub");

Client:
1) main.js:
Add:
  import VueSignalR from '@latelier/vue-signalr'
  Vue.use(VueSignalR, 'https://localhost:7081/chatHub')
