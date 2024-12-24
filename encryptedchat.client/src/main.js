import './assets/main.css'
import { createApp } from 'vue'
import VueSignalR from '@latelier/vue-signalr'
import App from './App.vue'

Vue.use(VueSignalR, 'https://localhost:7081/chatHub')

createApp(App).mount('#app')
