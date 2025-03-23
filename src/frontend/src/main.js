import { createApp } from 'vue'
import '@/app/styles/global.css'
import App from './app'
import {router} from "@/app/router/index.js";

createApp(App)
    .use(router)
    .mount('#app')
